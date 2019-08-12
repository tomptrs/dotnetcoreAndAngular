import { Injectable } from '@angular/core';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { AuthService } from './auth.service';

@Injectable({
  providedIn: 'root'
})
export class DataService {

  constructor(private http: HttpClient, private auth: AuthService) {
  }

  GetAllProjects() {
    return this.http.get("https://localhost:44372/api/projects", {
      headers: new HttpHeaders({
        "Authorization": "Bearer " + this.auth.token.token,
        "Content-Type": "application/json"
      })
    })
    
  }
}
