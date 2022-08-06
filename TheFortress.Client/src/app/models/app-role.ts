// NTypescript generated file



export interface IAppRole {
	roleId: string;
	roleName: string;

}

export class AppRole implements IAppRole {
	constructor(init: Partial<IAppRole>) {
		Object.assign(this, init);
	}
	
	roleId: string;
	roleName: string;
}