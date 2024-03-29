import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { FormsModule } from '@angular/forms';
import { HttpClientModule, HTTP_INTERCEPTORS } from '@angular/common/http';
import { RouterModule } from '@angular/router';

import { AppComponent } from './app.component';
import { NavMenuComponent } from './component/nav-menu/nav-menu.component';
import { HomeComponent } from './pages/home/home.component';
import { SplashComponent } from './pages/home/splash.component';
import { CitiesMenuComponent } from './pages/home/cities-menu.component';
import { CityComponent } from './pages/home/city.component';
import { FooterComponent } from './component/footer/footer.component';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { SpinnerOverlayComponent } from './component/spinner-overlay/spinner-overlay.component';
import { SpinnerOverlayService } from './services/spinner-overlay.service';
import { LoaderInterceptor } from './util/interceptors/loader.interceptor';
import { OverlayModule } from '@angular/cdk/overlay';
import { AuthButtonComponent } from './component/nav-menu/auth-button.component';
import { AuthService } from './services/auth.service';
import { AuthInterceptor } from './util/interceptors/auth.interceptor';
import { AdminGuard } from './auth/guards/admin.guard';

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
        AuthButtonComponent,
    ],
    imports: [
        OverlayModule,
        // BrowserModule.withServerTransition({ appId: 'ng-cli-universal' }),
        BrowserAnimationsModule,
        HttpClientModule,
        FormsModule,
        RouterModule.forRoot([
            { path: '', component: HomeComponent, pathMatch: 'full' },
            { path: 'admin', loadChildren: () => import('./pages/admin/admin.module').then(m => m.AdminModule), canActivate: [AdminGuard] },
            { path: 'about', loadChildren: () => import('./pages/about/about.module').then(m => m.AboutModule) },
            { path: 'venues', loadChildren: () => import('./pages/venues/venues.module').then(m => m.VenuesModule) },
            { path: ':city', loadChildren: () => import('./pages/events/event.module').then(m => m.EventModule) },
            { path: 'events/:eventId', loadChildren: () => import('./pages/event-detail/event-detail.module').then(m => m.EventDetailModule) },
            // { path: 'loading-animations', loadChildren: () => import('@animations/animations.module').then(m => m.AnimationsModule) },
            { path: 'auth', loadChildren: () => import('./auth/auth.module').then(m => m.AuthModule) },
            { path: '**', component: HomeComponent, pathMatch: 'full' },
        ])
    ],
    providers: [
        AuthService,
        SpinnerOverlayService,
        { provide: HTTP_INTERCEPTORS, useClass: LoaderInterceptor, multi: true },
        { provide: HTTP_INTERCEPTORS, useClass: AuthInterceptor, multi: true },
    ],
    bootstrap: [AppComponent]
})
export class AppModule { }
