import { CommonModule } from '@angular/common';
import { Component } from '@angular/core';
import { RouterLink } from '@angular/router';

interface FooterLink {
  label: string;
  route: string;
}

interface FooterSection {
  title: string;
  links: FooterLink[];
}

interface SocialLink {
  name: string;
  icon: string;
  url: string;
}


@Component({
  selector: 'app-footer',
  imports: [CommonModule, RouterLink],
  templateUrl: './footer.component.html',
  styleUrl: './footer.component.scss'
})
export class FooterComponent {

  currentYear = new Date().getFullYear();

  footerSections: FooterSection[] = [
    {
      title: 'Product',
      links: [
        { label: 'Features', route: '/features' },
        { label: 'Pricing', route: '/pricing' },
        { label: 'Dashboard', route: '/dashboard' },
        { label: 'Reports', route: '/reports' }
      ]
    },
    {
      title: 'Company',
      links: [
        { label: 'About Us', route: '/about' },
        { label: 'Careers', route: '/careers' },
        { label: 'Blog', route: '/blog' },
        { label: 'Contact', route: '/contact' }
      ]
    },
    {
      title: 'Resources',
      links: [
        { label: 'Documentation', route: '/docs' },
        { label: 'Help Center', route: '/help' },
        { label: 'Tutorials', route: '/tutorials' },
        { label: 'API', route: '/api' }
      ]
    },
    {
      title: 'Legal',
      links: [
        { label: 'Privacy Policy', route: '/privacy' },
        { label: 'Terms of Service', route: '/terms' },
        { label: 'Cookie Policy', route: '/cookies' },
        { label: 'GDPR', route: '/gdpr' }
      ]
    }
  ];

  socialLinks: SocialLink[] = [
    { name: 'Twitter', icon: '𝕏', url: 'https://twitter.com' },
    { name: 'LinkedIn', icon: '💼', url: 'https://linkedin.com' },
    { name: 'Facebook', icon: '👥', url: 'https://facebook.com' },
    { name: 'Instagram', icon: '📷', url: 'https://instagram.com' }
  ];
}
