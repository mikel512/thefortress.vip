
// NTypescript generated file

import { environment } from 'src/environments/environment';
import { HttpClient } from '@angular/common/http';
import { Inject, Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { catchError, map } from 'rxjs/operators';
import { Venue, IVenue } from '@models/venue'; 



@Injectable({
  providedIn: 'root'
})
export class VenueService {

	constructor(private http: HttpClient) { } 


	public get(): Observable<Venue[]> {
		return this.http.get<Venue[]>(`${environment.baseUrl}api/Venue`)
			.pipe(map(response => {
				return (response as Venue[]).map(x => new Venue(x))
			}));
	}
	public getByCity(city: string): Observable<Venue[]> {
		return this.http.get<Venue[]>(`${environment.baseUrl}api/Venue/city/${city}`)
			.pipe(map(response => {
				return (response as Venue[]).map(x => new Venue(x))
			}));
	}
	public getById(id: number): Observable<Venue> {
		return this.http.get<Venue>(`${environment.baseUrl}api/Venue/${id}`)
			.pipe(map(response => {
				return new Venue(<IVenue> response)
			}));
	}
	public post(value: Venue): Observable<Venue> {
		return this.http.post<Venue>(`${environment.baseUrl}api/Venue`, value )
			.pipe(map(response => {
				return new Venue(<IVenue> response)
			}));
	}
	public put(id: number, value: Venue): Observable<Venue> {
		return this.http.put<Venue>(`${environment.baseUrl}api/Venue/${id}`, value )
			.pipe(map(response => {
				return new Venue(<IVenue> response)
			}));
	}
	public delete(id: number): Observable<any> {
		return this.http.delete<any>(`${environment.baseUrl}api/Venue/${id}`)
			.pipe(map(response => {
				return response
			}));
	}
}