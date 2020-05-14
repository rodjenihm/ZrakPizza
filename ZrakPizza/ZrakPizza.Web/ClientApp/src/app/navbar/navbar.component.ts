import { Component, OnInit } from '@angular/core';
import { CartService } from '../services/cart.service';
import { Cart } from '../models/cart';
import { AuthService } from '../services/auth.service';
import { Router } from '@angular/router';

@Component({
  selector: 'app-navbar',
  templateUrl: './navbar.component.html',
  styleUrls: ['./navbar.component.css']
})
export class NavbarComponent implements OnInit {
  cart: Cart;

  authService: AuthService;
  cartService: CartService;

  constructor(
    authService: AuthService,
    cartService: CartService,
    private router: Router) {
    this.authService = authService;
    this.cartService = cartService;
  }

  ngOnInit() {
    this.cart = this.cartService.getCart();
  }

  logout() {
    this.authService.deauthenticate();
    this.router.navigate(['/']);
  }

}
