import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';

@Injectable({ providedIn: 'root' })
export class AuthService {
    public userClaims = null;

    constructor(private httpClient: HttpClient) {
    }


    async getHeader(): Promise<any> {
        var req = new Request("/bff/user", {
            headers: new Headers({
                "X-CSRF": "1",
            }),
        });

        try {
            var resp = await fetch(req);
            if (resp.ok) {
                this.userClaims = await resp.json();

                console.log("user logged in", this.userClaims);
            } else if (resp.status === 401) {
                console.log("user not logged in");
            }
            return this.userClaims;
        } catch (e) {
            console.log("error checking user status");
            return null;
        }
    };

    getClaim(type: string): string {
        return this.userClaims.find(
            (claim) => claim.type === type
        ).value;
    }

    logout() {
        if (this.userClaims) {
            var logoutUrl = this.userClaims.find(
                (claim) => claim.type === "bff:logout_url"
            ).value;
            window.location.href = logoutUrl;
        } else {
            window.location.href = "/bff/logout";
        }
    }

    reduce(arr: any): Map<string, string> {
        return new Map(arr.map(obj => [obj.type, obj.value]));
    }
}