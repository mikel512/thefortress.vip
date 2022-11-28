import { Component, OnInit } from '@angular/core';
import { UntypedFormControl, UntypedFormGroup, Validators } from '@angular/forms';
import { Router } from '@angular/router';
import { RetypeConfirm } from 'src/app/util/directives/retype-confirm';
import { AlertModel } from '@models/alert-model';
import { RegistrationDto } from '@models/registration-dto';
import { AuthService } from '@services/auth.service';

@Component({
    selector: 'ui-register',
    templateUrl: './register.component.html',
    styleUrls: ['../auth.css', '../../styles/app-styles.css' ]
})
export class RegisterComponent implements OnInit {
    public input: RegistrationDto = new RegistrationDto();
    public inputForm: UntypedFormGroup;
    public confirmPass: string = '';

    public error: string;
    public alert: AlertModel = new AlertModel();

    constructor(private router: Router,
        private auth: AuthService) { }

    ngOnInit() {
        this.inputForm = new UntypedFormGroup({
            email: new UntypedFormControl(this.input.email, [
                Validators.required,
                Validators.email
            ]),
            username: new UntypedFormControl(this.input.username),
            password: new UntypedFormControl(this.input.password, [
                Validators.required,
            ]),
            confirm: new UntypedFormControl(this.confirmPass, [
                Validators.required,
                RetypeConfirm('password')
            ])
        });
    }

    get email() { return this.inputForm.get('email') }
    get username() { return this.inputForm.get('username') }
    get password() { return this.inputForm.get('password') }
    get confirm() { return this.inputForm.get('confirm') }

    setModel() {
        this.input.email = this.email.value;
        this.input.password = this.password.value;
        this.input.username = this.username.value;
    }

    submit() {
        this.inputForm.markAllAsTouched();
        if (this.inputForm.invalid) {
            this.error = "One or more fields are invalid";
            return;
        }
        this.setModel();
        this.auth.register(this.input).subscribe({
            next: (item) => {
                this.alert.success = "Successful registration. Please check your email for confirmation." 
                // setTimeout(() => {
                //     this.router.navigate(['/auth/login']);

                // }, 3000);
            },
            error: err => {
                this.alert.error = "Something went wrong during registration. Please try again later."
            }
        });

    }
}