import { DirectiveResolver } from '@angular/compiler';
import { NgModule } from '@angular/core';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { MyDirectivesModule } from '@directives/my-directives.module';
import { SharedModule } from '../pages/shared/shared.module';
import { EventConcertFormComponent } from './event-concert-form.component';


@NgModule({
    declarations: [
        EventConcertFormComponent,
    ],
    imports: [
        ReactiveFormsModule, 
        FormsModule, 
        MyDirectivesModule,
        SharedModule,
    ],
    exports: [
        EventConcertFormComponent,
    ],
    providers: [],
})
export class AppFormsModule { }
