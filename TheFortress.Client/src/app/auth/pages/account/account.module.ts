import { CommonModule } from '@angular/common';
import { NgModule } from '@angular/core';
import { FormsModule } from '@angular/forms';
import { Router, RouterModule } from '@angular/router';
import { SharedModule } from 'src/app/pages/shared/shared.module';
import { AccountInfoComponent } from './account-info.component';
import { AccountComponent } from './account.component';


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
                    { path: 'info', component: AccountInfoComponent}
                ]
            }
        ])
    ],
    exports: [],
    declarations: [
        AccountComponent,
        AccountInfoComponent,
    ],
    providers: [],
})
export class AccountModule { }
