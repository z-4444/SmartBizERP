import { Routes } from '@angular/router';
import { LoginComponent } from './auth/login/login.component';
import { RegisterComponent } from './auth/register/register.component';
import { AuthService } from './auth/auth.service';
import { Injectable } from '@angular/core';
import { AuthGuard } from './auth/auth.guard';
import { DashboardComponent } from './pages/dashboard/dashboard.component';
import { HomeComponent } from './pages/home/home.component';

export const routes: Routes = [
    { path: '', component: HomeComponent },
    {
        path: 'login',
        component: LoginComponent
    },
    {
        path: 'register',
        component: RegisterComponent
    },
    {
        path: 'dashboard',
        component: DashboardComponent,
        canActivate: [AuthGuard]
    },
    { path: '**', redirectTo: '' } // catch-all
];
