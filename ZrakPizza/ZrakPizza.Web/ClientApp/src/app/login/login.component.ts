import { Component, OnInit } from '@angular/core';
import { FormGroup, FormControl, Validators, FormBuilder } from '@angular/forms';
import { ActivatedRoute, Router } from '@angular/router';
import { Credentials } from '../models/credentials';
import { AuthService } from '../services/auth.service';

@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.css']
})
export class LoginComponent implements OnInit {
  loginForm: FormGroup;
  credentials: Credentials = { userName: '', password: '' };

  get username() { return this.loginForm.get('username'); }
  get password() { return this.loginForm.get('password'); }

  constructor(
    private authService: AuthService,
    private router: Router,
    private formBuilder: FormBuilder,
    private route: ActivatedRoute) { }

  ngOnInit(): void {
    this.loginForm = this.formBuilder.group({
      username: new FormControl(this.credentials.userName, [
        Validators.required
      ]),
      password: new FormControl(this.credentials.password, [
        Validators.required
      ])
    });
  }

  login(credentials: Credentials) {
    this.authService.authenticate(credentials)
      .subscribe(result => {
        if (result) {
          const returnUrl = this.route.snapshot.queryParamMap.get('returnUrl');
          this.router.navigate([returnUrl ? returnUrl : '']);
        }
        else {
          console.log('Login failed!');
        }
      })
  }

}
