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

  getClaims(claims: any) {

    let list: Claim[] = new Array<Claim>();

    if (claims != null) {
      Object.keys(claims).forEach(function (k, v) {

        let c = new Claim()
        c.id = v;
        c.claim = k;
        c.value = claims ? claims[k] : null;
        if (c.claim === 'name') this.userName = c.value;
        list.push(c);
      }, this);

    }
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

