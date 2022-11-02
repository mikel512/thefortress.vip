// NTypewriter generated content
	
import { Component, EventEmitter, OnInit, Output } from '@angular/core';
import { UntypedFormControl, UntypedFormGroup, Validators } from '@angular/forms';
import { Router } from '@angular/router';
import { AlertModel } from '@models/alert-model';
import { EventConcert } from '@models/event-concert'
import { EventConcertService } from '@services/event-concert.service'

@Component({
	selector: 'ui-event-concert-form',
	templateUrl: './event-concert-form.component.html',
	styleUrls: ['../styles/app-styles.css']
})
export class EventConcertFormComponent implements OnInit {
	public input: EventConcert = new EventConcert();
	public inputForm: UntypedFormGroup;

	public alert: AlertModel = new AlertModel();
	
	@Output() out = new EventEmitter<EventConcert>();

	constructor(private data: EventConcertService) { }

	ngOnInit() {    
		this.inputForm = new UntypedFormGroup({ 
			eventName: new UntypedFormControl ('', [
				Validators.required,
				Validators.maxLength(100),
				Validators.minLength(1),
			]), 
			flyer: new UntypedFormControl ('', [
				Validators.required,
			]), 
			eventDate: new UntypedFormControl ('', [
				Validators.required,
			]),
			details: new UntypedFormControl (''),
			price: new UntypedFormControl (''),
			eventTime: new UntypedFormControl (''),
			isApproved: new UntypedFormControl (''),
		});
	} 
	
		get eventName() { return this.inputForm.get('eventName') }
		get flyer() { return this.inputForm.get('flyer') }
		get eventDate() { return this.inputForm.get('eventDate') }
		get details() { return this.inputForm.get('details') }
		get price() { return this.inputForm.get('price') }
		get eventTime() { return this.inputForm.get('eventTime') }
		get isApproved() { return this.inputForm.get('isApproved') }

	setModel() {
		this.input.eventName = this.eventName.value;
		this.input.flyer = this.flyer.value;
		this.input.eventDate = this.eventDate.value;
		this.input.details = this.details.value;
		this.input.price = this.price.value;
		this.input.eventTime = this.eventTime.value;
		this.input.isApproved = this.isApproved.value;
	}

	submit() {
		if(this.inputForm.invalid){
			return;
		}
		this.setModel();
		this.out.emit(this.input);
	}
}


