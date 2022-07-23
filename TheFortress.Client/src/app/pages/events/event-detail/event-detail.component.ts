import { HttpClient } from '@angular/common/http';
import { AfterViewChecked, Component, Inject, OnInit } from '@angular/core';
import { ActivatedRoute, ActivatedRouteSnapshot, Router } from '@angular/router';
import { EventConcertService } from 'src/app/services/event-concert.service';
import { VenueService } from 'src/app/services/venue.service';
import { EventConcert } from '../../../models/event-concert';

@Component({
  selector: 'app-event-detail',
  templateUrl: './event-detail.component.html',
  styleUrls: ['./event-detail.component.css']
})
export class EventDetailComponent implements OnInit, AfterViewChecked {
  private route?: ActivatedRouteSnapshot;
  private eventId: number = 0;
  event!: EventConcert;

  constructor(private actRouter: ActivatedRoute,
    private router: Router,
    private _event: EventConcertService,
    private _venue: VenueService,
    http: HttpClient, @Inject('BASE_URL') baseUrl: string) {

    this.route = actRouter.snapshot;
    this.eventId = this.route.params['eventId'];

    _event.getById(baseUrl, this.eventId).subscribe(
      x => {
        this.event = x;
      }, error => console.error(error))
    // http.get<EventConcert>(apiUrl + 'concert/' + this.eventId).subscribe(result => {
    //   this.event = result;
    // }, error => console.error(error))
  }

  ngOnInit(): void {
  }

  ngAfterViewChecked() {
  }

}
