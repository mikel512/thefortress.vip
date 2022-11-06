import { CommonModule } from '@angular/common';
import { NgModule } from '@angular/core';
import { RouterModule } from '@angular/router';
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
        AnimationsModule
    ],
    exports: [
        SearchBarComponent,
        MasterPageItemComponent,
        AlertComponent,
        AppModalComponent,
    ],
    providers: [],
})
export class SharedModule { }