import { CommonModule } from '@angular/common';
import { NgModule } from '@angular/core';
import { RouterModule } from '@angular/router';
import { LoadingAnimationsModule } from 'src/app/loading-animations/loading-animations.module';
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
        LoadingAnimationsModule,
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