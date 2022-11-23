import { Component, OnInit, ViewChild } from '@angular/core';
import { CityFormModelFormComponent } from '@forms/city-form-model-form.component';
import { City } from '@models/city';
import { CityService } from '@services/city.service';
import { AppModalComponent } from '../shared/modal.component';

@Component({
    selector: 'app-cities-list',
    templateUrl: 'cities-list.component.html'
})

export class CitiesListComponent implements OnInit {
    public cities: City[] = [];
    public cityEdit: City;

    @ViewChild(AppModalComponent) modal: AppModalComponent;
    @ViewChild(CityFormModelFormComponent) form: CityFormModelFormComponent;

    constructor(private _cities: CityService) { }

    ngOnInit() { 
        this.reload();
    }

    reload() {
        this._cities.get().subscribe({
            next: x => {
                this.cities = x;
            }
        });
    }

    edit(city: City) {
        this.cityEdit = city;
        this.form.inputForm.setValue({
            cityName: city.cityName,
            image: city.image
        });

        this.modal.show();
    }
}