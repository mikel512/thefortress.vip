import { Component, Inject, OnInit } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { AuthService } from '@services/auth.service';
import { EventConcertService } from '@services/event-concert.service';
import { SpinnerOverlayService } from '@services/spinner-overlay.service';
import { VenueService } from '@services/venue.service';

@Component({
    selector: 'app-confirmation',
    templateUrl: 'confirmation.component.html'
})

export class ConfirmationComponent implements OnInit {
    public success: boolean = false;
    public loading: boolean = true;

    constructor(private actRouter: ActivatedRoute,
        private _olay: SpinnerOverlayService,
        private router: Router,
        private auth: AuthService) { }

    ngOnInit() {
        const snapshot = this.actRouter.snapshot;
        console.log(snapshot);

        const userId = snapshot.params['userId'];
        const hash = snapshot.params['hash'];

        this.auth.confirmEmail(userId, hash).subscribe({
            next: () => {
                this.success = true;
                this.loading = false;
                setTimeout(() => {
                    this.router.navigate(['/auth/login']);

                }, 10000);
            },
            error: err => {
                this.loading = false;
            }
        });


    }
}