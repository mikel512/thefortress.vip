import { CommonModule } from '@angular/common';
import { NgModule } from '@angular/core';
import { RouterModule } from '@angular/router';
import { AdminSidebarComponent } from './admin-sidebar.component';
import { AdminComponent } from './admin.component';
import { AdminEventsComponent } from './events.component';
import { AdminGuard } from 'src/app/auth/guards/admin.guard';
import { AddEventComponent } from './add-event.component';
import { AppFormsModule } from '@forms/forms.module';
import { NgSelectModule } from '@ng-select/ng-select';


@NgModule({
    declarations: [
        AdminComponent,
        AdminSidebarComponent,
        AdminEventsComponent,
        AddEventComponent,
    ],
    imports: [
        CommonModule,
        AppFormsModule,
        NgSelectModule,
        RouterModule.forChild([
            {path: '', component: AdminComponent,
                children: [
                    {path: 'events', component: AdminEventsComponent},
                    {path: 'add-event', component: AddEventComponent}
                ]}
        ])
    ],
    exports: [

    ],
    providers: [

    ],
})
export class AdminModule { }
