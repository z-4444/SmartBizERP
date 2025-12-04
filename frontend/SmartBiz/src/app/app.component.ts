import { Component } from '@angular/core';
import { RouterOutlet, Router, NavigationEnd } from '@angular/router';
import { NavbarComponent } from './shared/navbar/navbar.component';
import { FooterComponent } from './shared/footer/footer.component';
import { filter } from 'rxjs';

@Component({
  selector: 'app-root',
  imports: [RouterOutlet, NavbarComponent, FooterComponent],
  templateUrl: './app.component.html',
  styleUrl: './app.component.scss'
})
export class AppComponent {
  title = 'SmartBiz';
  showNavbar: boolean = true;

  constructor(private router: Router) {
    this.router.events
      .pipe(
        filter(event => event instanceof NavigationEnd)
      ).subscribe((event: NavigationEnd) => {
        const isLoginOrRegister = ['/login', '/register'].some(path => event.urlAfterRedirects.startsWith(path));
        this.showNavbar = !isLoginOrRegister;
      });
  }
}

