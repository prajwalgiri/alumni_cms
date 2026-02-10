import type { LayoutServerLoad } from './$types';
import { redirect } from '@sveltejs/kit';
import { isAdminRole } from '$lib/utils/roles';

export const load: LayoutServerLoad = async ({ locals }) => {
  // Check if user is authenticated
  if (!locals.isAuthenticated || !locals.user) {
    throw redirect(302, '/auth/login?redirect=' + encodeURIComponent('/dashboard'));
  }

  if (isAdminRole(locals.user.roleName)) {
    throw redirect(302, '/admin');
  }

  return {
    user: locals.user,
    isAuthenticated: locals.isAuthenticated
  };
};
