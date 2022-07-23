// NTypescript generated file



export interface IArtist {
	id: number;
	name: string | null;
	biography: string | null;
	tour: string | null;
	picture: string | null;
	playlistEmbed: string | null;

}

export class Artist implements IArtist {
	constructor(init: Partial<IArtist>) {
		Object.assign(this, init);
	}
	
	id: number;
	name: string | null;
	biography: string | null;
	tour: string | null;
	picture: string | null;
	playlistEmbed: string | null;
}