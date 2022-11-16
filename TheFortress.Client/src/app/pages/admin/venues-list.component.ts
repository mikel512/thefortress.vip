import { Component, OnInit, ViewChild } from '@angular/core';
import { VenueFormModelFormComponent } from '@forms/venue-form-model-form.component';
import { Venue } from '@models/venue';
import { VenueFormModel } from '@models/venue-form-model';
import { VenueService } from '@services/venue.service';
import { AppModalComponent } from '../shared/modal.component';

@Component({
    selector: 'app-venues-list',
    templateUrl: 'venues-list.component.html'
})

export class VenuesListComponent implements OnInit {
    public venues: Venue[] = [];
    public editVenue: Venue;

    @ViewChild(VenueFormModelFormComponent) form: VenueFormModelFormComponent;
    @ViewChild(AppModalComponent) modal: AppModalComponent;

    constructor(private venueData: VenueService) { }

    ngOnInit() { 
        this.venueData.get().subscribe({
            next: x => {
                this.venues = x;
            }
        })
    }

    edit(venue: Venue) {
        this.editVenue = venue;
        this.form.inputForm.setValue({
            venueName: venue.venueName,
            address: venue.address,
            picture: venue.picture,
            location: venue.location,
            description: venue.description,
            ticketsLink: venue.ticketsLink,
            menuLink: venue.menuLink,
            hours: venue.hours
        })
        this.modal.show();
    }

    update(updateVenue: VenueFormModel){
        let update = new Venue({
            venueName: updateVenue.venueName,
            address: updateVenue.address,
            location: updateVenue.location,

        });

    }
}