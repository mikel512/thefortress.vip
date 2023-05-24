import { Component, Inject, Input, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { City } from 'src/app/models/city';
import { CityService } from 'src/app/services/city.service';
import { getBaseUrl } from 'src/main';

@Component({
  selector: 'app-search-bar',
  templateUrl: './search-bar.component.html',
  styleUrls: ['./search-bar.component.css'],
  providers: [CityService]
})
export class SearchBarComponent implements OnInit {
  @Input() chosenCity: string = '';
  @Input() isEvent: boolean = true;
  public cities: City[] = [];

  constructor(private router: Router,
    private _cities: CityService,
    ) {

    _cities.get().subscribe(
      items => {
        let all: City = {cityName: 'All', cityId: 0, image: '', venues: []};
        items.push(all);
        this.cities = items.filter(e => e.cityName !== this.chosenCity)
      }
    )

  }


  ngOnInit(): void {
  }

  eventsNav() {
    this.router.navigate([this.chosenCity]);
    this.isEvent = true;
  }

  venuesNav() {
    this.router.navigate([`venues/${this.chosenCity}`]);
    this.isEvent = false;
  }

  navigateTo(e: Event) {
    let value = (<HTMLSelectElement>e.target).value;
    if (this.isEvent) {
      if (value) {
        this.router.navigateByUrl('/', { skipLocationChange: true }).then(() =>
          this.router.navigate([value]));
      }
    } else {
      if (value) {
        this.router.navigateByUrl('/', { skipLocationChange: true }).then(() =>
          this.router.navigate([`venues/${value}`]));
      }

    }
  }

}
