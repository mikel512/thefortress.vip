import { Component, OnInit } from '@angular/core';
import { FormControl, FormGroup, Validators } from '@angular/forms';
import { Router } from '@angular/router';
import { RetypeConfirm } from 'src/app/directives/retype-confirm';
import { AlertModel } from 'src/app/models/alert-model';
import { RegistrationDto } from 'src/app/models/registration-dto';
import { AuthService } from 'src/app/services/auth.service';

@Component({
    selector: 'ui-register',
    templateUrl: './register.component.html',
    styleUrls: ['../auth.css']
})
export class RegisterComponent implements OnInit {
    public input: RegistrationDto = new RegistrationDto();
    public inputForm: FormGroup;
    public confirmPass: string = '';

    public error: string;
    public alert: AlertModel = new AlertModel();

    constructor(private router: Router,
        private auth: AuthService) { }

    ngOnInit() {
        this.inputForm = new FormGroup({
            email: new FormControl(this.input.email, [
                Validators.required,
                Validators.email
            ]),
            username: new FormControl(this.input.username),
            password: new FormControl(this.input.password, [
                Validators.required,
            ]),
            confirm: new FormControl(this.confirmPass, [
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
                this.alert.success = "Successful registration. Redirecting to login...";
                setTimeout(() => {
                    this.router.navigate(['/auth/login']);

                }, 3000);
            }
        });

    }
}