import { Component, OnInit } from '@angular/core';
import { EventConcert } from '@models/event-concert';

@Component({
    selector: 'app-add-event',
    templateUrl: 'add-event.component.html'
})

export class AddEventComponent implements OnInit {
    public event: EventConcert;


    constructor() { }

    ngOnInit() { }
}