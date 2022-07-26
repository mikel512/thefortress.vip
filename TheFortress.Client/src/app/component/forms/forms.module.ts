import { CommonModule } from '@angular/common';
import { NgModule } from '@angular/core';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { MyDirectivesModule } from 'src/app/util/directives/my-directives.module';
import { SharedModule } from '../../pages/shared/shared.module';
import { CityFormModelFormComponent } from './city-form-model-form.component';
import { EventConcertFormModelFormComponent } from './event-concert-form-model-form.component';
import { FileUploadComponent } from './file-upload.component';
import { VenueFormModelFormComponent } from './venue-form-model-form.component';


@NgModule({
    declarations: [
        FileUploadComponent,
        EventConcertFormModelFormComponent,
        VenueFormModelFormComponent,
        CityFormModelFormComponent,
    ],
    imports: [
        ReactiveFormsModule, 
        FormsModule, 
        MyDirectivesModule,
        SharedModule,
        CommonModule,
    ],
    exports: [
        EventConcertFormModelFormComponent,
        VenueFormModelFormComponent,
        CityFormModelFormComponent,
    ],
    providers: [],
})
export class AppFormsModule { }
