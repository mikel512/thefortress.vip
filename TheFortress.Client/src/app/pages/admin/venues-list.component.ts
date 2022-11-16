import { Component, OnInit, ViewChild } from '@angular/core';
import { VenueFormModelFormComponent } from '@forms/venue-form-model-form.component';
import { Venue } from '@models/venue';
import { VenueFormModel } from '@models/venue-form-model';
import { CustomService } from '@services/custom.service';
import { VenueService } from '@services/venue.service';
import { concat } from 'rxjs';
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

    constructor(private venueData: VenueService,
        private cstmService: CustomService) { }

    ngOnInit() {
        this.reload();
    }

    reload() {
        this.venues = [];
        this.venueData.get().subscribe({
            next: x => {
                this.venues = x;
            }
        });
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

    update(updateVenue: VenueFormModel) {
        let update = new Venue({
            venueId: this.editVenue.venueId,
            venueName: updateVenue.venueName,
            location: updateVenue.location,
            address: updateVenue.address,
            description: updateVenue.description,
            // picture: updateVenue.picture,
            // logo: ;
            ticketsLink: updateVenue.ticketsLink,
            menuLink: updateVenue.menuLink,
            hours: updateVenue.hours


        });
        // first upload the image, if there is one
        const venuePut = this.venueData.put(update.venueId, update);
        if (updateVenue.picture) {
            const imgObservable = this.cstmService.postImage(updateVenue.picture);

            concat(imgObservable, venuePut).subscribe({
                next(value) {
                    
                },
            })
        } else {
            update.picture = this.editVenue.picture;
            venuePut.subscribe({
                next: x => {
                    this.modal.hide();
                    this.reload();
                }
            })
        }
    }
}