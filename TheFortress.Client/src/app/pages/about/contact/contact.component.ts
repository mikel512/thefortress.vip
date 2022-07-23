import { Component, OnInit } from '@angular/core';
import { TooltipPosition } from '@angular/material/tooltip';

@Component({
  selector: 'app-contact',
  templateUrl: './contact.component.html',
  styleUrls: ['./contact.component.css']
})
export class ContactComponent implements OnInit {
  email: string = 'thefortressbooking@gmail.com';

  constructor() { }

  ngOnInit(): void {
  }

}
