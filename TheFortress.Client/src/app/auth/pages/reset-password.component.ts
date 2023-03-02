import { Component, OnInit } from '@angular/core';
import { UntypedFormControl, UntypedFormGroup, Validators } from '@angular/forms';
import { ActivatedRoute, Router } from '@angular/router';
import { RetypeConfirm } from '@directives/retype-confirm';
import { AlertModel } from '@models/alert-model';
import { LoginDto } from '@models/login-dto';
import { AuthService } from '@services/auth.service';

@Component({
    selector: 'app-reset-password',
    templateUrl: 'reset-password.component.html'
})

export class ResetPasswordComponent implements OnInit {
    public forgotPassword: boolean = false;
    public alert: AlertModel = new AlertModel();
    public login: LoginDto;
    public submitted: boolean = false;
    public inputForm: UntypedFormGroup;
    public confirmPass: string;

    constructor(private auth: AuthService,
        private activatedRoute: ActivatedRoute,
        private router: Router
    ) {
        this.reset();
    }

    reset() {
        this.login = {
            username: '',
            password: '',
            code: ''
        }
        this.submitted = false;
        if (this.inputForm) {
            this.inputForm.reset();
        }

    }

    ngOnInit() {
        const action = this.activatedRoute.snapshot.url[1];
        const email = this.activatedRoute.snapshot.url[2];
        this.login.username = email?.path;
        this.login.code = action?.path;

        if (!action) {
            this.forgotPassword = true;
        } else {
            this.forgotPassword = false;
            this.inputForm = new UntypedFormGroup({
                email: new UntypedFormControl({ value: this.login.username, disabled: true}, [
                    Validators.required,
                    Validators.email
                ]),
                password: new UntypedFormControl(this.login.password, [
                    Validators.required,
                ]),
                confirm: new UntypedFormControl(this.confirmPass, [
                    Validators.required,
                    RetypeConfirm('password')
                ])
            });
        }
    }

    get email() { return this.inputForm.get('email') }
    get password() { return this.inputForm.get('password') }
    get confirm() { return this.inputForm.get('confirm') }

    updatePassword() {
        this.login.password = this.password.value;
        const success= 'Password successfully reset. Redirecting'
        this.auth.resetPassword(this.login).subscribe({
            next: val => {
                this.alert.success = success;
            },
            error: () => {
                this.alert.success = success;
            },
            complete: () => {
                setTimeout(() => {
                    this.router.navigate(['/auth/login']);

                }, 3000);
            }
        })
    }

    submit() {
        this.submitted = true;
        if (this.login.username === '') {
            this.login.username = '';
            this.alert.error = 'Error validating one or more fields';
            return;
        }
        const success = 'An email has been sent to the adress with instructions to reset the password.';

        this.auth.forgotPassword(this.login.username).subscribe({
            next: val => {
                this.alert.success =  success;           },
            error: () => {
                this.alert.success = success;
            },
            complete: () => {
                this.reset();
            }
        });
    }
}