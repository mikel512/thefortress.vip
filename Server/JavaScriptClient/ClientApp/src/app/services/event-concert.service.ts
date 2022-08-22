// NTypescript generated file

import { HttpClient } from '@angular/common/http';
import { Inject, Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { catchError, map } from 'rxjs/operators';
import { EventConcert, IEventConcert } from '../models/event-concert'


@Injectable({
  providedIn: 'root'
})
export class EventConcertService {

	constructor(private http: HttpClient) { } 


	public get(baseUrl): Observable<EventConcert[]> {
		return this.http.get<EventConcert[]>(baseUrl + `api/EventConcert`)
			.pipe(map(response => {
				return (response as EventConcert[]).map(x => new EventConcert(x))
			}));
	}
	public getById(baseUrl, id: number): Observable<EventConcert> {
		return this.http.get<EventConcert>(baseUrl + `api/EventConcert/${id}`)
			.pipe(map(response => {
				return new EventConcert(<IEventConcert> response)
			}));
	}
	public getByCity(baseUrl, name: string): Observable<EventConcert[]> {
		return this.http.get<EventConcert[]>(baseUrl + `api/EventConcert/GetByCity/${name}`)
			.pipe(map(response => {
				return (response as EventConcert[]).map(x => new EventConcert(x))
			}));
	}
	public getByVenue(baseUrl, id: number): Observable<EventConcert[]> {
		return this.http.get<EventConcert[]>(baseUrl + `api/EventConcert/GetByVenue/${id}`)
			.pipe(map(response => {
				return (response as EventConcert[]).map(x => new EventConcert(x))
			}));
	}
	public post(baseUrl, concert: EventConcert): Observable<EventConcert> {
		return this.http.post<EventConcert>(baseUrl + `api/EventConcert`, concert )
			.pipe(map(response => {
				return new EventConcert(<IEventConcert> response)
			}));
	}
	public put(baseUrl, id: number, concert: EventConcert): Observable<EventConcert> {
		return this.http.put<EventConcert>(baseUrl + `api/EventConcert/${id}`, concert )
			.pipe(map(response => {
				return new EventConcert(<IEventConcert> response)
			}));
	}
	public delete(baseUrl, id: number): Observable<any> {
		return this.http.delete<any>(baseUrl + `api/EventConcert/${id}`)
			.pipe(map(response => {
				return response
			}));
	}
}