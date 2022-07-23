// NTypescript generated file

import { HttpClient } from '@angular/common/http';
import { Inject, Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { catchError, map } from 'rxjs/operators';
import { AppUser, IAppUser } from '../models/app-user'


@Injectable({
  providedIn: 'root'
})
export class AppUserService {

	constructor(private http: HttpClient) { } 


	public get(baseUrl): Observable<AppUser[]> {
		return this.http.get<AppUser[]>(baseUrl + `api/AppUser`)
			.pipe(map(response => {
				return (response as AppUser[]).map(x => new AppUser(x))
			}));
	}
	public getById(baseUrl, id: number): Observable<AppUser> {
		return this.http.get<AppUser>(baseUrl + `api/AppUser/${id}`)
			.pipe(map(response => {
				return new AppUser(<IAppUser> response)
			}));
	}
	public post(baseUrl, user: AppUser): Observable<AppUser> {
		return this.http.post<AppUser>(baseUrl + `api/AppUser`, user )
			.pipe(map(response => {
				return new AppUser(<IAppUser> response)
			}));
	}
	public put(baseUrl, id: number, user: AppUser): Observable<AppUser> {
		return this.http.put<AppUser>(baseUrl + `api/AppUser/${id}`, user )
			.pipe(map(response => {
				return new AppUser(<IAppUser> response)
			}));
	}
	public delete(baseUrl, id: number): Observable<any> {
		return this.http.delete<any>(baseUrl + `api/AppUser/${id}`)
			.pipe(map(response => {
				return response
			}));
	}
}