// NTypescript generated file



export interface IAppUserDto {
	userName: string;
	email: string;
	mailingListEnabled: boolean;

}

export class AppUserDto implements IAppUserDto {
	constructor(init?: Partial<IAppUserDto>) {
		Object.assign(this, init);
	}
	
	userName: string;
	email: string;
	mailingListEnabled: boolean;
}