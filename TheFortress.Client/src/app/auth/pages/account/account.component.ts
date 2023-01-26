import { Component, OnInit } from '@angular/core';
import { NavBarItem } from '@models/nav-bar-item';

@Component({
    selector: 'app-account',
    templateUrl: 'account.component.html'
})

export class AccountComponent implements OnInit {
    navLinks: NavBarItem[] = [];

    constructor() { 
        this.navLinks = [
            { name: 'Account Info', routerLink: '/auth/account/info'}
        ]
    }

    ngOnInit() { }
}