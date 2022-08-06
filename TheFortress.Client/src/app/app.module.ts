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
import { JwtModule } from '@auth0/angular-jwt';
import { MsalBroadcastService, MsalCustomNavigationClient, MsalGuard, MsalGuardConfiguration, MsalInterceptor, MsalModule, MsalRedirectComponent, MsalService, MSAL_GUARD_CONFIG, MSAL_INSTANCE } from '@azure/msal-angular';
import { InteractionType, IPublicClientApplication, PublicClientApplication } from '@azure/msal-browser';
import { environment } from 'src/environments/environment';
import { MsalConfig, protectedResources } from './auth-config.component';

export function MSALInstanceFactory(): IPublicClientApplication {
  return new PublicClientApplication(MsalConfig);
}

export function MSALGuardConfigFactory(): MsalGuardConfiguration {
  return {
    interactionType: InteractionType.Redirect,
  };
}


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
    MsalModule.forRoot(new PublicClientApplication(MsalConfig),
      {
        // The routing guard configuration. 
        interactionType: InteractionType.Redirect,
        authRequest: {
          // scopes: protectedResources.todoListApi.scopes
        }
      },
      {
        // MSAL interceptor configuration.
        // The protected resource mapping maps your web API with the corresponding app scopes. If your code needs to call another web API, add the URI mapping here.
        interactionType: InteractionType.Redirect,
        protectedResourceMap: new Map([
          // [protectedResources.todoListApi.endpoint, protectedResources.todoListApi.scopes]
        ])
      }),
    RouterModule.forRoot([
      {
        path: '',
        component: HomeComponent,
        pathMatch: 'full'
      },
      { path: 'about', loadChildren: () => import('./pages/about/about.module').then(m => m.AboutModule) },
      { path: 'venues/:city', loadChildren: () => import('./pages/venues/venues-page/venues-page.module').then(m => m.VenuesPageModule) },
      { path: ':city', loadChildren: () => import('./pages/events/event-page/event-page.module').then(m => m.EventPageModule) },
      { path: 'events/:eventId', loadChildren: () => import('./pages/events/event-detail/event-detail.module').then(m => m.EventDetailModule) },
      { path: 'venue/:venueId', loadChildren: () => import('./pages/venues/venue-detail/venue-detail.module').then(m => m.VenueDetailModule) },
      { path: 'loading-animations', loadChildren: () => import('./loading-animations/loading-animations.module').then(m => m.LoadingAnimationsModule) },
    ])
  ],
  providers: [
    {
      provide: MSAL_INSTANCE,
      useFactory: MSALInstanceFactory,
    },
    {
      provide: MSAL_GUARD_CONFIG,
      useFactory: MSALGuardConfigFactory,
    },
    MsalService,
    MsalGuard,
    MsalBroadcastService,
    SpinnerOverlayService,
    { provide: HTTP_INTERCEPTORS, useClass: LoaderInterceptor, multi: true },
    { provide: HTTP_INTERCEPTORS, useClass: MsalInterceptor, multi: true },
  ],
  bootstrap: [AppComponent, MsalRedirectComponent]
})
export class AppModule { }
