import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { Routes, RouterModule } from '@angular/router';
import { AboutComponent } from './about.component';
import { SplashComponent } from './splash/splash.component';
import { ContactComponent } from './contact/contact.component';
import { ClipboardModule } from '@angular/cdk/clipboard';


const routes: Routes = [
  { path: '', component: AboutComponent }
];

@NgModule({
  declarations: [
    AboutComponent,
    SplashComponent,
    ContactComponent,
  ],
  imports: [
    CommonModule,
    ClipboardModule,
    RouterModule.forChild(routes)
  ]
})
export class AboutModule { }
