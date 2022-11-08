// NTypewriter generated content
	
import { Component, EventEmitter, OnInit, Output } from '@angular/core';
import { FormControl, FormGroup, Validators } from '@angular/forms';
import { Router } from '@angular/router';
import { AlertModel } from '@models/alert-model';
import { fileTypeValidator } from './file-type-validator'; 
import { EventConcertFormModel } from '@models/event-concert-form-model'

@Component({
	selector: 'ui-event-concert-form-model-form',
	templateUrl: './event-concert-form-model-form.component.html',
	styleUrls: ['../../styles/app-styles.css']
})
export class EventConcertFormModelFormComponent implements OnInit {
	public input: EventConcertFormModel = new EventConcertFormModel();
	public inputForm: FormGroup;

	public alert: AlertModel = new AlertModel();
	
	@Output() outputModel = new EventEmitter<EventConcertFormModel>();

	constructor() { }

	ngOnInit() {    
		this.inputForm = new FormGroup({ 
			eventName: new FormControl ('', [
				Validators.required,
				Validators.maxLength(100),
				Validators.minLength(1),
			]), 
			flyer: new FormControl ('', [ 
				fileTypeValidator([" jpg", "jpeg", "png"]),
				Validators.required,
			]), 
			eventDate: new FormControl ('', [
				Validators.required,
			]),
			details: new FormControl (''),
			price: new FormControl (''),
			ticketsUrl: new FormControl (''),
			eventTime: new FormControl (''),
			isApproved: new FormControl (''),
		});
	} 
	
	get eventName() { return this.inputForm.get('eventName') }
	get flyer() { return this.inputForm.get('flyer') }
	get eventDate() { return this.inputForm.get('eventDate') }
	get details() { return this.inputForm.get('details') }
	get price() { return this.inputForm.get('price') }
	get ticketsUrl() { return this.inputForm.get('ticketsUrl') }
	get eventTime() { return this.inputForm.get('eventTime') }
	get isApproved() { return this.inputForm.get('isApproved') }

	setModel() {
		this.input.eventName = this.eventName.value;
		this.input.flyer = this.flyer.value;
		this.input.eventDate = this.eventDate.value;
		this.input.details = this.details.value;
		this.input.price = this.price.value;
		this.input.ticketsUrl = this.ticketsUrl.value;
		this.input.eventTime = this.eventTime.value;
		this.input.isApproved = this.isApproved.value;
	}

	submit() {
		if(this.inputForm.invalid){
			return;
		}
		this.setModel();
		this.outputModel.emit(this.input);
	}

	reset(){
		this.inputForm.reset();
	}
}


