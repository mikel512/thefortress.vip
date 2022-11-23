// NTypescript generated file

import { City } from './city'
import { EventConcert } from './event-concert'


export interface IVenue {
		venueId: number;
	venueName: string;
	location: string | null;
	address: string;
	description: string;
	picture: string;
	logo: string | null;
	ticketsLink: string | null;
	menuLink: string | null;
	hours: string | null;
	cityFk: number;
	cityFkNavigation: City | null;
	eventConcerts: EventConcert[];

}

export class Venue implements IVenue {
	constructor(init?: Partial<IVenue>) {
		Object.assign(this, init);
	}
	
	venueId: number;
	venueName: string;
	location: string | null;
	address: string;
	description: string;
	picture: string;
	logo: string | null;
	ticketsLink: string | null;
	menuLink: string | null;
	hours: string | null;
	cityFk: number;
	cityFkNavigation: City | null;
	eventConcerts: EventConcert[];
}