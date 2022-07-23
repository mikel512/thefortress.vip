import { AfterViewInit, Component, ElementRef, HostListener, Input, OnInit, ViewChild } from '@angular/core';
import { EventConcert } from '../../../models/event-concert';

@Component({
  selector: 'app-event-item',
  templateUrl: './event-item.component.html',
  styleUrls: ['./event-item.component.css'],
})
export class EventItemComponent implements OnInit, AfterViewInit {
  @Input() event!: EventConcert;
  isInVenueDetail: boolean = true;
  imageLoader: boolean = true;

  constructor() { }

  ngOnInit(): void {
  }

  ngAfterViewInit() {
  }


}
