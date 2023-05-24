import { AfterViewInit, Component, Inject, OnInit, TemplateRef, ViewChild } from '@angular/core';
import { EventConcertFormModelFormComponent } from '@forms/event-concert-form-model-form.component';
import { AlertModel } from '@models/alert-model';
import { EventConcertFormModel } from '@models/event-concert-form-model';
import { Venue } from '@models/venue';
import { Base64Service } from '@services/base-64.service';
import { CustomService } from '@services/custom.service';
import { EventConcertService } from '@services/event-concert.service';
import { VenueService } from '@services/venue.service';
import { MasterPageItemComponent } from '../shared/master-page-item.component';
import { AppModalComponent } from '../shared/modal.component';

@Component({
    selector: 'app-add-event',
    templateUrl: 'add-event.component.html',
    providers: [Base64Service, VenueService, CustomService]
})

export class AddEventComponent implements OnInit, AfterViewInit {
    public event: EventConcertFormModel;
    public venues: Venue[] = [];
    public venueFK: number;
    public alert = new AlertModel();
    public base64str: string;

    @ViewChild('form') form: EventConcertFormModelFormComponent;
    @ViewChild('previewModal') preview: AppModalComponent;
    @ViewChild('preview') previewCard: MasterPageItemComponent;

    constructor(private _venues: VenueService,
        private _base64: Base64Service,
        private _event: CustomService,) { }

    ngAfterViewInit(): void {
        this.form.inputForm.valueChanges.subscribe({
            next: x => {
                if (x.flyer) {
                    this._base64.convert(x.flyer);
                }
            }
        })
    }

    ngOnInit() {
        this._venues.get().subscribe({
            next: (items) => {
                this.venues = items;
            }
        })
        this._base64.base64Observable.subscribe({
            next: x => {
                this.base64str = x;
            }
        });
    }


    showPreviewModal(event: EventConcertFormModel) {
        this.event = event;
        event.venueFk = this.venueFK;
        this.preview.show();
    }
    closeModal() {
        this.preview.hide();
    }

    postNewEvent(event: EventConcertFormModel) {
        if (!this.venueFK){
            this.alert.error = 'Venue selection is required.'
            return;
        }
        this.event = event;
        event.venueFk = this.venueFK;

        this._event.postEventForm(this.event).subscribe({
            next: item => {
                console.log(item);
                this.form.reset();
            }
        })

    }
}