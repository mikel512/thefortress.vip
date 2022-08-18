// NTypescript generated file



export interface IAppUser {
	userId: number;
	email: string | null;
	displayName: string | null;
	dateAdded: Date | null;
	dateModified: Date | null;
	objectId: string | null;

}

export class AppUser implements IAppUser {
	constructor(init: Partial<IAppUser>) {
		Object.assign(this, init);
	}
	
	userId: number;
	email: string | null;
	displayName: string | null;
	dateAdded: Date | null;
	dateModified: Date | null;
	objectId: string | null;
}