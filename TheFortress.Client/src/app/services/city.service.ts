// NTypescript generated file

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


	public get(baseUrl): Observable<City[]> {
		return this.http.get<City[]>(baseUrl + `api/City`)
			.pipe(map(response => {
				return (response as City[]).map(x => new City(x))
			}));
	}
	public getById(baseUrl, id: number): Observable<City> {
		return this.http.get<City>(baseUrl + `api/City/${id}`)
			.pipe(map(response => {
				return new City(<ICity> response)
			}));
	}
	public post(baseUrl, value: City): Observable<City> {
		return this.http.post<City>(baseUrl + `api/City`, value )
			.pipe(map(response => {
				return new City(<ICity> response)
			}));
	}
	public put(baseUrl, id: number, value: City): Observable<City> {
		return this.http.put<City>(baseUrl + `api/City/${id}`, value )
			.pipe(map(response => {
				return new City(<ICity> response)
			}));
	}
	public delete(baseUrl, id: number): Observable<any> {
		return this.http.delete<any>(baseUrl + `api/City/${id}`)
			.pipe(map(response => {
				return response
			}));
	}
}