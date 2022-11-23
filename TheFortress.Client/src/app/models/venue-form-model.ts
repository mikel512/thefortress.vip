// NTypescript generated file



export interface IVenueFormModel {
	venueName: string;
	picture: File;
	address: string;
	description: string;
	location: string;
	ticketsLink: string;
	menuLink: string;
	hours: string;
	cityFk: number;

}

export class VenueFormModel implements IVenueFormModel {
	constructor(init?: Partial<IVenueFormModel>) {
		Object.assign(this, init);
	}
	
	venueName: string;
	picture: File;
	address: string;
	description: string;
	location: string;
	ticketsLink: string;
	menuLink: string;
	hours: string;
	cityFk: number;
}