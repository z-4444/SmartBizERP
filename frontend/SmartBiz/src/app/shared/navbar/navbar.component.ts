import { CommonModule } from '@angular/common';
import { Component, HostListener } from '@angular/core';
import { RouterLink, RouterLinkActive } from '@angular/router';
import { AuthService } from '../../auth/auth.service';

interface NavLink {
  label: string;
  route: string;
  icon?: string;
}


@Component({
  selector: 'app-navbar',
  imports: [CommonModule, RouterLink, RouterLinkActive],
  templateUrl: './navbar.component.html',
  styleUrl: './navbar.component.scss'
})
export class NavbarComponent {

  isScrolled = false;
  isMobileMenuOpen = false;

  constructor(public authService: AuthService) { }

  navLinks: NavLink[] = [
    { label: 'Home', route: '/', icon: '🏠' },
    { label: 'Dashboard', route: '/dashboard', icon: '📊' },
    { label: 'Inventory', route: '/inventory', icon: '📦' },
    { label: 'Sales', route: '/sales', icon: '💰' },
    { label: 'Orders', route: '/orders', icon: '📋' },
    { label: 'Customers', route: '/customers', icon: '👥' },
    { label: 'Reports', route: '/reports', icon: '📈' }
  ];

  isAuthenticated() {
    return this.authService.isAuthenticated();
  }
  logout() {
    this.authService.logout();
  }

  @HostListener('window:scroll', [])
  onWindowScroll() {
    this.isScrolled = window.scrollY > 50;
  }

  toggleMobileMenu() {
    this.isMobileMenuOpen = !this.isMobileMenuOpen;
  }

  closeMobileMenu() {
    this.isMobileMenuOpen = false;
  }

}
