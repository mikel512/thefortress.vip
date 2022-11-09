
// NTypescript generated file

import { environment } from 'src/environments/environment';
import { HttpClient } from '@angular/common/http';
import { Inject, Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { catchError, map } from 'rxjs/operators';
import { EventConcert, IEventConcert } from '@models/event-concert'


@Injectable({
  providedIn: 'root'
})
export class EventConcertService {

	constructor(private http: HttpClient) { } 


	public get(): Observable<EventConcert[]> {
		return this.http.get<EventConcert[]>(`${environment.baseUrl}api/EventConcert`)
			.pipe(map(response => {
				return (response as EventConcert[]).map(x => new EventConcert(x))
			}));
	}
	public getById(id: number): Observable<EventConcert> {
		return this.http.get<EventConcert>(`${environment.baseUrl}api/EventConcert/${id}`)
			.pipe(map(response => {
				return new EventConcert(<IEventConcert> response)
			}));
	}
	public getByCity(name: string): Observable<EventConcert[]> {
		return this.http.get<EventConcert[]>(`${environment.baseUrl}api/EventConcert/GetByCity/${name}`)
			.pipe(map(response => {
				return (response as EventConcert[]).map(x => new EventConcert(x))
			}));
	}
	public getByVenue(id: number): Observable<EventConcert[]> {
		return this.http.get<EventConcert[]>(`${environment.baseUrl}api/EventConcert/GetByVenue/${id}`)
			.pipe(map(response => {
				return (response as EventConcert[]).map(x => new EventConcert(x))
			}));
	}
	public post(concert: EventConcert): Observable<EventConcert> {
		return this.http.post<EventConcert>(`${environment.baseUrl}api/EventConcert`, concert )
			.pipe(map(response => {
				return new EventConcert(<IEventConcert> response)
			}));
	}
	public put(id: number, concert: EventConcert): Observable<EventConcert> {
		return this.http.put<EventConcert>(`${environment.baseUrl}api/EventConcert/${id}`, concert )
			.pipe(map(response => {
				return new EventConcert(<IEventConcert> response)
			}));
	}
	public delete(id: number): Observable<any> {
		return this.http.delete<any>(`${environment.baseUrl}api/EventConcert/${id}`)
			.pipe(map(response => {
				return response
			}));
	}
}