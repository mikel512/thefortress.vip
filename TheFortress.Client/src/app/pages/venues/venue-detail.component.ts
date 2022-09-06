import { HttpClient } from '@angular/common/http';
import { Component, ElementRef, Inject, OnInit, ViewChild } from '@angular/core';
import { ActivatedRoute, ActivatedRouteSnapshot, Router } from '@angular/router';
import { animate, style, transition, trigger } from '@angular/animations';
import { Venue } from '@models/venue';
import { EventConcert } from '@models/event-concert';
import { SpinnerOverlayService } from '@services/spinner-overlay.service';
import { VenueService } from '@services/venue.service';
import { EventConcertService } from '@services/event-concert.service';

@Component({
  selector: 'app-venue-detail',
  templateUrl: './venue-detail.component.html',
  styleUrls: ['./venue-detail.component.css'],
  animations: [
    trigger('fadeIn', [
      transition(':enter', [
        style({ opacity: '0' }),
        animate('.5s ease-out', style({ opacity: '1' })),
      ]),
    ]),
  ]
})
export class VenueDetailComponent implements OnInit {
  onTabChange: boolean = true;
  private route: ActivatedRouteSnapshot;
  private venueId: number = 0;
  venue!: Venue;
  concerts: EventConcert[] = [];

  constructor(private actRouter: ActivatedRoute,
    private overlay: SpinnerOverlayService,
    private router: Router,
    private _venue: VenueService,
    private _event: EventConcertService,
    @Inject('BASE_URL') baseUrl: string) {

    this.route = actRouter.snapshot;
    this.venueId = this.route.params['venueId'];
    console.log(this.venueId);

    let venue$ = _venue.getById(baseUrl, this.venueId);
    let events$ = _event.getByVenue(baseUrl, this.venueId);

    venue$.subscribe(x => {
      this.venue = x;
    }, error => console.log('error'));
    overlay.hide();
    events$.subscribe(x =>{
      this.concerts = x;
    }, error => console.log(error));
  }

  ngOnInit(): void {
  }

  toggleTab() {
    this.onTabChange = !this.onTabChange;
  }

}
