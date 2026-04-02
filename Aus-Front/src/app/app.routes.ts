import { Routes } from '@angular/router';
import { LoginPage } from './Pages/login-page/login-page';
import { ProductsPage } from './Pages/products-page/products-page';
import { authGuard } from './Guards/auth-guard';

export const routes: Routes = [
    {
        path: 'login',
        component: LoginPage
    },
    {
        path: 'products',
        component: ProductsPage,
        canActivate: [authGuard]
    },
    {
        path: '',
        redirectTo: 'login',
        pathMatch: 'full'
    },
    {
        path: '**',
        redirectTo: 'login',
    }
];
