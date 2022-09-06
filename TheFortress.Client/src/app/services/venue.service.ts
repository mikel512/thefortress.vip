// NTypescript generated file

import { HttpClient } from '@angular/common/http';
import { Inject, Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { catchError, map } from 'rxjs/operators';
import { Venue, IVenue } from '@models/venue'


@Injectable({
  providedIn: 'root'
})
export class VenueService {

	constructor(private http: HttpClient) { } 


	public get(baseUrl): Observable<Venue[]> {
		return this.http.get<Venue[]>(baseUrl + `api/Venue`)
			.pipe(map(response => {
				return (response as Venue[]).map(x => new Venue(x))
			}));
	}
	public getByCity(baseUrl, city: string): Observable<Venue[]> {
		return this.http.get<Venue[]>(baseUrl + `api/Venue/city/${city}`)
			.pipe(map(response => {
				return (response as Venue[]).map(x => new Venue(x))
			}));
	}
	public getById(baseUrl, id: number): Observable<Venue> {
		return this.http.get<Venue>(baseUrl + `api/Venue/${id}`)
			.pipe(map(response => {
				return new Venue(<IVenue> response)
			}));
	}
	public post(baseUrl, value: Venue): Observable<Venue> {
		return this.http.post<Venue>(baseUrl + `api/Venue`, value )
			.pipe(map(response => {
				return new Venue(<IVenue> response)
			}));
	}
	public put(baseUrl, id: number, value: Venue): Observable<Venue> {
		return this.http.put<Venue>(baseUrl + `api/Venue/${id}`, value )
			.pipe(map(response => {
				return new Venue(<IVenue> response)
			}));
	}
	public delete(baseUrl, id: number): Observable<any> {
		return this.http.delete<any>(baseUrl + `api/Venue/${id}`)
			.pipe(map(response => {
				return response
			}));
	}
}