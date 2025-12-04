import { CommonModule } from '@angular/common';
import { Component } from '@angular/core';
import { RouterLink } from '@angular/router';

interface QuickStat {
  icon: string;
  label: string;
  value: string | number;
  change: string;
  changeType: 'positive' | 'negative' | 'neutral' | 'warning';
  route: string;
}

interface QuickAction {
  icon: string;
  label: string;
  description: string;
  route: string;
  color: string;
  allowedRoles: string[];
}

interface RecentActivity {
  icon: string;
  title: string;
  description: string;
  time: string;
  type: 'success' | 'warning' | 'info';
}

interface LowStockItem {
  name: string;
  currentStock: number;
  minStock: number;
  category: string;
}

@Component({
  selector: 'app-dashboard',
  imports: [CommonModule, RouterLink],
  templateUrl: './dashboard.component.html',
  styleUrl: './dashboard.component.scss'
})
export class DashboardComponent {

  // Simulated user role - replace with actual auth service
  userRole: 'admin' | 'manager' | 'employee' = 'admin';
  userName: string = 'Admin User';
  businessName: string = 'My Business';

  currentDate: Date = new Date();

  quickStats: QuickStat[] = [
    {
      icon: '💰',
      label: 'Total Sales',
      value: 'Rs. 145,000',
      change: '+12.5%',
      changeType: 'positive',
      route: '/sales'
    },
    {
      icon: '📋',
      label: 'Total Orders',
      value: 234,
      change: '+8 today',
      changeType: 'positive',
      route: '/orders'
    },
    {
      icon: '📦',
      label: 'Products',
      value: 456,
      change: '12 low stock',
      changeType: 'warning',
      route: '/inventory'
    },
    {
      icon: '👥',
      label: 'Customers',
      value: 189,
      change: '+5 this week',
      changeType: 'positive',
      route: '/customers'
    }
  ];

  quickActions: QuickAction[] = [
    {
      icon: '🛒',
      label: 'Create Order',
      description: 'Add new sales order',
      route: '/orders/create',
      color: '#667eea',
      allowedRoles: ['admin', 'manager', 'employee']
    },
    {
      icon: '📦',
      label: 'Add Product',
      description: 'Add product to inventory',
      route: '/inventory/add',
      color: '#48bb78',
      allowedRoles: ['admin', 'manager']
    },
    {
      icon: '👤',
      label: 'Add Customer',
      description: 'Register new customer',
      route: '/customers/add',
      color: '#ed8936',
      allowedRoles: ['admin', 'manager']
    },
    {
      icon: '📊',
      label: 'View Reports',
      description: 'Business analytics',
      route: '/reports',
      color: '#9f7aea',
      allowedRoles: ['admin', 'manager']
    },
    {
      icon: '👥',
      label: 'Manage Users',
      description: 'Add/edit users & roles',
      route: '/users',
      color: '#e53e3e',
      allowedRoles: ['admin']
    },
    {
      icon: '⚙️',
      label: 'Settings',
      description: 'System configuration',
      route: '/settings',
      color: '#718096',
      allowedRoles: ['admin']
    }
  ];

  recentActivities: RecentActivity[] = [
    {
      icon: '✓',
      title: 'Order #1234 Completed',
      description: 'Customer: Ahmed Khan - Rs. 5,500',
      time: '5 minutes ago',
      type: 'success'
    },
    {
      icon: '📦',
      title: 'Low Stock Alert',
      description: 'Samsung Galaxy A54 - Only 3 units left',
      time: '15 minutes ago',
      type: 'warning'
    },
    {
      icon: '👤',
      title: 'New Customer Added',
      description: 'Fatima Malik registered',
      time: '1 hour ago',
      type: 'info'
    },
    {
      icon: '✓',
      title: 'Order #1233 Shipped',
      description: 'Customer: Hassan Ali - Rs. 12,000',
      time: '2 hours ago',
      type: 'success'
    },
    {
      icon: '📦',
      title: 'Product Updated',
      description: 'iPhone 15 Pro - Price changed to Rs. 425,000',
      time: '3 hours ago',
      type: 'info'
    }
  ];

  lowStockItems: LowStockItem[] = [
    { name: 'Samsung Galaxy A54', currentStock: 3, minStock: 10, category: 'Mobiles' },
    { name: 'iPhone 13', currentStock: 2, minStock: 5, category: 'Mobiles' },
    { name: 'AirPods Pro', currentStock: 4, minStock: 15, category: 'Accessories' },
    { name: 'USB-C Cable', currentStock: 8, minStock: 20, category: 'Accessories' },
    { name: 'Phone Case - Clear', currentStock: 5, minStock: 25, category: 'Accessories' }
  ];

  // Sales data for chart (simple representation)
  salesData = {
    labels: ['Mon', 'Tue', 'Wed', 'Thu', 'Fri', 'Sat', 'Sun'],
    values: [12000, 15000, 18000, 14000, 22000, 25000, 20000]
  };

  ngOnInit() {
    // Load user data from auth service
    this.loadUserData();
  }

  loadUserData() {
    // Simulate loading user data - replace with actual auth service
    // this.userRole = authService.getUserRole();
    // this.userName = authService.getUserName();
  }

  canAccess(allowedRoles: string[]): boolean {
    return allowedRoles.includes(this.userRole);
  }

  getFilteredQuickActions(): QuickAction[] {
    return this.quickActions.filter(action => this.canAccess(action.allowedRoles));
  }

  getGreeting(): string {
    const hour = this.currentDate.getHours();
    if (hour < 12) return 'Good Morning';
    if (hour < 17) return 'Good Afternoon';
    return 'Good Evening';
  }

  getRoleBadgeClass(): string {
    switch (this.userRole) {
      case 'admin': return 'role-admin';
      case 'manager': return 'role-manager';
      case 'employee': return 'role-employee';
      default: return '';
    }
  }

  getMaxValue(): number {
    return Math.max(...this.salesData.values);
  }

  getBarHeight(value: number): number {
    return (value / this.getMaxValue()) * 100;
  }


}
