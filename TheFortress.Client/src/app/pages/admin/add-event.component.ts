import { TemplateBindingParseResult } from '@angular/compiler';
import { Component, Inject, OnInit, TemplateRef, ViewChild } from '@angular/core';
import { AlertModel } from '@models/alert-model';
import { EventConcert } from '@models/event-concert';
import { Venue } from '@models/venue';
import { EventConcertService } from '@services/event-concert.service';
import { VenueService } from '@services/venue.service';
import { AppModalComponent } from '../shared/modal.component';

@Component({
    selector: 'app-add-event',
    templateUrl: 'add-event.component.html'
})

export class AddEventComponent implements OnInit {
    public event: EventConcert;
    public venues: Venue[] = [];
    public venueFK: number;
    public alert = new AlertModel();

    @ViewChild('previewModal') preview: AppModalComponent;

    constructor(private _venues: VenueService,
        private _event: EventConcertService,) { }

    ngOnInit() {
        this._venues.get().subscribe({
            next: (items) => {
                this.venues = items;
            }
        })
    }

    showPreviewModal(event: EventConcert) {
        this.event = event;
        event.venueFk = this.venueFK;
        this.preview.show();
    }

    closeModal(){
        this.preview.hide();
    }

    postNewEvent() {
        if(!this.venueFK) return;

        this._event.post(this.event).subscribe({
            next: (val) => {
                this.preview.hide();

            }
        })
    }
}