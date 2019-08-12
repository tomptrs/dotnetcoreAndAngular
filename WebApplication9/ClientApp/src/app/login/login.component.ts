import { Component, OnInit } from '@angular/core';
import { AuthService } from '../auth.service';
import { Router } from '@angular/router';

@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.css']
})
export class LoginComponent implements OnInit {

  constructor(private auth: AuthService, private route: Router) { }


  ngOnInit() {

  }

  login(form) {

    this.auth.Login(form.value).subscribe(result => {
      console.log(result)
      this.auth.token = result;

      //navigate to project data
      this.route.navigate(["/project"]);
    }, error => console.error(error));
  
  }

}
