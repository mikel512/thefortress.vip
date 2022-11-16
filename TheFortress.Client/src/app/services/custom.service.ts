import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { EventConcert, IEventConcert } from '@models/event-concert';
import { EventConcertFormModel } from '@models/event-concert-form-model';
import { IVenue, Venue } from '@models/venue';
import { VenueFormModel } from '@models/venue-form-model';
import { map, Observable } from 'rxjs';
import { environment } from 'src/environments/environment';

@Injectable({ providedIn: 'root' })
export class CustomService {
    constructor(private http: HttpClient) { }

    public postEventForm(event: EventConcertFormModel): Observable<EventConcert> {
        let formData: FormData = new FormData();
        formData.append('file', event.flyer, event.flyer.name);
        event.flyer = null;
        formData.append('data', JSON.stringify(event));

        return this.http.post(`${environment.baseUrl}api/eventConcert/postWithFlyerFile`, formData)
            .pipe(map(response => {
                return new EventConcert(<IEventConcert>response)
            }));
    }

    public postVenueForm(venue: VenueFormModel): Observable<Venue> {
        let formData: FormData = new FormData();
        formData.append('file', venue.picture, venue.picture.name);
        venue.picture = null;
        formData.append('data', JSON.stringify(venue));

        return this.http.post(`${environment.baseUrl}api/venue/postWithImage`, formData)
            .pipe(map(response => {
                return new Venue(<IVenue>response)
            }));
    }

    public postImage(file: File): Observable<string> {
        let formData: FormData = new FormData();
        formData.append('file', file, file.name);

        return this.http.post<string>(`${environment.baseUrl}api/admin/uploadImage`, formData)
            .pipe(map(response => { return response }
                ));
    }
}