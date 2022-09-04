import { CommonModule } from '@angular/common';
import { NgModule } from '@angular/core';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { RouterModule } from '@angular/router';
import { MyDirectivesModule } from '../directives/my-directives.module';
import { LoadingAnimationsModule } from '../loading-animations/loading-animations.module';
import { SharedModule } from '../pages/shared/shared.module';
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
        MyDirectivesModule,
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
