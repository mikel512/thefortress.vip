import { DOCUMENT } from '@angular/common';
import { Component, Inject, OnInit } from '@angular/core';
import { AuthService } from '../services/auth.service';

@Component({
    selector: 'app-auth-button',
    templateUrl: 'auth-button.component.html'
})

export class AuthButtonComponent implements OnInit {
    public isLoggedIn = false;
    public displayName: string = '';

    constructor(public _auth: AuthService) { }

    ngOnInit() {
        this._auth.getHeader().then(x => {
            if (x == null) {
                return;
            }
            this.isLoggedIn = true;
            this.displayName = this._auth.getClaim('name');
        });
    }

    login() {
        window.location.href = "/bff/login";
    }
}