import { CommonModule } from '@angular/common';
import { NgModule } from '@angular/core';
import { RouterModule } from '@angular/router';
import { FaIconLibrary, FontAwesomeModule } from '@fortawesome/angular-fontawesome';
import { faArrowsRotate } from '@fortawesome/free-solid-svg-icons';
import { AnimationsModule } from 'src/app/util/animations/animations.module';
import { AlertComponent } from './alert.component';
import { MasterPageItemComponent } from './master-page-item.component';
import { AppModalComponent } from './modal.component';
import { SearchBarComponent } from './search-bar.component';


@NgModule({
    declarations: [
        SearchBarComponent,
        MasterPageItemComponent,
        AlertComponent,
        AppModalComponent,
    ],
    imports: [
        CommonModule,
        RouterModule,
        AnimationsModule,
        FontAwesomeModule,
    ],
    exports: [
        SearchBarComponent,
        MasterPageItemComponent,
        AlertComponent,
        AppModalComponent,
        FontAwesomeModule,
    ],
    providers: [],
})
export class SharedModule { 
    constructor(private library: FaIconLibrary) {
        library.addIcons(faArrowsRotate);
    }
}