 import {MatTableModule} from '@angular/material/table'; 
import { CommonModule } from '@angular/common';
import { NgModule } from '@angular/core';
import { RouterModule } from '@angular/router';
import { AdminSidebarComponent } from './admin-sidebar.component';
import { AdminComponent } from './admin.component';
import { AdminEventsComponent } from './events.component';
import { AdminGuard } from 'src/app/auth/guards/admin.guard';


@NgModule({
    declarations: [
        AdminComponent,
        AdminSidebarComponent,
        AdminEventsComponent
    ],
    imports: [
        CommonModule,
        RouterModule.forChild([
            {path: '', component: AdminComponent,
                children: [
                    {path: 'events', component: AdminEventsComponent}
                ]}
        ])
    ],
    exports: [

    ],
    providers: [

    ],
})
export class AdminModule { }
