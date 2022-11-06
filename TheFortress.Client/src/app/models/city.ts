// NTypescript generated file

import { Venue } from './venue'


export interface ICity {
		cityId: number;
	cityName: string | null;
	image: string | null;
	venues: Venue[];

}

export class City implements ICity {
	constructor(init?: Partial<ICity>) {
		Object.assign(this, init);
	}
	
	cityId: number;
	cityName: string | null;
	image: string | null;
	venues: Venue[];
}