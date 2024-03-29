import { Component, Input, OnInit } from '@angular/core';
import { City } from '../../models/city';

@Component({
  selector: 'app-city',
  templateUrl: './city.component.html',
  styleUrls: ['./city.component.css']
})
export class CityComponent implements OnInit {
  @Input() cityObj!: HomePageCityLink;

  constructor() { }

  ngOnInit(): void {
  }

}

export class HomePageCityLink {
  name?: string;
  routerLink?: string;
  imgUrl?: string;

}
