import type { LayoutServerLoad } from './$types';
import { redirect } from '@sveltejs/kit';

export const load: LayoutServerLoad = async ({ locals, url }) => {
  // If user is already authenticated, redirect to appropriate dashboard
  if (locals.isAuthenticated && locals.user) {
    const adminRoles = ['Admin', 'SuperAdmin', 'ADMINMNGR', 'Staff', 'Moderator'];
    const isAdmin = adminRoles.includes(locals.user.roleName);
    const redirectTo = isAdmin ? '/admin' : '/dashboard';
    throw redirect(302, redirectTo);
  }

  return {
    user: null,
    isAuthenticated: false
  };
};
