import { Component, OnInit } from '@angular/core';
import { City } from '../../models/city';
import { HomePageCityLink } from './city.component';

@Component({
  selector: 'app-cities-menu',
  templateUrl: './cities-menu.component.html',
  styleUrls: ['./cities-menu.component.css']
})
export class CitiesMenuComponent implements OnInit {
  cities: HomePageCityLink[] = [];

  constructor() {
    this.cities = [
      {
        imgUrl: "../../../../assets/arcata-1.jpg",
        name: 'Arcata',
        routerLink: 'Arcata'
      },
      {
        imgUrl: "../../../../assets/eureka-1.jpg",
        name: 'Eureka',
        routerLink: 'Eureka'
      },
      {
        imgUrl: "../../../../assets/humbay.jpg",
        name: 'All',
        routerLink: 'All'
      },

    ]
  }

  ngOnInit(): void {
  }

}

