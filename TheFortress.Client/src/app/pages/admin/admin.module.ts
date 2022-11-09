import { CommonModule } from '@angular/common';
import { NgModule } from '@angular/core';
import { RouterModule } from '@angular/router';
import { AdminSidebarComponent } from './admin-sidebar.component';
import { AdminComponent } from './admin.component';
import { AdminEventsComponent } from './events.component';
import { AdminGuard } from 'src/app/auth/guards/admin.guard';
import { AddEventComponent } from './add-event.component';
import { AppFormsModule } from 'src/app/component/forms/forms.module';
import { NgSelectModule } from '@ng-select/ng-select';
import { FormsModule } from '@angular/forms';
import { SharedModule } from '../shared/shared.module';
import { AppPipesModule } from 'src/app/util/pipes/app-pipes.module';
import { FontAwesomeModule } from '@fortawesome/angular-fontawesome';
import { VenuesListComponent } from './venues-list.component';


@NgModule({
    declarations: [
        AdminComponent,
        AdminSidebarComponent,
        AdminEventsComponent,
        AddEventComponent,
        VenuesListComponent,
    ],
    imports: [
        AppPipesModule,
        FormsModule,
        CommonModule,
        AppFormsModule,
        NgSelectModule,
        SharedModule,
        RouterModule.forChild([
            {path: '', component: AdminComponent,
                children: [
                    {path: 'events', component: AdminEventsComponent},
                    {path: 'add-event', component: AddEventComponent},
                    {path: 'venues', component: VenuesListComponent},
                ]}
        ])
    ],
    exports: [

    ],
    providers: [

    ],
})
export class AdminModule { }
