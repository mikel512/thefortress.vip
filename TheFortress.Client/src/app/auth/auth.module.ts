import { CommonModule } from '@angular/common';
import { NgModule } from '@angular/core';
import { FormsModule } from '@angular/forms';
import { RouterModule } from '@angular/router';
import { LoadingAnimationsModule } from '../loading-animations/loading-animations.module';
import { AuthComponent } from './auth.component';
import { LoginComponent } from './pages/login.component';
import { RegisterComponent } from './pages/register.component';


@NgModule({
    declarations: [
        AuthComponent,
        LoginComponent,
        RegisterComponent,
    ],
    imports: [
        CommonModule,
        FormsModule,
        RouterModule.forChild([
            {
                path: '',
                component: AuthComponent,
                children: [
                    { path: 'login', component: LoginComponent },
                    { path: 'register', component: RegisterComponent}
                ]
            },
        ]),
        LoadingAnimationsModule,

    ],
    exports: [],
    providers: [],
})
export class AuthModule { }
