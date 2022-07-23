import { Injectable } from '@angular/core';
import {
  HttpRequest,
  HttpHandler,
  HttpEvent,
  HttpInterceptor
} from '@angular/common/http';
import { Observable } from 'rxjs';
import { finalize } from 'rxjs/operators'
import { SpinnerOverlayService } from '../services/spinner-overlay.service';

@Injectable()
export class LoaderInterceptor implements HttpInterceptor {

  constructor(public loaderService: SpinnerOverlayService) {}

  intercept(request: HttpRequest<any>, next: HttpHandler): Observable<HttpEvent<any>> {
    // const subscription = this.loaderService.spinner$.subscribe();
    this.loaderService.show();
    return next.handle(request).pipe(
      finalize(() => this.loaderService.hide())
    );
  }
}
