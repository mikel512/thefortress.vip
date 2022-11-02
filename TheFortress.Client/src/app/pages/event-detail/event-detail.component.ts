import { HttpClient } from '@angular/common/http';
import { AfterViewChecked, Component, Inject, OnInit } from '@angular/core';
import { ActivatedRoute, ActivatedRouteSnapshot, Router } from '@angular/router';
import { EventConcertService } from '@services/event-concert.service';
import { VenueService } from '@services/venue.service';
import { EventConcert } from '@models/event-concert';

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
    ) {

    this.route = actRouter.snapshot;
    this.eventId = this.route.params['eventId'];
    console.log(this.eventId);

    _event.getById(this.eventId).subscribe(
      x => {
        this.event = x;
      }, error => console.error(error))
  }

  ngOnInit(): void {
  }

  ngAfterViewChecked() {
  }

}
