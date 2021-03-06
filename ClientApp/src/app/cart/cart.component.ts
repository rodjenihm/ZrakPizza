import { SignalRService } from './../services/signal-r.service';
import { Component, OnInit } from '@angular/core';
import { CartService } from '../services/cart.service';
import { NotificationService } from '../services/notification.service';

@Component({
  selector: 'app-cart',
  templateUrl: './cart.component.html',
  styleUrls: ['./cart.component.css']
})
export class CartComponent implements OnInit {
  cartService: CartService;

  constructor(
    cartService: CartService,
    private notificationService: NotificationService,
    private signalRService: SignalRService) {
    this.cartService = cartService;
  }

  ngOnInit(): void {
  }

  get cart() {
    return this.cartService.getCart();
  }

  clearCart() {
    this.cartService.clearCart().subscribe(result => {
      if (result) {
        this.signalRService.notifyUpdateCart(this.cartService.getCart().id);
        this.notificationService.showSuccess('', 'Cart cleared successfully');
      }
      else this.notificationService.showSuccess('Failed to clear cart. Try again later.', 'Error');
    });
  }
}
