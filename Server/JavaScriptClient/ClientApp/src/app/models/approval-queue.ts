// NTypescript generated file



export interface IApprovalQueue {
	queueId: number;

}

export class ApprovalQueue implements IApprovalQueue {
	constructor(init: Partial<IApprovalQueue>) {
		Object.assign(this, init);
	}
	
	queueId: number;
}