import { Component, OnInit } from '@angular/core';
import { AlertModel } from '@models/alert-model';
import { AppUserDto } from '@models/app-user-dto';
import { AccountService } from '@services/account.service';

@Component({
    selector: 'app-account-info',
    templateUrl: 'account-info.component.html'
})

export class AccountInfoComponent implements OnInit {
    appUser: AppUserDto = new AppUserDto();
    alert: AlertModel = new AlertModel();

    constructor(private account: AccountService) { }

    ngOnInit() {
        this.reload();
    }

    reload() {
        this.account.getUserInfo().subscribe({
            next: x => {
                this.appUser = x;
            }
        });
    }

    submit() {
        this.account.updateUserInfo(this.appUser).subscribe({
            next: x => {
                this.alert.success = 'User info updated';
                this.appUser = x;
            }
        });
    }
}