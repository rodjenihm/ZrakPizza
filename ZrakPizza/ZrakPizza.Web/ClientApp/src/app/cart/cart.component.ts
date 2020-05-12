import { Component, OnInit } from '@angular/core';
import { CartService } from '../services/cart.service';

@Component({
  selector: 'app-cart',
  templateUrl: './cart.component.html',
  styleUrls: ['./cart.component.css']
})
export class CartComponent implements OnInit {
  cartService: CartService;

  constructor(cartService: CartService) {
    this.cartService = cartService;
  }

  ngOnInit(): void {
  }

  get cart() {
    return this.cartService.getCart();
  }

  clearCart() {
    this.cartService.clearCart();
  }

  checkout() {
  }
}
