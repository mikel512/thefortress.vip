import { CommonModule } from '@angular/common';
import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { AnimationsModule } from '@animations/animations.module';
import { SharedModule } from '../shared/shared.module';
import { VenueDetailComponent } from './venue-detail.component';
import { VenueItemComponent } from './venue-item.component';
import { VenuesPageComponent } from './venues-page.component';

const routes: Routes = [
    {
        path: ':city',
        component: VenuesPageComponent,
    },
    {
        path: 'detail/:venueId',
        component: VenueDetailComponent
    },
];

@NgModule({
    declarations: [
        VenuesPageComponent,
        VenueItemComponent,
        VenueDetailComponent,
    ],
    providers: [],
    imports: [
        CommonModule,
        RouterModule.forChild(routes),
        AnimationsModule,
        SharedModule
    ],
    exports: [],
})
export class VenuesModule { }
