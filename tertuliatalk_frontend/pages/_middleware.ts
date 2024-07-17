import { NextRequest, NextResponse } from 'next/server';
import { verifyJwtToken } from '../lib/auth';

const AUTH_PAGES = ['/login'];

const isAuthPages = (url: string) => AUTH_PAGES.some((page) => url.startsWith(page));

export async function middleware(request: NextRequest) {
  const { nextUrl, cookies } = request;
  const token = cookies['token'];

  const hasVerifiedToken = token && (await verifyJwtToken(token));
  const isAuthPageRequested = isAuthPages(nextUrl.pathname);

  if (isAuthPageRequested) {
    // If the page is an auth page
    if (!hasVerifiedToken) {  
      return NextResponse.next();
    }
    // Redirect to home page if the user is already logged in
    return NextResponse.redirect(new URL(`/`, request.url));
  }

  if (!hasVerifiedToken) {
    // If the page is protected page and the user is not logged in
    const searchParams = new URLSearchParams(nextUrl.searchParams);
    searchParams.set('next', nextUrl.pathname);
    return NextResponse.redirect(new URL(`/login?${searchParams}`, request.url));
  }

  return NextResponse.next();
}

export const config = {
  matcher: ['/'], // Apply to all pages except static files and favicon
};
