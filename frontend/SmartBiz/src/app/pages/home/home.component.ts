import { CommonModule } from '@angular/common';
import { Component } from '@angular/core';
import { RouterLink } from '@angular/router';

interface Feature {
  icon: string;
  title: string;
  description: string;
  route: string;
}

interface Stat {
  value: string;
  label: string;
  icon: string;
}

interface BusinessType {
  icon: string;
  name: string;
}

interface Testimonial {
  name: string;
  business: string;
  message: string;
  avatar: string;
}

@Component({
  selector: 'app-home',
  imports: [CommonModule, RouterLink],
  templateUrl: './home.component.html',
  styleUrl: './home.component.scss'
})
export class HomeComponent {

  features: Feature[] = [
    {
      icon: '📦',
      title: 'Inventory Management',
      description: 'Track your stock levels, get low-stock alerts, and manage products effortlessly.',
      route: '/inventory'
    },
    {
      icon: '💰',
      title: 'Sales Tracking',
      description: 'Record daily sales, process payments, and monitor revenue in real-time.',
      route: '/sales'
    },
    {
      icon: '📋',
      title: 'Order Management',
      description: 'Handle customer orders from WhatsApp, Shopify, or walk-ins - all in one place.',
      route: '/orders'
    },
    {
      icon: '👥',
      title: 'Customer Database',
      description: 'Maintain customer records, purchase history, and contact details easily.',
      route: '/customers'
    },
    {
      icon: '📊',
      title: 'Business Reports',
      description: 'Generate daily, weekly, and monthly reports to track your business performance.',
      route: '/reports'
    },
    {
      icon: '👨‍💼',
      title: 'Team Management',
      description: 'Add staff members, assign roles, and control access permissions.',
      route: '/settings'
    }
  ];

  stats: Stat[] = [
    { value: 'Rs. 2,500', label: 'Monthly Cost', icon: '💵' },
    { value: '< 5 Min', label: 'Setup Time', icon: '⚡' },
    { value: '500+', label: 'Happy Businesses', icon: '🎉' },
    { value: '24/7', label: 'Support Available', icon: '💬' }
  ];

  businessTypes: BusinessType[] = [
    { icon: '🛒', name: 'Retail Shops' },
    { icon: '📱', name: 'Mobile Shops' },
    { icon: '👔', name: 'Garment Stores' },
    { icon: '📚', name: 'Book Stores' },
    { icon: '🛋️', name: 'Furniture Business' },
    { icon: '💊', name: 'Pharmacy' },
    { icon: '🔌', name: 'Electronics' },
    { icon: '📦', name: 'Wholesalers' },
    { icon: '🌐', name: 'Online Sellers' },
    { icon: '🎁', name: 'Gift Shops' },
    { icon: '🏪', name: 'General Store' },
    { icon: '👗', name: 'Boutiques' }
  ];

  testimonials: Testimonial[] = [
    {
      name: 'Ahmed Khan',
      business: 'Mobile Shop Owner, Karachi',
      message: 'SmartBiz made my daily operations so much easier! Now I can track my inventory and sales from my phone.',
      avatar: '👨'
    },
    {
      name: 'Fatima Malik',
      business: 'Boutique Owner, Lahore',
      message: 'Perfect solution for small businesses like mine. Easy to use and very affordable compared to other systems.',
      avatar: '👩'
    },
    {
      name: 'Hassan Ali',
      business: 'Electronics Store, Islamabad',
      message: 'My staff learned it in just one day! Customer management and order tracking features are excellent.',
      avatar: '👨‍💼'
    }
  ];

  currentYear = new Date().getFullYear();
}
