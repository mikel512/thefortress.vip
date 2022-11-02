import { AbstractControl, UntypedFormControl, ValidationErrors, ValidatorFn } from "@angular/forms";

export function RetypeConfirm(controlName: string): ValidatorFn{
    return (control: UntypedFormControl): ValidationErrors | null => {
        if (!control || !control.parent) {
            return null;
        }

        return control.parent.get(controlName).value === control.value ? null : { mismatch: true };
    }

} 