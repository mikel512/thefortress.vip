import { CommonModule } from '@angular/common';
import { NgModule } from '@angular/core';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { MyDirectivesModule } from '@directives/my-directives.module';
import { SharedModule } from '../../pages/shared/shared.module';
import { EventConcertFormComponent } from './event-concert-form.component';
import { FileUploadComponent } from './file-upload.component';


@NgModule({
    declarations: [
        EventConcertFormComponent,
        FileUploadComponent,
    ],
    imports: [
        ReactiveFormsModule, 
        FormsModule, 
        MyDirectivesModule,
        SharedModule,
        CommonModule,
    ],
    exports: [
        EventConcertFormComponent,
    ],
    providers: [],
})
export class AppFormsModule { }
