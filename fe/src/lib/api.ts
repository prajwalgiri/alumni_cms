// API service for backend communication
const RAW_API_BASE_URL = import.meta.env.VITE_API_BASE_URL;
const API_BASE_URL =
	typeof RAW_API_BASE_URL === "string" &&
	RAW_API_BASE_URL.trim() &&
	RAW_API_BASE_URL.trim() !== "undefined"
		? RAW_API_BASE_URL.trim().replace(/\/+$/, "")
		: "";

export interface ApiResponse<T> {
	success: boolean;
	data?: T;
	message?: string;
}

export interface User {
	id: string;
	email: string;
	firstName: string;
	lastName: string;
	roleId: string;
	roleName: string;
}

export interface AuthResponse {
	token: string;
	user: User;
}

export interface LoginRequest {
	email: string;
	password: string;
}

export interface RegisterRequest {
	firstName: string;
	lastName: string;
	email: string;
	password: string;
}

export interface Alumni {
	id: string;
	userId: string;
	user: User;
	graduationYear: number;
	degree: string;
	major: string;
	currentCompany?: string;
	currentPosition?: string;
	location?: string;
	bio?: string;
	linkedinUrl?: string;
	githubUrl?: string;
	websiteUrl?: string;
	profileImageUrl?: string;
	isPublic: boolean;
	createdAt: string;
	updatedAt: string;
}

export interface AlumniListItem {
	id: string;
	firstName: string;
	lastName: string;
	graduationYear: number;
	degree: string;
	major: string;
	currentCompany?: string;
	currentPosition?: string;
	location?: string;
	bio?: string;
	linkedinUrl?: string;
	githubUrl?: string;
	websiteUrl?: string;
	profileImageUrl?: string;
}

export interface CreateAlumniRequest {
	graduationYear: number;
	degree: string;
	major: string;
	currentCompany?: string;
	currentPosition?: string;
	location?: string;
	bio?: string;
	linkedinUrl?: string;
	githubUrl?: string;
	websiteUrl?: string;
	isPublic: boolean;
}

export interface Event {
	id: string;
	title: string;
	description: string;
	location?: string;
	start_date: string;
	end_date: string;
	max_attendees?: number;
	current_attendees: number;
	is_online: boolean;
	meeting_url?: string;
	created_by: string;
	created_at: string;
	updated_at: string;
}

export interface CreateEventRequest {
	title: string;
	description: string;
	location?: string;
	start_date: string;
	end_date: string;
	max_attendees?: number;
	is_online: boolean;
	meeting_url?: string;
}

export interface NavigationItem {
	id: string;
	label: string;
	icon?: string;
	url?: string;
	order: number;
	parentId?: string;
	groupId?: string;
	isActive: boolean;
	children: NavigationItem[];
}

export interface NavigationGroup {
	id: string;
	name: string;
	description?: string;
	order: number;
	isActive: boolean;
	navigationItems: NavigationItem[];
}

export interface UserNavigation {
	groups: NavigationGroup[];
	flatItems: NavigationItem[];
}

export interface SystemSetting {
	key: string;
	value: string;
	type: string;
	description?: string;
}

class ApiService {
	private baseUrl: string;

	constructor(baseUrl: string = API_BASE_URL) {
		this.baseUrl = this.normalizeBaseUrl(baseUrl);
		if (!this.baseUrl && import.meta.env.DEV) {
			console.warn(
				"VITE_API_BASE_URL is not set. Requests will use relative /api/... paths.",
			);
		}
	}

	private normalizeBaseUrl(baseUrl: string): string {
		if (!baseUrl || baseUrl === "undefined") return "";
		return baseUrl.replace(/\/+$/, "");
	}

	private buildUrl(endpoint: string): string {
		const normalizedEndpoint = endpoint.startsWith("/")
			? endpoint
			: `/${endpoint}`;
		return `${this.baseUrl}${normalizedEndpoint}`;
	}

	private decodeTokenPayload(token: string): Record<string, any> | null {
		const parts = token.split(".");
		if (parts.length !== 3) return null;

		const normalized = parts[1].replace(/-/g, "+").replace(/_/g, "/");
		const padded = normalized + "=".repeat((4 - (normalized.length % 4)) % 4);

		try {
			if (typeof atob !== "function") return null;
			const json = atob(padded);
			return JSON.parse(json);
		} catch {
			return null;
		}
	}

	private getValidToken(): string | null {
		if (typeof window === "undefined") return null;
		const token = localStorage.getItem("authToken");
		if (!token) return null;

		const payload = this.decodeTokenPayload(token);
		if (!payload) {
			this.logout();
			return null;
		}

		const exp = typeof payload.exp === "number" ? payload.exp : null;
		if (exp && Date.now() >= exp * 1000) {
			this.logout();
			return null;
		}

		return token;
	}

	private getAuthHeaders(): HeadersInit {
		const token = this.getValidToken();
		console.log(
			"Using token for request:",
			token ? "Token present" : "No token",
		);
		return {
			"Content-Type": "application/json",
			...(token && { Authorization: `Bearer ${token}` }),
		};
	}

	private async handleResponse<T>(response: Response): Promise<ApiResponse<T>> {
		let data: any;
		const responseClone = response.clone();
		try {
			data = await response.json();
		} catch (error) {
			// If response is not JSON, get the text content from the clone
			const textContent = await responseClone.text();
			console.error("Non-JSON response:", textContent);
			throw new Error(
				`Invalid response format: ${response.status} ${response.statusText}`,
			);
		}

		if (!response.ok) {
			throw new Error(
				data.message || data.error || `HTTP error! status: ${response.status}`,
			);
		}

		return data;
	}

