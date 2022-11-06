import { Directive, ElementRef, Input, OnChanges, SimpleChanges } from '@angular/core';

@Directive({
  selector: '[inputIsValid]'
})
export class InputIsValidDirective implements OnChanges {
  // true if input is valid
  @Input() inputIsValid = false;
  constructor(private el: ElementRef) {
  }

  private validate() {
    if (this.inputIsValid) {
      this.el.nativeElement.classList.add('is-valid');
    }
    else {
      this.el.nativeElement.classList.remove('is-valid');

    }
  }

  ngOnChanges(changes: SimpleChanges): void {
    if (changes.inputIsValid) {
      this.validate();
    }
  }

}