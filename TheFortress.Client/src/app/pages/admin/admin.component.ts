import { Component, OnInit } from '@angular/core';
import { AuthService } from '@services/auth.service';

@Component({
    selector: 'ui-admin',
    templateUrl: './admin.component.html',
    styleUrls: ['./admin.component.css']
})

export class AdminComponent implements OnInit {
    constructor(public auth: AuthService) { }

    ngOnInit() { }
}