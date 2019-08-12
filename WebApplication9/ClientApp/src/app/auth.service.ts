import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';

@Injectable({
  providedIn: 'root'
})
export class AuthService {

  public token: any;

  constructor(private http: HttpClient) {

  }

  Login(user) {
    return this.http.post('https://localhost:44372/api/account/Login', user);
  }


}
