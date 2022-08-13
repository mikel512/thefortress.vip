import { Component, Input, OnInit } from '@angular/core';
import { EventConcert } from '../../../models/event-concert';

@Component({
  selector: 'app-event-mobile',
  templateUrl: './event-mobile.component.html',
  styleUrls: ['./event-mobile.component.css']
})
export class EventMobileComponent implements OnInit {
  @Input() dataMobile!: EventConcert;

  constructor() { }

  ngOnInit(): void {
  }

}
