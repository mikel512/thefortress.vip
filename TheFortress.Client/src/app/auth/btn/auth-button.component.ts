import { DOCUMENT } from '@angular/common';
import { Component, Inject, OnInit } from '@angular/core';
import { AuthService } from 'src/app/services/auth.service';

@Component({
    selector: 'app-auth-button',
    templateUrl: 'auth-button.component.html'
})

export class AuthButtonComponent implements OnInit {
    constructor(public auth: AuthService) { }

    ngOnInit() { }

}