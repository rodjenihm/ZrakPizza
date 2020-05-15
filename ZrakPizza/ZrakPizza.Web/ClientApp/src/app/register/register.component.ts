import { Component, OnInit } from '@angular/core';
import { FormGroup, FormBuilder, FormControl, Validators } from '@angular/forms';
import { Router } from '@angular/router';
import { NotificationService } from '../services/notification.service';
import { UserService } from '../services/user.service';

@Component({
  selector: 'app-register',
  templateUrl: './register.component.html',
  styleUrls: ['./register.component.css']
})
export class RegisterComponent implements OnInit {
  registerForm: FormGroup;
  user = { username: '', name: '', password: '' };

  constructor(
    private userService: UserService,
    private notificationService: NotificationService,
    private router: Router,
    private formBuilder: FormBuilder) { }

  get username() { return this.registerForm.get('username'); }
  get name() { return this.registerForm.get('name'); }
  get password() { return this.registerForm.get('password'); }

  ngOnInit(): void {
    this.registerForm = this.formBuilder.group({
      username: new FormControl(this.user.username, [
        Validators.required,
        Validators.minLength(4)
      ]),
      name: new FormControl(this.user.name, [
        Validators.required
      ]),
      password: new FormControl(this.user.password, [
        Validators.required,
        Validators.minLength(6)
      ])
    });
  }

  register(userData) {
    this.userService.create(userData).subscribe(result => {
      if (result) {
        this.notificationService.showSuccess('Account successfully created. You can now log in.', 'Registration successful')
        this.router.navigate(['/login']);
      } else {
        this.notificationService.showError('Smething went wrong. Try again later.', 'Error');
      }
    }, error => this.notificationService.showError(error.error['errorMessage'], 'Error'));
  }
}
