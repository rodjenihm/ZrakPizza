import { Component, OnInit } from '@angular/core';
import { FormGroup, FormControl, Validators, FormBuilder } from '@angular/forms';
import { ActivatedRoute, Router } from '@angular/router';

@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.css']
})
export class LoginComponent implements OnInit {

  loginForm: FormGroup;
  credentials = { username: '', password: '' };

  get username() { return this.loginForm.get('username'); }
  get password() { return this.loginForm.get('password'); }

  constructor(
    //private authService: AuthService,
    private router: Router,
    private formBuilder: FormBuilder,
    private route: ActivatedRoute) { }

  ngOnInit(): void {
    this.loginForm = this.formBuilder.group({
      username: new FormControl(this.credentials.username, [
        Validators.required
      ]),
      password: new FormControl(this.credentials.password, [
        Validators.required
      ])
    });
  }

  login(credentials) {
    //this.authService.authenticate(credentials)
    //  .subscribe(result => {
    //    if (result) {
    //      let returnUrl = this.route.snapshot.queryParamMap.get('returnUrl');
    //      this.router.navigate([returnUrl ? returnUrl : '']);
    //    }
    //    else {
    //      this.notificationService.showError('Login failed!', "error");
    //    }
    //  })
  }

}
