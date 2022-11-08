
// NTypescript generated file

import { environment } from 'src/environments/environment';
import { HttpClient } from '@angular/common/http';
import { Inject, Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { catchError, map } from 'rxjs/operators';
import { City, ICity } from '@models/city'


@Injectable({
  providedIn: 'root'
})
export class CityService {

	constructor(private http: HttpClient) { } 


	public get(): Observable<City[]> {
		return this.http.get<City[]>(`${environment.baseUrl}api/City`)
			.pipe(map(response => {
				return (response as City[]).map(x => new City(x))
			}));
	}
	public getById(id: number): Observable<City> {
		return this.http.get<City>(`${environment.baseUrl}api/City/${id}`)
			.pipe(map(response => {
				return new City(<ICity> response)
			}));
	}
	public post(value: City): Observable<City> {
		return this.http.post<City>(`${environment.baseUrl}api/City`, value )
			.pipe(map(response => {
				return new City(<ICity> response)
			}));
	}
	public put(id: number, value: City): Observable<City> {
		return this.http.put<City>(`${environment.baseUrl}api/City/${id}`, value )
			.pipe(map(response => {
				return new City(<ICity> response)
			}));
	}
	public delete(id: number): Observable<any> {
		return this.http.delete<any>(`${environment.baseUrl}api/City/${id}`)
			.pipe(map(response => {
				return response
			}));
	}
}