import { CommonModule } from '@angular/common';
import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { SharedModule } from '../shared/shared.module';
import { EventPageComponent } from './event-page.component';

const routes: Routes = [
    { path: '', component: EventPageComponent },
];

@NgModule({
    declarations: [
        EventPageComponent,
    ],
    imports: [
        CommonModule,
        RouterModule.forChild(routes),
        SharedModule,
    ],
    exports: [],
    providers: [],
})
export class EventModule { }
