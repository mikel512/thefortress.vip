import { CommonModule } from '@angular/common';
import { NgModule } from '@angular/core';
import { FormsModule } from '@angular/forms';
import { Router, RouterModule } from '@angular/router';
import { AccountService } from '@services/account.service';
import { SharedModule } from 'src/app/pages/shared/shared.module';
import { AccountInfoComponent } from './account-info.component';
import { AccountComponent } from './account.component';
import { ChangePasswordComponent } from './change-password.component';


@NgModule({
    imports: [
        FormsModule,
        CommonModule,
        SharedModule,
        RouterModule.forChild([
            { 
                path: '',
                component: AccountComponent,
                children:[
                    { path: 'info', component: AccountInfoComponent},
                    { path: 'change-password', component: ChangePasswordComponent}
                ]
            }
        ])
    ],
    exports: [],
    declarations: [
        ChangePasswordComponent,
        AccountComponent,
        AccountInfoComponent,
    ],
    providers: [AccountService],
})
export class AccountModule { }
