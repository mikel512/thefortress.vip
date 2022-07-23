import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { Routes, RouterModule } from '@angular/router';
import { SearchBarComponent } from './search-bar.component';


const routes: Routes = [
  // { path: '', component: SearchBarComponent }
];

@NgModule({
  declarations: [
    SearchBarComponent
  ],
  imports: [
    CommonModule,
    RouterModule.forChild(routes)
  ],
  exports: [
    SearchBarComponent
  ]
})
export class SearchBarModule { }
