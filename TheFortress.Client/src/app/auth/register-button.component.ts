import { Component, OnInit } from '@angular/core';
import { AuthService } from '@auth0/auth0-angular';

@Component({
    selector: 'app-register-button',
    templateUrl: 'register-button.component.html'
})

export class RegisterButtonComponent implements OnInit {
    constructor(private auth: AuthService) { }

    ngOnInit() { }

    loginWithRedirect(): void {
        this.auth.loginWithRedirect({ screen_hint: 'signup' });
    }
}