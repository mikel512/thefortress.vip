import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { EventItemComponent } from './event-item.component';
import { RouterModule } from '@angular/router';
import { LoadingAnimationsModule } from '../../../loading-animations/loading-animations.module';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';


@NgModule({
  declarations: [EventItemComponent],
  imports: [
    CommonModule,
    RouterModule,
    LoadingAnimationsModule,
  ],
  exports: [EventItemComponent]
})
export class EventItemModule { }