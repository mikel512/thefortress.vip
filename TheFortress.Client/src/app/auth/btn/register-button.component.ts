import { Component, OnInit } from '@angular/core';

@Component({
    selector: 'app-register-button',
    templateUrl: 'register-button.component.html'
})

export class RegisterButtonComponent implements OnInit {
    constructor() { }

    ngOnInit() { }

    loginWithRedirect(): void {
        // this.auth.loginWithRedirect({ screen_hint: 'signup' });
    }
}