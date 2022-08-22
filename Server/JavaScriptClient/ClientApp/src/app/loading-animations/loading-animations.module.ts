import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { Routes, RouterModule } from '@angular/router';
import { AnimationOneComponent } from './animation1/animation-one.component';


const routes: Routes = [
  // { path: '', component: LoadingAnimationsComponent }
];

@NgModule({
  declarations: [AnimationOneComponent],
  imports: [
    CommonModule,
    RouterModule.forChild(routes)
  ],
  exports: [
    AnimationOneComponent
  ]
})
export class LoadingAnimationsModule { }
