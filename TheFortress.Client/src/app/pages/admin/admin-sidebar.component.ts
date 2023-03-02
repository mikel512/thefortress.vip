import { Component, OnInit } from '@angular/core';
import { NavBarItem } from '@models/nav-bar-item';
import { AuthService } from '@services/auth.service';
import { faAddressBook, faCalendarDays, faCalendarPlus, faHouseMedical, faHouse, faCity } from '@fortawesome/free-solid-svg-icons'

@Component({
    selector: 'ui-admin-sidebar',
    templateUrl: './admin-sidebar.component.html',
})

export class AdminSidebarComponent implements OnInit {
    manageItems: NavBarItem[] = [];


    constructor(public auth: AuthService) {
        this.manageItems = [
            { routerLink: '/admin/events', name: 'Event List', icon: faCalendarDays },
            { routerLink: '/admin/add-event', name: 'Add Event', icon: faCalendarPlus },
            { routerLink: '/admin/venues', name: 'Venue List', icon: faHouse },
            { routerLink: '/admin/add-venue', name: 'Add Venue', icon: faHouseMedical },
            { routerLink: '/admin/cities', name: 'City List', icon: faCity },
        ]
    }

    ngOnInit() { }
}
