// NTypescript generated file



export interface ICityFormModel {
	cityName: string;
	image: File;

}

export class CityFormModel implements ICityFormModel {
	constructor(init?: Partial<ICityFormModel>) {
		Object.assign(this, init);
	}
	
	cityName: string;
	image: File;
}