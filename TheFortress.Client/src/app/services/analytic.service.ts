// NTypescript generated file

import { HttpClient } from '@angular/common/http';
import { Inject, Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { catchError, map } from 'rxjs/operators';
import { Analytic, IAnalytic } from '@models/analytic'


@Injectable({
  providedIn: 'root'
})
export class AnalyticService {

	constructor(private http: HttpClient) { } 


	public get(baseUrl): Observable<any> {
		return this.http.get<any>(baseUrl + `api/Analytic`)
			.pipe(map(response => {
				return response
			}));
	}
}