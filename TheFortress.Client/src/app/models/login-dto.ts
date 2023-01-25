// NTypescript generated file



export interface ILoginDto {
	username: string;
	password: string;
	code: string | null;

}

export class LoginDto implements ILoginDto {
	constructor(init?: Partial<ILoginDto>) {
		Object.assign(this, init);
	}
	
	username: string;
	password: string;
	code: string | null;
}