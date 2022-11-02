import { Component, Inject, OnInit } from '@angular/core';
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


    constructor(private _venues: VenueService,
        private _event: EventConcertService,) { }

    ngOnInit() {
        // this._venues.get()
    }
}