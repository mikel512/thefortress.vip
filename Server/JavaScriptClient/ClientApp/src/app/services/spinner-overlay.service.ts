import { Overlay, OverlayRef } from '@angular/cdk/overlay'
import { ComponentPortal } from '@angular/cdk/portal'
import { Injectable } from '@angular/core';
import { NEVER } from 'rxjs';
import { defer, Subject } from 'rxjs';
import { finalize, share } from 'rxjs/operators';
import { SpinnerOverlayComponent } from '../component/spinner-overlay/spinner-overlay.component'

@Injectable({
  providedIn: 'root'
})
export class SpinnerOverlayService {
  private overlayRef?: OverlayRef;

  constructor(private overlay: Overlay) { }

  public show() {
    if (!this.overlayRef) {
      this.overlayRef = this.overlay.create();
    }

    // Create ComponentPortal that can be attached to a PortalHost
    const spinnerOverlayPortal = new ComponentPortal(SpinnerOverlayComponent);
    const component = this.overlayRef.attach(spinnerOverlayPortal); // Attach ComponentPortal to PortalHost
  }

  public readonly spinner$ = defer(() => {
    this.show();
    return NEVER.pipe(
      finalize(() => {
        this.hide();
      })
    );
  }).pipe(share());

  public hide() {
    if (!!this.overlayRef) {
      this.overlayRef.detach();
    }
  }
}
