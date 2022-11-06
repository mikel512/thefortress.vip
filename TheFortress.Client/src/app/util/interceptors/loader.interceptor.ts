import { Injectable } from '@angular/core';
import {
  HttpRequest,
  HttpHandler,
  HttpEvent,
  HttpInterceptor,
  HttpResponse
} from '@angular/common/http';
import { Observable } from 'rxjs';
import { finalize } from 'rxjs/operators'
import { SpinnerOverlayService } from '../../services/spinner-overlay.service';

@Injectable()
export class LoaderInterceptor implements HttpInterceptor {
  private requests: HttpRequest<any>[] = [];

  constructor(public loaderService: SpinnerOverlayService) { }

  removeRequest(req: HttpRequest<any>) {
    const i = this.requests.indexOf(req);
    if (i >= 0) {
      this.requests.splice(i, 1);
    }
  }

  intercept(request: HttpRequest<any>, next: HttpHandler): Observable<HttpEvent<any>> {
    // const subscription = this.loaderService.spinner$.subscribe();

    this.requests.push(request);
    if (this.requests.length == 1) {
      this.loaderService.show();
    }
    return new Observable(observer => {
      const subscription = next.handle(request)
        .subscribe(
          event => {
            if (event instanceof HttpResponse) {
              this.removeRequest(request);
            }
            observer.next(event);
          },
          err => {
            // this.alertService.setAlert('error', err.message);
            this.removeRequest(request);
            observer.error(err);
            this.loaderService.hide();
          },
          () => {
            this.removeRequest(request);
            observer.complete();
            this.loaderService.hide();
          });
      // remove request from queue when cancelled
      return () => {
        this.removeRequest(request);
        subscription.unsubscribe();
        this.loaderService.hide();

      };
    });
    // return next.handle(request).pipe(request => {
    //   request.pipe((event) => {
    //     if (event instanceof HttpResponse) {
    //       this.removeRequest(request);
    //     }

    //   })
    // }
    //   finalize(() => this.loaderService.hide())
    // );
  }
}
