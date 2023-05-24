import { DOCUMENT } from '@angular/common';
import { AfterViewInit, ChangeDetectorRef, Component, Inject, OnInit } from '@angular/core';
import { AuthService } from 'src/app/services/auth.service';

@Component({
    selector: 'app-auth-button',
    templateUrl: 'auth-button.component.html',
    providers: [AuthService]
})

export class AuthButtonComponent implements OnInit, AfterViewInit {
    constructor(public auth: AuthService,
        private cdr: ChangeDetectorRef) { }

    ngOnInit() { 
    }

    ngAfterViewInit(): void {
        this.auth.isLoggedIn();
        this.cdr.detectChanges();
    }
}