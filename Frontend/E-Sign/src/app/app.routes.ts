import { Routes } from '@angular/router';
import { LoginComponent } from './login/login.component';
import { SignupComponent } from './signup/signup.component';
import { AgreementsComponent } from './agreements/agreements.component';

export const routes: Routes = [
    {
        path:"login", component:LoginComponent
    },
    {
        path:"register",component:SignupComponent
    },
    {
        path:"agreements",component:AgreementsComponent
    },
    {
        path:"",redirectTo:'/login',pathMatch:'full'
    }
];
