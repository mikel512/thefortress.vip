import { Pipe, PipeTransform } from "@angular/core";
import { Subject } from "rxjs";

@Pipe({ name: 'base64' })
export class Base64Pipe implements PipeTransform {
    base64str: string;

    strEv = new Subject<string>();
    strObservable = this.strEv.asObservable();

    transform(value: File): string {
        if (value) {
            var reader = new FileReader();

            reader.onload = this._handleReaderLoaded.bind(this);

            reader.readAsBinaryString(value);

            this.strObservable.subscribe(
                x => {
                    const result = `data:image/png;base64, ${x}`;
                    return result;
                }
            );
        }
        return '';

    }
    _handleReaderLoaded(readerEvt) {
        var binaryString = readerEvt.target.result;
        this.strEv.next(btoa(binaryString));
    }

}