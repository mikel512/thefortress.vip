import { Injectable } from '@angular/core';
import { Subject } from 'rxjs';

@Injectable()
export class SearchBarService {
    private _search = new Subject<boolean>();
    public search$ = this._search.asObservable();

    private _city = new Subject<string>();
    public city$ = this._city.asObservable();

    private _isEvent = new Subject<boolean>();
    public isEvent$ = this._isEvent.asObservable();

    constructor() { }

    public emitSearch(val: boolean) {
        this._search.next(val);
    }

    public emitCity(city: string) {
        console.log(city);
        this._city.next(city);
    }

    public emitIsEvent(isEvent: boolean) {
        this._isEvent.next(isEvent);
    }
    
}