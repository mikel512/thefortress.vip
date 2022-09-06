import { animate, keyframes, state, style, transition, trigger } from '@angular/animations';
import { HttpClient } from '@angular/common/http';
import { Component, Inject, OnInit } from '@angular/core';
import { ActivatedRoute, ActivatedRouteSnapshot, Router } from '@angular/router';
import { EventConcertService } from '@services/event-concert.service';
import { EventConcert } from '@models/event-concert';

@Component({
  selector: 'app-event-page',
  templateUrl: './event-page.component.html',
  styleUrls: ['./event-page.component.css'],
  animations: [
    trigger('flyInOut', [
      state('in', style({ transform: 'translateX(0)' })),
      transition('void => *', [
        animate(50, keyframes([
          style({ opacity: 0, transform: 'translateX(-100%)', offset: 0 }),
          style({ opacity: 1, transform: 'translateX(15px)', offset: 0.3 }),
          style({ opacity: 1, transform: 'translateX(0)', offset: 1.0 })
        ]))
      ]),
    ])
  ]
})
export class EventPageComponent implements OnInit {
  private next: number = 0;
  private route: ActivatedRouteSnapshot;

  public events: EventConcert[] = [];
  public currentCity: string = '';

  public staggeringEvents: EventConcert[] = [];

  constructor(private actRouter: ActivatedRoute,
    private router: Router,
    private data: EventConcertService,
    @Inject('BASE_URL') baseUrl: string) {

    this.route = actRouter.snapshot;
    this.currentCity = this.route.params['city'];
    console.log(this.currentCity);

    if (this.currentCity === 'All') {
      data.get(baseUrl).subscribe(
        x => {
          this.events = x;
          this.doNext();
        }, 
        error => console.error(error)
      );

    } else {
      data.getByCity(baseUrl, this.currentCity).subscribe(
        x => {
          this.events = x;
          this.doNext();
        }, 
        error => console.error(error)
      );
    }

  }

  ngOnInit(): void {
  }

  doNext() {
    if (this.next < this.events.length) {
      this.staggeringEvents.push(this.events[this.next++]);
    }
  }

}
