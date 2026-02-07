<script lang="ts">
	import { onMount } from "svelte";
	import { navigationStore } from "$lib/stores/navigation";
	import { page } from "$app/stores";
	import { apiService } from "$lib/api";
	import type { NavigationItem, NavigationGroup } from "$lib/api";

	// Import all possible icons
	import {
		Home,
		Users,
		Calendar,
		FileText,
		Settings,
		BarChart3,
		Shield,
		Mail,
		User,
		Plus,
		Download,
		Image,
		Bell,
		LogOut,
		Menu,
		X,
		Info,
		GraduationCap,
		CheckCircle,
		Newspaper,
		Folder,
		TrendingUp,
		Navigation,
		ChevronDown,
		ChevronUp,
	} from "lucide-svelte";

	export let type: "main" | "admin" | "mobile" = "main";
	export let showGroups = true;
	export let className = "";
	export let collapsible = false; // New prop to enable collapsible groups

	// Icon mapping
	const iconMap: Record<string, any> = {
		home: Home,
		users: Users,
		calendar: Calendar,
		"file-text": FileText,
		settings: Settings,
		"bar-chart": BarChart3,
		shield: Shield,
		mail: Mail,
		user: User,
		plus: Plus,
		download: Download,
		image: Image,
		bell: Bell,
		"graduation-cap": GraduationCap,
		"check-circle": CheckCircle,
		newspaper: Newspaper,
		folder: Folder,
		"trending-up": TrendingUp,
		navigation: Navigation,
	};

	let isLoggedIn = false;
	let expandedGroups: Record<string, boolean> = {}; // Track which groups are expanded

	onMount(() => {
		// Check if user is logged in
		isLoggedIn = apiService.isAuthenticated();

		// Load navigation when component mounts (only if logged in)
		if (isLoggedIn) {
			navigationStore.loadUserNavigation();
		}
	});

	$: navigation = $navigationStore.navigation;
	$: loading = $navigationStore.loading;
	$: error = $navigationStore.error;

	// Initialize all groups as expanded when navigation loads
	$: if (navigation) {
		navigation.groups.forEach((group) => {
			if (expandedGroups[group.id] === undefined) {
				expandedGroups[group.id] = true; // Expand all by default
			}
		});
	}

	function toggleGroup(groupId: string) {
		expandedGroups[groupId] = !expandedGroups[groupId];
	}

	function getIcon(iconName: string | undefined) {
		if (!iconName) return null;
		return iconMap[iconName] || null;
	}

	function isActive(item: NavigationItem): boolean {
		const path = $page.url.pathname;
		return path === item.url || path.startsWith(item.url + "/");
	}

	function getNavigationItems(): NavigationItem[] {
		if (!navigation || !isLoggedIn) return [];

		if (type === "main") {
			return (
				navigation.groups.find((g) =>
					g.name.toLowerCase().includes("main"),
				)?.navigationItems || []
			);
		} else if (type === "admin") {
			return navigation.groups
				.filter((g) =>
					["administration", "content", "analytics", "settings"].some(
						(name) => g.name.toLowerCase().includes(name),
					),
				)
				.flatMap((g) => g.navigationItems);
		}

		return navigation.flatItems;
	}

	function getNavigationGroups(): NavigationGroup[] {
		if (!navigation || !showGroups || !isLoggedIn) return [];

		// Return all groups for tree structure view
		// Filter only active groups
		return navigation.groups.filter((g) => g.isActive);
	}
</script>

