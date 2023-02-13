import { Component, OnInit } from '@angular/core';
import { AlertModel } from '@models/alert-model';
import { AppUserDto } from '@models/app-user-dto';
import { AccountService } from '@services/account.service';
import { AuthService } from '@services/auth.service';

@Component({
    selector: 'app-change-password',
    templateUrl: 'change-password.component.html'
})

export class ChangePasswordComponent implements OnInit {

    appUser: AppUserDto = new AppUserDto();
    alert: AlertModel = new AlertModel();
    confirmPassword: string  = '';

    constructor(private account: AccountService,
        private auth: AuthService) { }

    ngOnInit() {
    }

    submit() {
        if(this.confirmPassword !== this.appUser.password){
            this.alert.error = `Passwords do not match`;
        }
        this.account.changePassword(this.appUser).subscribe({
            next: x => {
                this.alert.success = 'Password updated, redirecting to login';
                this.auth.logout(['/auth/login']);
            }
        });
    }
}