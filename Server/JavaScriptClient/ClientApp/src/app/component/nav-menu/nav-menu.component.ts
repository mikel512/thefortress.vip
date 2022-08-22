import { Component, Inject } from '@angular/core';


@Component({
  selector: 'app-nav-menu',
  templateUrl: './nav-menu.component.html',
  styleUrls: ['./nav-menu.component.css']
})
export class NavMenuComponent {
  isExpanded = false;

  constructor(
    @Inject('BASE_URL') baseUrl: string
  ) {
    // analytic.get(baseUrl).subscribe();
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


export class Claim {
  id: number;
  claim: string;
  value: string;
}

