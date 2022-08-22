import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { Routes, RouterModule } from '@angular/router';
import { EventDetailComponent } from './event-detail.component';
import { EventMobileComponent } from './event-mobile/event-mobile.component';
import { EventDesktopComponent } from './event-desktop/event-desktop.component';
import { SharedModule } from '../shared/shared.module';


const routes: Routes = [
  { path: '', component: EventDetailComponent }
];

@NgModule({
  declarations: [
    EventDetailComponent, 
    EventMobileComponent, 
    EventDesktopComponent
  ],
  imports: [
    CommonModule,
    RouterModule.forChild(routes),
    SharedModule,
  ]
})
export class EventDetailModule { }
