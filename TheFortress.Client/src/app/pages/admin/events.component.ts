import { Component, Inject, OnInit } from '@angular/core';
import { EventConcert } from '@models/event-concert';
import { EventConcertService } from '@services/event-concert.service';
import { getBaseUrl } from 'src/main';

@Component({
    selector: 'ui-admin-events',
    templateUrl: './events.component.html'
})

export class AdminEventsComponent implements OnInit {
    public events: EventConcert[] = [];

    constructor(private data: EventConcertService) { }

    ngOnInit() {
        this.reload();
    }

    reload() {
        this.data.get(getBaseUrl()).subscribe(
            x => {
                this.events = [];
                this.events = x;
            }
        );
    }

    delete(id:number) {
        this.data.delete(getBaseUrl(),id).subscribe(
            next => {
                this.reload();
            }
        )
    }
}