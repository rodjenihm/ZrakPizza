import { Component, OnInit } from '@angular/core';
import { FormGroup, FormBuilder, FormControl, Validators } from '@angular/forms';

@Component({
  selector: 'app-register',
  templateUrl: './register.component.html',
  styleUrls: ['./register.component.css']
})
export class RegisterComponent implements OnInit {
  registerForm: FormGroup;
  user = { username: '', fullName: '', password: '' };

  constructor(
    private formBuilder: FormBuilder) { }

  get username() { return this.registerForm.get('username'); }
  get password() { return this.registerForm.get('password'); }

  ngOnInit(): void {
    this.registerForm = this.formBuilder.group({
      username: new FormControl(this.user.username, [
        Validators.required,
        Validators.minLength(4)
      ]),
      fullName: new FormControl(this.user.fullName),
      password: new FormControl(this.user.password, [
        Validators.required,
        Validators.minLength(6)
      ])
    });
  }

  register(userData) {
  }
}
