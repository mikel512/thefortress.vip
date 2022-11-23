// NTypewriter generated content
	
import { Component, EventEmitter, OnInit, Output, Input } from '@angular/core';
import { FormControl, FormGroup, Validators } from '@angular/forms';
import { Router } from '@angular/router';
import { AlertModel } from '@models/alert-model';
import { fileTypeValidator } from './file-type-validator'; 
import { CityFormModel } from '@models/city-form-model'

@Component({
	selector: 'ui-city-form-model-form',
	templateUrl: './city-form-model-form.component.html',
	styleUrls: ['../../styles/app-styles.css']
})
export class CityFormModelFormComponent implements OnInit {
	public input: CityFormModel = new CityFormModel();
	public inputForm: FormGroup;
	@Input() validate: boolean = true;
	@Input() showSubmit: boolean = true;

	public alert: AlertModel = new AlertModel();
	
	@Output() outputModel = new EventEmitter<CityFormModel>();

	constructor() { }

	ngOnInit() {    
		if(this.validate){
			this.inputForm = new FormGroup({ 
				cityName: new FormControl ('', [
					Validators.required,
					Validators.maxLength(100),
				]), 
				image: new FormControl ('', [ 
					fileTypeValidator([" jpg", "jpeg", "png"]),
					Validators.required,
				]),
			});
		} else {
			this.inputForm = new FormGroup({ 
				cityName: new FormControl ('', [
				]), 
				image: new FormControl ('', [
				]),
			});

		}
	} 
	
	get cityName() { return this.inputForm.get('cityName') }
	get image() { return this.inputForm.get('image') }

	setModel() {
		this.input.cityName = this.cityName.value;
		this.input.image = this.image.value;
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


