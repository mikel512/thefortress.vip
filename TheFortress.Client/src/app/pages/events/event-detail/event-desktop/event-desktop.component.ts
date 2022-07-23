import { Component, Input, OnInit } from '@angular/core';
import { EventConcert } from '../../../../models/event-concert';
import {DomSanitizer, SafeUrl} from '@angular/platform-browser'

@Component({
  selector: 'app-event-desktop',
  templateUrl: './event-desktop.component.html',
  styleUrls: ['./event-desktop.component.css']
})
export class EventDesktopComponent implements OnInit {
  @Input() dataDesk!: EventConcert;
  displayDate: string = '';
  abnormalStatus: boolean = false;

  constructor(private domSanitizer: DomSanitizer) { }

  ngOnInit(): void {
    this.checkStatus();
  }

  flyerURL() {
    return this.domSanitizer.bypassSecurityTrustUrl(this.dataDesk.flyer)
  }

  checkStatus() {
    if(this.dataDesk.status === '' || this.dataDesk.status === null) {
    } else {
      this.abnormalStatus = true;
    }
  }

}
