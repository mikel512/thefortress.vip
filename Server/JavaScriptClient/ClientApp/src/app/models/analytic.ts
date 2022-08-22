// NTypescript generated file



export interface IAnalytic {
	analyticsId: number;
	ipAddress: string | null;
	dateAdded: Date | null;
	location: string | null;

}

export class Analytic implements IAnalytic {
	constructor(init: Partial<IAnalytic>) {
		Object.assign(this, init);
	}
	
	analyticsId: number;
	ipAddress: string | null;
	dateAdded: Date | null;
	location: string | null;
}