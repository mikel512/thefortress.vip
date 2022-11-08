import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { EventConcert, IEventConcert } from '@models/event-concert';
import { EventConcertFormModel } from '@models/event-concert-form-model';
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

}