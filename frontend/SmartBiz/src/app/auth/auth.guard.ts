import { CanActivate, CanActivateFn } from '@angular/router';
import { AuthService } from './auth.service';
import { Injectable } from '@angular/core';
import { Router } from '@angular/router';
import { map, Observable, take } from 'rxjs';
@Injectable({
  providedIn: 'root'
})
export class AuthGuard implements CanActivate {
  constructor(private authService: AuthService, private router: Router) { }

  canActivate(): Observable<boolean> {
    return this.authService.isAuthenticated().pipe(
      take(1),
      map(isAuthenticated => {
        if (isAuthenticated) {
          return true;
        } else {
          this.router.navigate(['/login']);
          return false;
        }
      })
    );
  }
}

