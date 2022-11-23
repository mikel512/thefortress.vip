import { CommonModule } from '@angular/common';
import { NgModule } from '@angular/core';
import { RouterModule } from '@angular/router';
import { AdminSidebarComponent } from './admin-sidebar.component';
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
import { AddVenueComponent } from './add-venue.component';
import { CitiesListComponent } from './cities-list.component';
import { AdminLayoutComponent } from './admin-layout.component';


@NgModule({
    declarations: [
        AdminSidebarComponent,
        AdminEventsComponent,
        AddEventComponent,
        VenuesListComponent,
        AddVenueComponent,
        CitiesListComponent,
        AdminLayoutComponent,
    ],
    imports: [
        AppPipesModule,
        FormsModule,
        CommonModule,
        AppFormsModule,
        NgSelectModule,
        SharedModule,
        RouterModule.forChild([
            {
                path: '', component: AdminLayoutComponent,
                children: [
                    { path: 'events', component: AdminEventsComponent },
                    { path: 'add-event', component: AddEventComponent },
                    { path: 'venues', component: VenuesListComponent },
                    { path: 'add-venue', component: AddVenueComponent },
                    { path: 'cities', component: CitiesListComponent },
                ]
            }
        ])
    ],
    exports: [

    ],
    providers: [

    ],
})
export class AdminModule { }
