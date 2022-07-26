import { FormControl } from "@angular/forms";

export function fileTypeValidator(types: string[]) {
    types = types.map(x => {
        let result = x.toLowerCase();
        return result.trim();
    });
    return function (control: FormControl) {
        const file = control.value;
        if (file) {
            const extension = file?.name?.split('.')[1].toLowerCase();
            if (!types.includes(extension?.toLowerCase())) {
                return {
                    requiredFileType: true
                };
            }

            return null;
        }

        return null;
    };
}