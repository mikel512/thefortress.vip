import { Component, Input, OnInit } from '@angular/core';
import { Venue } from '../../../models/venue';

@Component({
  selector: 'app-venue-item',
  templateUrl: './venue-item.component.html',
  styleUrls: ['./venue-item.component.css']
})
export class VenueItemComponent implements OnInit {
  @Input() venue!: Venue;
  imageLoader: boolean = true;

  constructor() { 
  }

  ngOnInit(): void {
  }

}
