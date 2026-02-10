import type { Handle } from '@sveltejs/kit';
import { JWT_SECRET } from '$env/static/private';
import jwt from 'jsonwebtoken';
import { isAdminRole } from '$lib/utils/roles';

// Define protected routes that require authentication
const PROTECTED_ROUTES = [
  '/dashboard',
  '/admin',
  '/profile',
  '/alumni/new',
  '/events/new'
];

// Define admin-only routes
const ADMIN_ROUTES = [
  '/admin'
];

// Define public routes that don't require authentication
const PUBLIC_ROUTES = [
  '/',
  '/auth/login',
  '/auth/register',
  '/alumni',
  '/events',
  '/about',
  '/contact'
];

export const handle: Handle = async ({ event, resolve }) => {
  const { url, request } = event;
  const pathname = url.pathname;

  // Skip middleware for static assets and API routes
  if (pathname.startsWith('/api/') || pathname.startsWith('/_app/') || pathname.includes('.')) {
    return resolve(event);
  }

  // Get the JWT token from cookies
  const token = event.cookies.get('authToken') ||
    request.headers.get('authorization')?.replace('Bearer ', '');

  let user = null;
  let isAuthenticated = false;

  // Verify JWT token if present
  if (token) {
    try {
      const decoded = jwt.verify(token, JWT_SECRET) as any;
      const emailClaim =
        decoded.email ||
        decoded['http://schemas.xmlsoap.org/ws/2005/05/identity/claims/emailaddress'];
      const idClaim =
        decoded.id ||
        decoded['http://schemas.xmlsoap.org/ws/2005/05/identity/claims/nameidentifier'];
      const roleNameClaim =
        decoded.roleName ||
        decoded.role ||
        decoded['http://schemas.microsoft.com/ws/2008/06/identity/claims/role'];

      user = {
        id: idClaim,
        email: emailClaim,
        firstName: decoded.firstName,
        lastName: decoded.lastName,
        roleId: decoded.roleId,
        roleName: roleNameClaim
      };
      isAuthenticated = true;

      // Add user to event.locals for use in load functions
      event.locals.user = user;
      event.locals.isAuthenticated = true;
    } catch (error) {
      console.log('Invalid JWT token:', error);
      // Clear invalid token
      event.cookies.delete('authToken', { path: '/' });
    }
  }

  // Check if route requires authentication
  const requiresAuth = PROTECTED_ROUTES.some(route => pathname.startsWith(route));
  const isAdminRoute = ADMIN_ROUTES.some(route => pathname.startsWith(route));
  const isPublicRoute = PUBLIC_ROUTES.some(route => pathname === route || pathname.startsWith(route));

  // Handle authentication requirements
  if (requiresAuth && !isAuthenticated) {
    // Redirect to login if accessing protected route without authentication
    return new Response(null, {
      status: 302,
      headers: {
        Location: '/auth/login?redirect=' + encodeURIComponent(pathname)
      }
    });
  }

  // Handle admin route access
  if (isAdminRoute && isAuthenticated) {
    const isAdmin = isAdminRole(user?.roleName);
    if (!isAdmin) {
      // Redirect non-admin users to dashboard
      return new Response(null, {
        status: 302,
        headers: {
          Location: '/dashboard'
        }
      });
    }
  }

  // Handle authenticated users trying to access auth pages
  if (isAuthenticated && (pathname === '/auth/login' || pathname === '/auth/register')) {
    // Redirect authenticated users to appropriate dashboard
    const isAdmin = isAdminRole(user?.roleName);
    const redirectTo = isAdmin ? '/admin' : '/dashboard';

    return new Response(null, {
      status: 302,
      headers: {
        Location: redirectTo
      }
    });
  }

  // Add authentication headers for client-side use
  event.locals.user = user;
  event.locals.isAuthenticated = isAuthenticated;

  const response = await resolve(event);

  // Add security headers
  response.headers.set('X-Frame-Options', 'DENY');
  response.headers.set('X-Content-Type-Options', 'nosniff');
  response.headers.set('Referrer-Policy', 'strict-origin-when-cross-origin');
  response.headers.set('Permissions-Policy', 'camera=(), microphone=(), geolocation=()');

  return response;
};
