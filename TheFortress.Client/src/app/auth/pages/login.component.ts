import { Component, OnInit } from '@angular/core';
import { AlertModel } from 'src/app/models/alert-model';
import { LoginDto } from 'src/app/models/login-dto';
import { AuthService } from 'src/app/services/auth.service';

@Component({
    selector: 'ui-login',
    templateUrl: './login.component.html',
})

export class LoginComponent implements OnInit {
    public login: LoginDto;
    public submitted: boolean = false;

    public alert: AlertModel = new AlertModel();

    constructor(private _auth: AuthService,) {
        this.login = {
            username: '',
            password: ''
        }
    }

    ngOnInit() {

    }

        this.title = 'Forgot Password';
    }

        this.title = 'Forgot Password';
    }

        this.title = 'Forgot Password';
    }

        this.title = 'Forgot Password';
    }

        this.title = 'Forgot Password';
    }
        if(this.login.username ==='' || this.login.password === ''){
        this.title = 'Forgot Password';
    }

        this.title = 'Forgot Password';
    }

    submit() {
        this.submitted = true;
        if (this.login.username === '' || this.login.password === '') {
            this.login.username = '';
            this.alert.error = 'Error validating one or more fields';
            return;
        }
        this._auth.login(this.login).subscribe({
            next: (item) => {
                console.log(item)
            },
            error: (err) => {
                this.alert.error = err.error.errorMessage;
            }
        });
    }
}