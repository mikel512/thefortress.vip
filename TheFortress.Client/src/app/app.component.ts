import { Component, Inject } from '@angular/core';
import { tap } from 'rxjs';
import { SpinnerOverlayService } from './services/spinner-overlay.service';


@Component({
    selector: 'app-root',
    templateUrl: './app.component.html',
    styleUrls: ['./app.component.css']
})
export class AppComponent {
    title = 'app';
    isIframe = false;

    constructor(
        private spinner: SpinnerOverlayService) {
    }

    ngOnInit() {
    }
}