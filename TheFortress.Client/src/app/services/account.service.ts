
// NTypescript generated file

import { environment } from 'src/environments/environment';
import { HttpClient } from '@angular/common/http';
import { Inject, Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { catchError, map } from 'rxjs/operators';
import { AppUserDto, IAppUserDto } from '@models/app-user-dto'; 



@Injectable()
export class AccountService {

	constructor(private http: HttpClient) { } 

	public updateUserInfo(appUserDto: AppUserDto): Observable<AppUserDto> {
		return this.http.post<AppUserDto>(`${environment.baseUrl}identity/Account/UpdateUserInfo`, appUserDto)
			.pipe(map(response => {
				return new AppUserDto(<IAppUserDto> response)
			}));
	}

	public getUserInfo(): Observable<AppUserDto> {
		return this.http.get<AppUserDto>(`${environment.baseUrl}identity/Account/GetUserInfo`)
			.pipe(map(response => {
				return new AppUserDto(<IAppUserDto> response)
			}));
	}
	public changePassword(appUser: AppUserDto): Observable<any> { 
		return this.http.put<any>(`${environment.baseUrl}identity/Account/ChangePassword`,appUser)
			.pipe(map(response => {
				return response
			}));
	}
}