import { Component, Inject } from '@angular/core';
import { NavBarItem } from '@models/nav-bar-item';


@Component({
  selector: 'app-nav-menu',
  templateUrl: './nav-menu.component.html',
  styleUrls: ['./nav-menu.component.css']
})
export class NavMenuComponent {
  isExpanded = false;
  public navItems: NavBarItem[] = [];

  constructor() {
    this.navItems = [
      { name: 'Events', routerLink: '/All' },
      { name: 'Venues', routerLink: '/venues/All' },
      { name: 'About', routerLink: '/about' },
    ]
  }

  ngOnInit() {
  }
  ngOnDestroy(): void {
  }

  collapse() {
    this.isExpanded = false;
  }

  toggle() {
    this.isExpanded = !this.isExpanded;
  }

}
