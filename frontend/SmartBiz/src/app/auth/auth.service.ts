import { Injectable } from '@angular/core';
import { environment } from '../../environments/environment';
import { HttpClient } from '@angular/common/http';
import { catchError, Observable, of, tap, throwError } from 'rxjs';
import { CallTracker } from 'assert';
import { Router } from '@angular/router';

@Injectable({
  providedIn: 'root'
})
export class AuthService {
  isAuthenticated(): Observable<boolean> {
    const token = this.getToken();
    return of(!!token);
  }
  private apiUrl = environment.apiUrl + '/auth';
  private tokenKey = 'app_token';

  constructor(private http: HttpClient, private router: Router) { }

  login(credentials: any): Observable<{ token: string }> {
    return this.http.post<{ token: string }>(`${this.apiUrl}/login`, credentials).pipe(
      tap(response => this.saveToken(response.token)),
      catchError(error => {
        console.error('Login failed:', error);
        return throwError(() => error)
      })
    );
  }

  saveToken(token: string): void {
    localStorage.setItem(this.tokenKey, token);
  }

  getToken(): string | null {
    return localStorage.getItem(this.tokenKey);
  }

  register(userData: any): Observable<any> {
    // Construct the full URL using the base path
    return this.http.post<any>(`${this.apiUrl}/register`, userData);
  }

  // --- LOGOUT ---
  logout() {
    localStorage.removeItem(this.tokenKey);   // remove JWT
    this.router.navigate(['/login']);         // navigate to login page
  }
}