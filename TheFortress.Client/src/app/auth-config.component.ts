import { Configuration, LogLevel } from "@azure/msal-browser";
import { environment } from "src/environments/environment";

const isIE = window.navigator.userAgent.indexOf("MSIE ") > -1 || window.navigator.userAgent.indexOf("Trident/") > -1;

export const b2cPolicies = {
     names: {
         signUpSignIn: "B2C_1_signupsignin",
         editProfile: "B2C_1_editprofile"
     },
     authorities: {
         signUpSignIn: {
             authority: 'https://thefortressvip.b2clogin.com/thefortressvip.onmicrosoft.com/b2c_1_signupsignin',
         },
         editProfile: {
             authority: "https://thefortressvip.b2clogin.com/thefortressvip.onmicrosoft.com/B2C_1_editprofile"
         }
     },
     authorityDomain: "thefortressvip.b2clogin.com"
 };

export const MsalConfig: Configuration = {

    auth: {
        clientId: environment.clientId,
        authority: b2cPolicies.authorities.signUpSignIn.authority,
        knownAuthorities: [b2cPolicies.authorityDomain],
        redirectUri: '/',
        postLogoutRedirectUri: '/',
        navigateToLoginRequestUrl: true,
    },
    cache: {
        cacheLocation: 'localStorage',
        storeAuthStateInCookie: isIE,
    },
    system: {
        loggerOptions: {
            loggerCallback(logLevel: LogLevel, message: string) {
                console.log(message);
            },
            logLevel: LogLevel.Verbose,
            piiLoggingEnabled: false
        }
    }
};
export const protectedResources = {
  todoListApi: {
    endpoint: "https://localhost:4200/api/EventConcert",
    scopes: ["https://thefortressvip.onmicrosoft.com/93c6bc24-6617-4281-a8ac-e7f4e81dcf78/tasks.read"],
  },
}
export const loginRequest = {
  scopes: []
};