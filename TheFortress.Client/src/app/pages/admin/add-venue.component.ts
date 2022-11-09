import { Component, OnInit } from '@angular/core';
import { NumberValueAccessor } from '@angular/forms';
import { AlertModel } from '@models/alert-model';
import { City } from '@models/city';
import { VenueFormModel } from '@models/venue-form-model';
import { CityService } from '@services/city.service';
import { CustomService } from '@services/custom.service';
import { VenueService } from '@services/venue.service';

@Component({
    selector: 'app-add-venue',
    templateUrl: 'add-venue.component.html'
})

export class AddVenueComponent implements OnInit {
    public alert = new AlertModel();
    public cityFk: number;
    public cities: City[] = []

    constructor(private venueData: CustomService,
        private city: CityService) { }

    ngOnInit() { 
        this.city.get().subscribe({
            next: x => {
                this.cities = x;
            }
        })
    }

    postNewEvent(venue: VenueFormModel) {
        if (!this.cityFk){
            this.alert.error = 'City selection is required.'
            return;
        }

    }
}