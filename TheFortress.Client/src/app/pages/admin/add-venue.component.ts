import { Component, OnInit, ViewChild } from '@angular/core';
import { NumberValueAccessor } from '@angular/forms';
import { VenueFormModelFormComponent } from '@forms/venue-form-model-form.component';
import { AlertModel } from '@models/alert-model';
import { City } from '@models/city';
import { VenueFormModel } from '@models/venue-form-model';
import { CityService } from '@services/city.service';
import { CustomService } from '@services/custom.service';

@Component({
    selector: 'app-add-venue',
    templateUrl: 'add-venue.component.html',
    providers: [CityService, CustomService]
})

export class AddVenueComponent implements OnInit {
    public alert = new AlertModel();
    public cityFk: number;
    public cities: City[] = []

    @ViewChild(VenueFormModelFormComponent) form: VenueFormModelFormComponent;

    constructor(private venueData: CustomService,
        private city: CityService) { }

    ngOnInit() { 
        this.city.get().subscribe({
            next: x => {
                this.cities = x;
            }
        })
    }

    post(venue: VenueFormModel) {
        if (!this.cityFk){
            this.alert.error = 'City selection is required.'
            return;
        }

        venue.cityFk = this.cityFk;
        this.venueData.postVenueForm(venue).subscribe({
            next: item => {
                this.alert.success = 'Venue added'
                this.form.reset();
            }
        })

    }
}