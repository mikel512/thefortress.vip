import { Component, OnInit } from '@angular/core';
import { AuthService } from '@services/auth.service';

@Component({
    selector: 'ui-admin-sidebar',
    templateUrl: './admin-sidebar.component.html',
    styleUrls: ['./admin.component.css']
})

export class AdminSidebarComponent implements OnInit {
    constructor(public auth: AuthService) { }

    ngOnInit() { }
}