import { CommonModule } from '@angular/common';
import { NgModule } from '@angular/core';
import { InputIsInvalidDirective } from './input-is-invalid.directive';
import { InputIsValidDirective } from './input-is-valid.directive';
import { RetypeConfirm } from './retype-confirm';


@NgModule({
    declarations: [
        InputIsInvalidDirective,
        InputIsValidDirective
    ],
    imports: [CommonModule],
    exports: [
        InputIsInvalidDirective,
        InputIsValidDirective
    ],
    providers: [],
})
export class MyDirectivesModule {}
