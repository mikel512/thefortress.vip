import { Component, Inject, OnInit } from '@angular/core';
import { AlertModel } from '@models/alert-model';
import { EventConcert } from '@models/event-concert';
import { Venue } from '@models/venue';
import { EventConcertService } from '@services/event-concert.service';
import { VenueService } from '@services/venue.service';

@Component({
    selector: 'app-add-event',
    templateUrl: 'add-event.component.html'
})

export class AddEventComponent implements OnInit {
    public event: EventConcert;
    public venues: Venue[] = [];
    public venueFK: number;
    public alert = new AlertModel();


    constructor(private _venues: VenueService,
        private _event: EventConcertService,) { }

    ngOnInit() {
        this._venues.get().subscribe({
            next: (items) => {
                this.venues = items;
            }
        })
    }

    postNewEvent(event: EventConcert) {
        if(!this.venueFK) return;

        event.venueFk = this.venueFK;
        this._event.post(event).subscribe({
            next: (val) => {

            }
        })
    }
}