﻿// NTypewriter generated content
	
import { Component, EventEmitter, OnInit, Output, Input } from '@angular/core';
import { FormControl, FormGroup, Validators } from '@angular/forms';
import { Router } from '@angular/router';
import { AlertModel } from '@models/alert-model';
import { fileTypeValidator } from './file-type-validator'; 
import { VenueFormModel } from '@models/venue-form-model'

@Component({
	selector: 'ui-venue-form-model-form',
	templateUrl: './venue-form-model-form.component.html',
})
export class VenueFormModelFormComponent implements OnInit {
	public input: VenueFormModel = new VenueFormModel();
	public inputForm: FormGroup;
	@Input() validate: boolean = true;
	@Input() showSubmit: boolean = true;

	public alert: AlertModel = new AlertModel();
	
	@Output() outputModel = new EventEmitter<VenueFormModel>();

	constructor() { }

	ngOnInit() {    
		if(this.validate){
			this.inputForm = new FormGroup({ 
				venueName: new FormControl ('', [
					Validators.required,
					Validators.maxLength(100),
					Validators.minLength(1),
				]), 
				picture: new FormControl ('', [ 
					fileTypeValidator([" jpg", "jpeg", "png"]),
					Validators.required,
				]), 
				address: new FormControl ('', [
					Validators.required,
				]), 
				description: new FormControl ('', [
					Validators.required,
				]),
				location: new FormControl (''),
				ticketsLink: new FormControl (''),
				menuLink: new FormControl (''),
				hours: new FormControl (''),
			});
		} else {
			this.inputForm = new FormGroup({ 
				venueName: new FormControl ('', [
				]), 
				picture: new FormControl ('', [
				]), 
				address: new FormControl ('', [
				]), 
				description: new FormControl ('', [
				]),
				location: new FormControl (''),
				ticketsLink: new FormControl (''),
				menuLink: new FormControl (''),
				hours: new FormControl (''),
			});

		}
	} 
	
	get venueName() { return this.inputForm.get('venueName') }
	get picture() { return this.inputForm.get('picture') }
	get address() { return this.inputForm.get('address') }
	get description() { return this.inputForm.get('description') }
	get location() { return this.inputForm.get('location') }
	get ticketsLink() { return this.inputForm.get('ticketsLink') }
	get menuLink() { return this.inputForm.get('menuLink') }
	get hours() { return this.inputForm.get('hours') }

	setModel() {
		this.input.venueName = this.venueName.value;
		this.input.picture = this.picture.value;
		this.input.address = this.address.value;
		this.input.description = this.description.value;
		this.input.location = this.location.value;
		this.input.ticketsLink = this.ticketsLink.value;
		this.input.menuLink = this.menuLink.value;
		this.input.hours = this.hours.value;
	}

	submit() {
		if(this.inputForm.invalid){
			return;
		}
		this.setModel();
		this.outputModel.emit(this.input);
	}

	getInputModel() {
		this.setModel();
		return this.input;
	}

	reset(){
		this.inputForm.reset();
	}
}


