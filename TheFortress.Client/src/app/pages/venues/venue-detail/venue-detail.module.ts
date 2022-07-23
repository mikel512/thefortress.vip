import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { Routes, RouterModule } from '@angular/router';
import { VenueDetailComponent } from './venue-detail.component';
import { EventItemModule } from '../../events/event-item/event-item.module';


const routes: Routes = [
  { path: '', component: VenueDetailComponent }
];

@NgModule({
  declarations: [VenueDetailComponent],
  imports: [
    CommonModule,
    RouterModule.forChild(routes),
    EventItemModule
  ]
})
export class VenueDetailModule { }
