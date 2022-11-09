import { Component, OnInit } from '@angular/core';
import { Venue } from '@models/venue';
import { VenueService } from '@services/venue.service';

@Component({
    selector: 'app-venues-list',
    templateUrl: 'venues-list.component.html'
})

export class VenuesListComponent implements OnInit {
    public venues: Venue[] = [];

    constructor(private venueData: VenueService) { }

    ngOnInit() { 
        this.venueData.get().subscribe({
            next: x => {
                this.venues = x;
            }
        })
    }
}