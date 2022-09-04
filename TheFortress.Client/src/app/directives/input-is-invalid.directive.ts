import { Directive, ElementRef, Input, OnChanges, SimpleChanges } from '@angular/core';

@Directive({
  selector: '[inputIsInvalid]'
})
export class InputIsInvalidDirective implements OnChanges {
  // true if input is valid
  @Input() inputIsInvalid = false;
  constructor(private el: ElementRef) {
  }

  private validate() {
    if (this.inputIsInvalid) {
      this.el.nativeElement.classList.add('is-invalid');
    }
    else {
      this.el.nativeElement.classList.remove('is-invalid');

    }
  }

  ngOnChanges(changes: SimpleChanges): void {
    if (changes.inputIsInvalid) {
      this.validate();
    }
  }

}
