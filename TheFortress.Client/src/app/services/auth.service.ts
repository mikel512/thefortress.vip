import { HttpClient, HttpParams } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { shareReplay, Subject, tap } from 'rxjs'
import { LoginDto } from '../models/login-dto';
import * as moment from 'moment';
import { _isNumberValue } from '@angular/cdk/coercion';
import { Router } from '@angular/router';
import { RegistrationDto } from '../models/registration-dto';

export enum ClaimKey {
    name = "http://schemas.xmlsoap.org/ws/2005/05/identity/claims/name",
    email = "http://schemas.xmlsoap.org/ws/2005/05/identity/claims/emailaddress",
    role = "http://schemas.microsoft.com/ws/2008/06/identity/claims/role"
}

@Injectable({ providedIn: 'root' })
export class AuthService {
    private _isAuthenticated = new Subject<boolean>();
    public isAuthenticated$ = this._isAuthenticated.asObservable();
    private _decodedJWT = {};


    constructor(
        private router: Router,
        private http: HttpClient) {
        setTimeout(() => {
            this.isLoggedIn();
        }, 10000)
        this.setClaims();
    }

    login(login: LoginDto) {
        return this.http.post<any>('/authenticate/login', login)
            .pipe(tap((x) => this.setSession(x), shareReplay));
    }

    register(input: RegistrationDto) {
        return this.http.post<any>('/authenticate/register', input);

    }

    private setSession(authResult) {
        const expiresAt = moment().add(authResult.expiresIn, 'second');

        localStorage.setItem('id_token', authResult.token);
        localStorage.setItem("expires_at", JSON.stringify(expiresAt.valueOf()));
        this.setClaims();

        this._isAuthenticated.next(true);
        this.router.navigate(['/'])
    }

    logout() {
        localStorage.removeItem("id_token");
        localStorage.removeItem("expires_at");
        this._isAuthenticated.next(false);
        window.location.reload();
    }

    public isLoggedIn() {
        let status = moment().isBefore(this.getExpiration());
        console.log(status);
        this._isAuthenticated.next(status);
    }

    confirmEmail(userId: string, code: string) {
        userId = userId.trim();
        code = code.trim();

        const options = 
        {
            params: new HttpParams().set('userId', userId).set('code', code)
            
        };
        return this.http.get<any>('/authenticate/ConfirmEmail', options);
    }

    // isLoggedOut() {
    //     return !this.isLoggedIn();
    // }

    getExpiration() {
        const expiration = localStorage.getItem("expires_at");
        const expiresAt = JSON.parse(expiration);
        return moment(expiresAt);
    }

    setClaims() {
        let token = localStorage.getItem('id_token');
        if (token != null) {
            this._decodedJWT = JSON.parse(window.atob(token.split('.')[1]));
            console.log(this._decodedJWT);
        }

    }

    getName() {
        return this._decodedJWT[ClaimKey.name];
    }
    getRoles() {
        return this._decodedJWT[ClaimKey.role];
    }
    isAdmin() {
        return this.getRoles()?.includes("Admin");
    }
}
