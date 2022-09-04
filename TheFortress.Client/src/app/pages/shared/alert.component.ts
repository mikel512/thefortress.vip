import { Component, Input, OnInit } from '@angular/core';
import { AlertModel } from 'src/app/models/alert-model';

@Component({
    selector: 'ui-alert',
    templateUrl: './alert.component.html'
})

export class AlertComponent implements OnInit {
    @Input() display: string;
    @Input() input: AlertModel;

    constructor() { }

    ngOnInit() { }

    reset() {
        this.input = new AlertModel();
    }
}