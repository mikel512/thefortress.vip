import { Component, OnInit } from '@angular/core';
import { City } from '../../../models/city';

@Component({
  selector: 'app-cities-menu',
  templateUrl: './cities-menu.component.html',
  styleUrls: ['./cities-menu.component.css']
})
export class CitiesMenuComponent implements OnInit {
  cities : City[] = [];

  constructor() { 
  }

  ngOnInit(): void {
    let obj1: City = {
      cityId: 0,
      image: "../../../../assets/arcata-1.jpg",
      cityName: 'Arcata',
      venues: null
    }
    let obj2: City = {
      cityId: 1,
      image: "../../../../assets/eureka-1.jpg",
      cityName: 'Eureka',
      venues: null
    }
    this.cities.push(obj1);
    this.cities.push(obj2);
  }

}
