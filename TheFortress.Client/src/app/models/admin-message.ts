// NTypescript generated file



export interface IAdminMessage {
	adminMessageId: number;
	sender: string;
	message: string;
	date: Date | null;
	subject: string;

}

export class AdminMessage implements IAdminMessage {
	constructor(init?: Partial<IAdminMessage>) {
		Object.assign(this, init);
	}
	
	adminMessageId: number;
	sender: string;
	message: string;
	date: Date | null;
	subject: string;
}