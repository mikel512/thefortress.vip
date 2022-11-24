import { Component, ElementRef, EventEmitter, OnInit, Output, ViewChild } from '@angular/core';

@Component({
    selector: 'app-modal',
    templateUrl: 'modal.component.html'
})

export class AppModalComponent implements OnInit {
    public modalDisplay: string = 'none';

    @Output() onSubmit: EventEmitter<void> = new EventEmitter<void>();
    @ViewChild('modal') modal: ElementRef;

    constructor() { }

    ngOnInit() { }

    show(){
        this.modal.nativeElement.className = 'modal fade show';
        this.modalDisplay = 'block';
    }

    hide(){
        this.modalDisplay = 'none';
    }
}