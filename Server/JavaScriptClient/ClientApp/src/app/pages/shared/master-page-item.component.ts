import { Component, Input, OnInit } from '@angular/core';
import { Venue } from 'src/app/models/venue';

@Component({
    selector: 'app-master-page-item',
    templateUrl: 'master-page-item.component.html',
    styleUrls: ['master-page-item.component.css']
})

export class MasterPageItemComponent implements OnInit {
    @Input() eventName: string = '';
    @Input() venueName: string = '';
    @Input() link: string = '';
    @Input() location: string = '';
    @Input() imgUrl: string = '';
    @Input() date: Date;
    @Input() isEvent: boolean;
    public imageLoader: boolean = false;
    

    constructor() { }

    ngOnInit() { }
}