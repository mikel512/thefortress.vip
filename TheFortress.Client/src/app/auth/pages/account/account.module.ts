import { CommonModule } from '@angular/common';
import { NgModule } from '@angular/core';
import { Router, RouterModule } from '@angular/router';
import { AccountInfoComponent } from './account-info.component';
import { AccountComponent } from './account.component';


@NgModule({
    imports: [
        CommonModule,
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
