import { DOCUMENT } from '@angular/common';
import { Component, Inject, OnInit } from '@angular/core';

@Component({
    selector: 'app-auth-button',
    templateUrl: 'auth-button.component.html'
})

export class AuthButtonComponent implements OnInit {
    constructor() { }

    ngOnInit() { }

    login() {
        window.location.href = "/bff/login";
    }
}