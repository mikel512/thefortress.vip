// NTypescript generated file



export interface ILinkType {
	linkTypeId: number;
	linkType1: string;
	faImgClass: string | null;

}

export class LinkType implements ILinkType {
	constructor(init?: Partial<ILinkType>) {
		Object.assign(this, init);
	}
	
	linkTypeId: number;
	linkType1: string;
	faImgClass: string | null;
}