{#if loading}
	<div class="flex items-center justify-center p-4">
		<div
			class="animate-spin rounded-full h-6 w-6 border-b-2 border-primary-600"
		></div>
	</div>
{:else if error}
	<div class="text-red-600 text-sm p-4">
		{error}
	</div>
{:else}
	<nav id="navigation" class={className}>
		{#if showGroups}
			<!-- Tree structure: All groups with all their menus -->
			{#each getNavigationGroups() as group}
				{console.log(group)}
				<div class="mb-6">
					<!-- Group Header with optional collapse toggle -->
					{#if collapsible}
						<button
							type="button"
							class="flex items-center justify-between w-full px-3 mb-3 cursor-pointer hover:bg-gray-50 rounded-lg py-2 -mx-1 px-4"
							on:click={() => toggleGroup(group.id)}
						>
							<h3
								class="text-xs font-semibold text-gray-500 uppercase tracking-wider"
							>
								{group.name}
								{#if group.description}
									<span
										class="text-gray-400 normal-case font-normal ml-2"
										>• {group.description}</span
									>
								{/if}
							</h3>
							<svelte:component
								this={expandedGroups[group.id]
									? ChevronUp
									: ChevronDown}
								class="h-4 w-4 text-gray-400"
							/>
						</button>
					{:else}
						<div
							class="flex items-center justify-between px-3 mb-3"
						>
							<h3
								class="text-xs font-semibold text-gray-500 uppercase tracking-wider"
							>
								{group.name}
								{#if group.description}
									<span
										class="text-gray-400 normal-case font-normal ml-2"
										>• {group.description}</span
									>
								{/if}
							</h3>
						</div>
					{/if}

					<!-- Navigation items - show/hide based on collapsed state -->
					{#if !collapsible || expandedGroups[group.id]}
						<div class="space-y-1">
							{#each group.navigationItems.filter((item) => item.isActive) as item}
								{@const IconComponent = getIcon(item.icon)}
								{@const active = isActive(item)}

								<a
									href={item.url}
									class="flex items-center px-3 py-2 text-sm font-medium rounded-lg transition-colors duration-200 {active
										? 'bg-primary-100 text-primary-700'
										: 'text-gray-700 hover:bg-gray-100'}"
								>
									{#if IconComponent}
										<svelte:component
											this={IconComponent}
											class="h-5 w-5 mr-3"
										/>
									{/if}
									{item.label}
								</a>

								<!-- Nested children (sub-menus) -->
								{#if item.children && item.children.length > 0}
									<div
										class="ml-6 space-y-1 border-l-2 border-gray-200 pl-3"
									>
										{#each item.children.filter((child) => child.isActive) as child}
											{@const ChildIconComponent =
												getIcon(child.icon)}
											{@const childActive =
												isActive(child)}

											<a
												href={child.url}
												class="flex items-center px-3 py-2 text-sm rounded-lg transition-colors duration-200 {childActive
													? 'bg-primary-50 text-primary-600'
													: 'text-gray-600 hover:bg-gray-50'}"
											>
												{#if ChildIconComponent}
													<svelte:component
														this={ChildIconComponent}
														class="h-4 w-4 mr-3"
													/>
												{/if}
												{child.label}
											</a>
										{/each}
									</div>
								{/if}
							{/each}
						</div>
					{/if}
				</div>
			{/each}
		{:else}
			{#each getNavigationItems().filter((item) => item.isActive) as item}
				{@const IconComponent = getIcon(item.icon)}
				{@const active = isActive(item)}

				<a
					href={item.url}
					class="flex items-center px-3 py-2 text-sm font-medium rounded-lg transition-colors duration-200 {active
						? 'bg-primary-100 text-primary-700'
						: 'text-gray-700 hover:bg-gray-100'}"
				>
					{#if IconComponent}
						<svelte:component
							this={IconComponent}
							class="h-5 w-5 mr-3"
						/>
					{/if}
					{item.label}
				</a>

				{#if item.children && item.children.length > 0}
					<div class="ml-6 space-y-1">
						{#each item.children.filter((child) => child.isActive) as child}
							{@const ChildIconComponent = getIcon(child.icon)}
							{@const childActive = isActive(child)}

							<a
								href={child.url}
								class="flex items-center px-3 py-2 text-sm rounded-lg transition-colors duration-200 {childActive
									? 'bg-primary-50 text-primary-600'
									: 'text-gray-600 hover:bg-gray-50'}"
							>
								{#if ChildIconComponent}
									<svelte:component
										this={ChildIconComponent}
										class="h-4 w-4 mr-3"
									/>
								{/if}
								{child.label}
							</a>
						{/each}
					</div>
				{/if}
			{/each}
		{/if}
	</nav>
{/if}
