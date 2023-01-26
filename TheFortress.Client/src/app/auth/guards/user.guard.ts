import { Injectable } from '@angular/core';
import { ActivatedRouteSnapshot, CanActivate, RouterStateSnapshot } from '@angular/router';
import { AuthService } from '@services/auth.service';

@Injectable({providedIn: 'root'})
export class UserGuard implements CanActivate {
    constructor(private auth: AuthService) { }

    canActivate(route: ActivatedRouteSnapshot, state: RouterStateSnapshot) {
        return this.auth.isLoggedIn();
    }
}