// NTypescript generated file



export interface ICodeUser {
	codeId: number;
	userId: string;

}

export class CodeUser implements ICodeUser {
	constructor(init: Partial<ICodeUser>) {
		Object.assign(this, init);
	}
	
	codeId: number;
	userId: string;
}