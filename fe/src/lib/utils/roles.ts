const ADMIN_ROLE_SET = new Set([
	"ADMIN",
	"SUPERADMIN",
	"ADMINMNGR",
	"STAFF",
	"MODERATOR",
]);

export function normalizeRoleName(roleName?: string | null): string {
	return (roleName ?? "").trim().toUpperCase();
}

export function isAdminRole(roleName?: string | null): boolean {
	return ADMIN_ROLE_SET.has(normalizeRoleName(roleName));
}

export function hasRequiredRole(
	roleName: string | null | undefined,
	requiredRoles: string[],
): boolean {
	if (requiredRoles.length === 0) return true;
	const normalizedRole = normalizeRoleName(roleName);
	return requiredRoles.some(
		(role) => normalizeRoleName(role) === normalizedRole,
	);
}
