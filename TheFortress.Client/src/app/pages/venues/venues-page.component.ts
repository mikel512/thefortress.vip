import { HttpClient } from '@angular/common/http';
import { AfterViewChecked, Component, Inject, OnInit } from '@angular/core';
import { ActivatedRoute, ActivatedRouteSnapshot, Router } from '@angular/router';
import { VenueService } from '@services/venue.service';
import { Venue } from '@models/venue';

@Component({
    selector: 'app-venues-page',
    templateUrl: './venues-page.component.html',
    styleUrls: ['./venues-page.component.css']
})
export class VenuesPageComponent implements OnInit {
    venues: Venue[] = [];
    private route: ActivatedRouteSnapshot;
    currentCity: string = '';

    constructor(private actRouter: ActivatedRoute,
        private data: VenueService,
        @Inject('BASE_URL') baseUrl: string) {

        this.route = actRouter.snapshot;
        this.currentCity = this.route.params['city'];

        let observable;
        if (this.currentCity === 'All') {
            observable = data.get(baseUrl);
        }
        else {
            observable = data.getByCity(baseUrl, this.currentCity);
        }
        observable.subscribe({
            next: (x) => {
                this.venues = x;
            },
            error: (error) => console.error(error)
        })
    }


    ngOnInit(): void {
    }

    reload() {

    }
}
