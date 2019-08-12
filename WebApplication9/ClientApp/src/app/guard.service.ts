import { Injectable } from '@angular/core';
import { CanActivate, Router } from '@angular/router';
import { JwtHelperService } from "@auth0/angular-jwt";
import { AuthService } from './auth.service';

@Injectable({
  providedIn: 'root'
})
export class GuardService implements CanActivate {

  constructor(private jwtHelper: JwtHelperService, private router: Router, private auth: AuthService) {
    console.log("guard service constructor")
  }
  canActivate() {
    console.log("canactivate?")
    var token = this.auth.token.token;
    console.log(token)

    if (token && !this.jwtHelper.isTokenExpired(token)) {
      return true;
    }
    this.router.navigate(["login"]);
    return false;
  }
}
