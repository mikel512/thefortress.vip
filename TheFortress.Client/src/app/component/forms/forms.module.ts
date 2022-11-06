import { CommonModule } from '@angular/common';
import { NgModule } from '@angular/core';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { MyDirectivesModule } from 'src/app/util/directives/my-directives.module';
import { SharedModule } from '../../pages/shared/shared.module';
import { EventConcertFormModelFormComponent } from './event-concert-form-model-form.component';
import { FileUploadComponent } from './file-upload.component';


@NgModule({
    declarations: [
        FileUploadComponent,
        EventConcertFormModelFormComponent
    ],
    imports: [
        ReactiveFormsModule, 
        FormsModule, 
        MyDirectivesModule,
        SharedModule,
        CommonModule,
    ],
    exports: [
        EventConcertFormModelFormComponent
    ],
    providers: [],
})
export class AppFormsModule { }
