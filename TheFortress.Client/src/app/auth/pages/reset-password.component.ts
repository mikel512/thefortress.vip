import { Component, OnInit } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { AlertModel } from '@models/alert-model';
import { LoginDto } from '@models/login-dto';
import { AuthService } from '@services/auth.service';

@Component({
    selector: 'app-reset-password',
    templateUrl: 'reset-password.component.html'
})

export class ResetPasswordComponent implements OnInit {
    public forgotPassword: boolean = true;
    public alert: AlertModel = new AlertModel();
    public login: LoginDto;
    public submitted: boolean = false;

    constructor(private auth: AuthService,
        private activatedRoute: ActivatedRoute,
        private router: Router
    ) {
        this.login = {
            username: '',
            password: ''
        }
    }

    ngOnInit() {

        const action = this.activatedRoute.snapshot.url[2];
        if(!action){
            this.forgotPassword = true;
        } else {
            this.forgotPassword = false;
        }
    }

    submit() {
        this.submitted = true;
        if (this.login.username === '') {
            this.login.username = '';
            this.alert.error = 'Error validating one or more fields';
            return;
        }
    }
}