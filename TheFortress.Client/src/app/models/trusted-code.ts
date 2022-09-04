// NTypescript generated file



export interface ITrustedCode {
	trustedCodeId: number;
	codeString: string;
	timesUsed: number;
	maxTimesUsed: number | null;

}

export class TrustedCode implements ITrustedCode {
	constructor(init?: Partial<ITrustedCode>) {
		Object.assign(this, init);
	}
	
	trustedCodeId: number;
	codeString: string;
	timesUsed: number;
	maxTimesUsed: number | null;
}