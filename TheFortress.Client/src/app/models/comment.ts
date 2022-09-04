// NTypescript generated file



export interface IComment {
	commentId: number;
	content: string;
	dateStamp: Date;
	upvotes: number;
	userName: string;

}

export class Comment implements IComment {
	constructor(init?: Partial<IComment>) {
		Object.assign(this, init);
	}
	
	commentId: number;
	content: string;
	dateStamp: Date;
	upvotes: number;
	userName: string;
}