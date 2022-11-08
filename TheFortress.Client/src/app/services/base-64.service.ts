import { Subject } from "rxjs";

export class Base64Service {
    base64str: string;

    private strEv = new Subject<string>();
    public base64Observable = this.strEv.asObservable();

    constructor() { }

    /**
     * Converts the image to base 64. The value will be emitted in the class' base64Observable.
     * @param value The file
     * @returns  void
     */
    convert(value: File) {
        if (value) {
            var reader = new FileReader();

            reader.onload = this._handleReaderLoaded.bind(this);

            reader.readAsBinaryString(value);
        }
        return '';

    }
    _handleReaderLoaded(readerEvt) {
        var binaryString = readerEvt.target.result;
        this.strEv.next(`data:image/png;base64, ${btoa(binaryString)}`);
    }

}