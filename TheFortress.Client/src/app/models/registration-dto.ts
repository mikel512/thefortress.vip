// NTypescript generated file



export interface IRegistrationDto {
	username: string | null;
	email: string;
	password: string;

}

export class RegistrationDto implements IRegistrationDto {
	constructor(init?: Partial<IRegistrationDto>) {
		Object.assign(this, init);
	}
	
	username: string | null;
	email: string;
	password: string;
}