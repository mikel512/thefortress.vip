import { CommonModule } from '@angular/common';
import { NgModule } from '@angular/core';
import { RouterModule } from '@angular/router';
import { AdminComponent } from './admin.component';


@NgModule({
    declarations: [
        AdminComponent
    ],
    imports: [
        CommonModule,
        RouterModule.forChild([
            {path: '', component: AdminComponent, canActivate: []}
        ])
    ],
    exports: [

    ],
    providers: [

    ],
})
export class AdminModule { }
