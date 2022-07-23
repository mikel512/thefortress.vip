import { Component, Input, OnInit } from '@angular/core';
import { Router } from '@angular/router';

@Component({
  selector: 'app-search-bar',
  templateUrl: './search-bar.component.html',
  styleUrls: ['./search-bar.component.css']
})
export class SearchBarComponent implements OnInit {
  @Input() city: string = '';
  citiesDropdown: string[] = ['Arcata', 'Eureka', 'All'];
  @Input() isEvent: boolean = true;

  constructor(private router: Router) { }

  ngOnInit(): void {
    this.citiesDropdown = this.citiesDropdown.filter(e => e !== this.city)
  }

  eventsNav() {
    this.router.navigate([this.city]);
    this.isEvent = true;
  }

  venuesNav() {
    this.router.navigate([`venues/${this.city}`]);
    this.isEvent = false;
  }
  
  navigateTo(e: Event) {
    let value = (<HTMLSelectElement>e.target).value;
    console.log(value);
    if(this.isEvent){
      if (value) {
        this.router.navigateByUrl('/', { skipLocationChange: true }).then(() =>
          this.router.navigate([value]));
      }
    } else {
    if(value) {
      this.router.navigateByUrl('/', {skipLocationChange: true}).then(()=>
      this.router.navigate([`venues/${value}`]));
    }

    }
  }

}
