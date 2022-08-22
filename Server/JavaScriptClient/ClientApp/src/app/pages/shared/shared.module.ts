import { CommonModule } from '@angular/common';
import { NgModule } from '@angular/core';
import { RouterModule } from '@angular/router';
import { LoadingAnimationsModule } from 'src/app/loading-animations/loading-animations.module';
import { MasterPageItemComponent } from './master-page-item.component';
import { SearchBarComponent } from './search-bar.component';


@NgModule({
    declarations: [
        SearchBarComponent,
        MasterPageItemComponent,
    ],
    imports: [
        CommonModule,
        RouterModule,
        LoadingAnimationsModule,
    ],
    exports: [
        SearchBarComponent,
        MasterPageItemComponent,
    ],
    providers: [],
})
export class SharedModule { }