import { CommonModule } from '@angular/common';
import { NgModule } from '@angular/core';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { RouterModule } from '@angular/router';
import { AppFormsModule } from '@forms/forms.module';
import { MyDirectivesModule } from '../directives/my-directives.module';
import { LoadingAnimationsModule } from '../loading-animations/loading-animations.module';
import { SharedModule } from '../pages/shared/shared.module';
import { AuthComponent } from './auth.component';
import { ConfirmationComponent } from './pages/confirmation.component';
import { LoginComponent } from './pages/login.component';
import { RegisterComponent } from './pages/register.component';


@NgModule({
    declarations: [
        AuthComponent,
        LoginComponent,
        RegisterComponent,
        ConfirmationComponent,
    ],
    imports: [
        MyDirectivesModule,
        AppFormsModule,
        CommonModule,
        SharedModule,
        FormsModule,
        ReactiveFormsModule,
        RouterModule.forChild([
            {
                path: '',
                component: AuthComponent,
                children: [
                    { path: 'login', component: LoginComponent },
                    { path: 'register', component: RegisterComponent },
                    { path: 'confirm-email/:userId/:hash', component: ConfirmationComponent }
                ]
            },
        ]),
        LoadingAnimationsModule,

    ],
    exports: [],
    providers: [],
})
export class AuthModule { }
