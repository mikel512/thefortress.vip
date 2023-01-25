
// NTypescript generated file

import { environment } from 'src/environments/environment';
import { HttpClient } from '@angular/common/http';
import { Inject, Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { catchError, map } from 'rxjs/operators';
import { AppUserDto, IAppUserDto } from '@models/app-user-dto'; 



@Injectable({
  providedIn: 'root'
})
export class AccountService {

	constructor(private http: HttpClient) { } 

	public updateUserInfo(appUserDto: AppUserDto): Observable<AppUserDto> {
		return this.http.post<AppUserDto>(`${environment.baseUrl}identity/Account/UpdateUserInfo`, appUserDto AppUserDto)
			.pipe(map(response => {
				return new AppUserDto(<IAppUserDto> response)
			}));
	}
}