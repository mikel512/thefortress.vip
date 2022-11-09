// NTypescript generated file



export interface IEventConcertFormModel {
	eventName: string;
	flyer: File;
	eventDate: Date;
	details: string | null;
	price: string | null;
	ticketsUrl: string | null;
	eventTime: string | null;
	isApproved: boolean | null;
	venueFk: number;

}

export class EventConcertFormModel implements IEventConcertFormModel {
	constructor(init?: Partial<IEventConcertFormModel>) {
		Object.assign(this, init);
	}
	
	eventName: string;
	flyer: File;
	eventDate: Date;
	details: string | null;
	price: string | null;
	ticketsUrl: string | null;
	eventTime: string | null;
	isApproved: boolean | null;
	venueFk: number;
}