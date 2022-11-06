// NTypescript generated file



export interface IEventConcertFormModel {
	eventName: string;
	flyer: File;
	eventDate: Date;
	details: string | null;
	price: string | null;
	eventTime: string | null;
	isApproved: boolean;

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
	eventTime: string | null;
	isApproved: boolean;
}