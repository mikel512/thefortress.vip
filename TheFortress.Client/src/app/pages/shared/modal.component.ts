import { Component, EventEmitter, OnInit, Output } from '@angular/core';

@Component({
    selector: 'app-modal',
    templateUrl: 'modal.component.html'
})

export class AppModalComponent implements OnInit {
    public modalDisplay: string = 'none';

    @Output() onSubmit: EventEmitter<void> = new EventEmitter<void>();

    constructor() { }

    ngOnInit() { }

    show(){
        this.modalDisplay = 'block';
    }

    hide(){
        this.modalDisplay = 'none';
    }
}