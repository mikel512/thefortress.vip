import { HttpClient } from '@angular/common/http';
import { AfterViewChecked, Component, Inject, OnInit } from '@angular/core';
import { ActivatedRoute, ActivatedRouteSnapshot, Router } from '@angular/router';
import { VenueService } from 'src/app/services/venue.service';
import { Venue } from '../../../models/venue';

@Component({
  selector: 'app-venues-page',
  templateUrl: './venues-page.component.html',
  styleUrls: ['./venues-page.component.css']
})
export class VenuesPageComponent implements OnInit {
  venues: Venue[] = [];
  private route: ActivatedRouteSnapshot;
  currentCity: string = '';

  constructor(private actRouter: ActivatedRoute,
    private data: VenueService,
    @Inject('BASE_URL') baseUrl: string) {

    this.route = actRouter.snapshot;
    this.currentCity = this.route.params['city'];

    if (this.currentCity === 'All') {
      data.get(baseUrl).subscribe(
        x => {
          this.venues = x;
        }, error => console.error(error));
    }
    else {
      data.getByCity(baseUrl, this.currentCity).subscribe(
        x => {
          this.venues = x;
        }, error => console.error(error));

    }
  }


  ngOnInit(): void {
  }

  reload() {

  }
}
