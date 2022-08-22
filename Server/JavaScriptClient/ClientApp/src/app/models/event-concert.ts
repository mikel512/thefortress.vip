// NTypescript generated file

import { Venue } from './venue'


export interface IEventConcert {
	eventConcertId: number;
	eventName: string;
	flyer: string | null;
	eventDate: Date;
	isApproved: boolean | null;
	tickets: string | null;
	venueFk: number | null;
	details: string | null;
	price: string | null;
	eventTime: string | null;
	status: string | null;
	venueFkNavigation: Venue | null;

}

export class EventConcert implements IEventConcert {
	constructor(init: Partial<IEventConcert>) {
		Object.assign(this, init);
	}
	
	eventConcertId: number;
	eventName: string;
	flyer: string | null;
	eventDate: Date;
	isApproved: boolean | null;
	tickets: string | null;
	venueFk: number | null;
	details: string | null;
	price: string | null;
	eventTime: string | null;
	status: string | null;
	venueFkNavigation: Venue | null;
}