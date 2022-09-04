import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { shareReplay, Subject, tap } from 'rxjs'
import { LoginDto } from '../models/login-dto';
import * as moment from 'moment';
import { _isNumberValue } from '@angular/cdk/coercion';
import { Router } from '@angular/router';
import { RegistrationDto } from '../models/registration-dto';

@Injectable({ providedIn: 'root' })
export class AuthService {
    private _isAuthenticated = new Subject<boolean>();
    public isAuthenticated$ = this._isAuthenticated.asObservable();


    constructor(
        private router: Router,
        private http: HttpClient) {
    }

    login(login: LoginDto) {
        return this.http.post<any>('/authenticate/login', login);
    }

    register(input: RegistrationDto) {
        return this.http.post<any>('/authenticate/register', input);

    }

    private setSession(authResult) {
        console.log(authResult);
        const expiresAt = moment().add(authResult.expiresIn, 'second');

        localStorage.setItem('id_token', authResult.token);
        localStorage.setItem("expires_at", JSON.stringify(expiresAt.valueOf()));
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

    // isLoggedOut() {
    //     return !this.isLoggedIn();
    // }

    getExpiration() {
        const expiration = localStorage.getItem("expires_at");
        const expiresAt = JSON.parse(expiration);
        return moment(expiresAt);
    }
}
