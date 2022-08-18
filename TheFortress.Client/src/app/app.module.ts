import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { FormsModule } from '@angular/forms';
import { HttpClientModule, HTTP_INTERCEPTORS } from '@angular/common/http';
import { RouterModule } from '@angular/router';

import { AppComponent } from './app.component';
import { NavMenuComponent } from './component/nav-menu/nav-menu.component';
import { HomeComponent } from './pages/home/home.component';
import { SplashComponent } from './pages/home/splash/splash.component';
import { CitiesMenuComponent } from './pages/home/cities-menu/cities-menu.component';
import { CityComponent } from './pages/home/cities-menu/city/city.component';
import { FooterComponent } from './component/footer/footer.component';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { SpinnerOverlayComponent } from './component/spinner-overlay/spinner-overlay.component';
import { SpinnerOverlayService } from './services/spinner-overlay.service';
import { LoaderInterceptor } from './interceptors/loader.interceptor';
import { OverlayModule } from '@angular/cdk/overlay';


@NgModule({
  declarations: [
    AppComponent,
    NavMenuComponent,
    HomeComponent,
    SplashComponent,
    CitiesMenuComponent,
    CityComponent,
    FooterComponent,
    SpinnerOverlayComponent,
  ],
  imports: [
    OverlayModule,
    BrowserModule.withServerTransition({ appId: 'ng-cli-universal' }),
    BrowserAnimationsModule,
    HttpClientModule,
    FormsModule,
    RouterModule.forRoot([
      {
        path: '',
        component: HomeComponent,
        pathMatch: 'full'
      },
      { path: 'about', loadChildren: () => import('./pages/about/about.module').then(m => m.AboutModule) },
      { path: 'venues', loadChildren: () => import('./pages/venues/venues.module').then(m => m.VenuesModule) },
      { path: ':city', loadChildren: () => import('./pages/events/event.module').then(m => m.EventModule) },
      { path: 'events/:eventId', loadChildren: () => import('./pages/event-detail/event-detail.module').then(m => m.EventDetailModule) },
      { path: 'loading-animations', loadChildren: () => import('./loading-animations/loading-animations.module').then(m => m.LoadingAnimationsModule) },
    ])
  ],
  providers: [
    SpinnerOverlayService,
    { provide: HTTP_INTERCEPTORS, useClass: LoaderInterceptor, multi: true },
  ],
  bootstrap: [AppComponent]
})
export class AppModule { }
