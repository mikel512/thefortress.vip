import { Component, OnInit } from '@angular/core';
import { NavBarItem } from '@models/nav-bar-item';
import { AuthService } from '@services/auth.service';

@Component({
    selector: 'ui-admin-sidebar',
    templateUrl: './admin-sidebar.component.html',
    styleUrls: ['./admin.component.css']
})

export class AdminSidebarComponent implements OnInit {
    manageItems: NavBarItem[] = [];


    constructor(public auth: AuthService) {
        this.manageItems = [
            { routerLink: '/admin/events', name: 'Event List' },
            { routerLink: '/admin/add-event', name: 'Add Event' },
            { routerLink: '/admin/venues', name: 'Venue List' },
            { routerLink: '/admin/add-venue', name: 'Add Venue' },
            { routerLink: '/admin/cities', name: 'City List' },
        ]
    }

    ngOnInit() { }
}
