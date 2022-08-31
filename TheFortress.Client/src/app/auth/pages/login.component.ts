import { Component, OnInit } from '@angular/core';
import { LoginDto } from 'src/app/models/login-dto';
import { AuthService } from 'src/app/services/auth.service';

@Component({
    selector: 'ui-login',
    templateUrl: './login.component.html',
    styleUrls: ['../auth.css']
})

export class LoginComponent implements OnInit {
    public login: LoginDto;
    public submitted: boolean = false;

    constructor(private _auth: AuthService,
        ) { 
        this.login = {
            username: '',
            password: ''
        }
    }

    ngOnInit() { }

    submit() {
        this.submitted = true;
        if(this.login.username ==='' || this.login.password === ''){
            return;
        }
        this._auth.login(this.login).subscribe(
            item => {
                console.log(item)
            }
        )
    }
}