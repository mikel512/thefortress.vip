import { Component, Input, OnChanges, OnInit, SimpleChanges } from '@angular/core';
import { Venue } from 'src/app/models/venue';

@Component({
    selector: 'app-master-page-item',
    templateUrl: 'master-page-item.component.html',
    styleUrls: ['master-page-item.component.css']
})

export class MasterPageItemComponent implements OnInit, OnChanges{
    @Input() eventName: string = '';
    @Input() venueName: string = '';
    @Input() link: string = '';
    @Input() location: string = '';
    @Input() date: Date;
    @Input() isEvent: boolean;
    @Input() imgUrl: string;
    public imageLoader: boolean = false;


    constructor() { }
    ngOnChanges(changes: SimpleChanges): void {
    }

    ngOnInit() {
    }
}