	private async request<T>(
		endpoint: string,
		options: RequestInit = {},
	): Promise<ApiResponse<T>> {
		const url = this.buildUrl(endpoint);
		const config: RequestInit = {
			headers: this.getAuthHeaders(),
			...options,
		};

		try {
			const response = await fetch(url, config);
			return await this.handleResponse<T>(response);
		} catch (error) {
			console.error("API request failed:", error);
			throw error;
		}
	}

	// Authentication endpoints
	async login(credentials: LoginRequest): Promise<ApiResponse<AuthResponse>> {
		const response = await this.request<AuthResponse>("/api/auth/login", {
			method: "POST",
			body: JSON.stringify(credentials),
		});

		// If login is successful, set the token in a cookie for server-side access
		if (response.success && response.data) {
			// Set cookie for server-side middleware
			document.cookie = `authToken=${response.data.token}; path=/; max-age=86400; SameSite=Strict`;
		}

		return response;
	}

	async register(
		userData: RegisterRequest,
	): Promise<ApiResponse<AuthResponse>> {
		return this.request<AuthResponse>("/api/auth/register", {
			method: "POST",
			body: JSON.stringify(userData),
		});
	}

	async getCurrentUser(): Promise<ApiResponse<User>> {
		return this.request<User>("/api/auth/me");
	}

	// Alumni endpoints
	async getAlumni(): Promise<ApiResponse<AlumniListItem[]>> {
		return this.request<AlumniListItem[]>("/api/alumni");
	}

	async getAlumniById(id: string): Promise<ApiResponse<Alumni>> {
    console.log(id," tjs os o")
		return this.request<Alumni>(`/api/alumni/${id}`);
	}

	async createAlumni(
		alumniData: CreateAlumniRequest,
	): Promise<ApiResponse<Alumni>> {
		return this.request<Alumni>("/api/alumni", {
			method: "POST",
			body: JSON.stringify(alumniData),
		});
	}

	async updateAlumni(
		id: string,
		alumniData: CreateAlumniRequest,
	): Promise<ApiResponse<Alumni>> {
		return this.request<Alumni>(`/api/alumni/${id}`, {
			method: "PUT",
			body: JSON.stringify(alumniData),
		});
	}

	async deleteAlumni(id: string): Promise<ApiResponse<string>> {
		return this.request<string>(`/api/alumni/${id}`, {
			method: "DELETE",
		});
	}

	// Events endpoints
	async getEvents(): Promise<ApiResponse<Event[]>> {
		return this.request<Event[]>("/api/events");
	}

	async getEventById(id: string): Promise<ApiResponse<Event>> {
		return this.request<Event>(`/api/events/${id}`);
	}

	async createEvent(
		eventData: CreateEventRequest,
	): Promise<ApiResponse<Event>> {
		return this.request<Event>("/api/events", {
			method: "POST",
			body: JSON.stringify(eventData),
		});
	}

	async updateEvent(
		id: string,
		eventData: CreateEventRequest,
	): Promise<ApiResponse<Event>> {
		return this.request<Event>(`/api/events/${id}`, {
			method: "PUT",
			body: JSON.stringify(eventData),
		});
	}

	async deleteEvent(id: string): Promise<ApiResponse<string>> {
		return this.request<string>(`/api/events/${id}`, {
			method: "DELETE",
		});
	}

	// Health check
	async healthCheck(): Promise<
		ApiResponse<{ status: string; timestamp: string; service: string }>
	> {
		return this.request<{ status: string; timestamp: string; service: string }>(
			"/health",
		);
	}

	// Navigation endpoints
	async getUserNavigation(): Promise<ApiResponse<UserNavigation>> {
		return this.request<UserNavigation>("/api/navigation/user");
	}

	async getNavigationByRole(
		roleId: string,
	): Promise<ApiResponse<UserNavigation>> {
		return this.request<UserNavigation>(`/api/navigation/role/${roleId}`);
	}

	// Settings endpoints
	async getSettings(type?: string): Promise<ApiResponse<SystemSetting[]>> {
		const endpoint = type ? `/api/settings?type=${type}` : "/api/settings";
		return this.request<SystemSetting[]>(endpoint);
	}

	async updateSetting(
		key: string,
		value: string,
	): Promise<ApiResponse<boolean>> {
		return this.request<boolean>(`/api/settings/${key}`, {
			method: "PUT",
			body: JSON.stringify({ value }),
		});
	}

	// Utility methods
	isAuthenticated(): boolean {
		return !!this.getValidToken();
	}

	logout(): void {
		if (typeof window !== "undefined") {
			localStorage.removeItem("authToken");
			localStorage.removeItem("user");
		}
		// Clear the auth cookie
		if (typeof document !== "undefined") {
			document.cookie =
				"authToken=; path=/; expires=Thu, 01 Jan 1970 00:00:00 GMT";
		}
	}

	getCurrentUserFromStorage(): User | null {
		if (!this.isAuthenticated()) return null;
		const userStr = localStorage.getItem("user");
		return userStr ? JSON.parse(userStr) : null;
	}
}

// Export singleton instance
export const apiService = new ApiService();
