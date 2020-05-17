import { SignalRService } from './services/signal-r.service';
import { Component, OnInit } from '@angular/core';
import { ProductService } from './services/product.service';
import { CartService } from './services/cart.service';
import { Title } from '@angular/platform-browser';


@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.css']
})
export class AppComponent implements OnInit {
  private appTitle = "Zrak Pizza";

  constructor(
    private productService: ProductService,
    private cartService: CartService,
    private titleService: Title,
    private signalRService: SignalRService) {
  }

  ngOnInit() {
    this.titleService.setTitle(this.appTitle);
    this.signalRService.startConnection();
    this.signalRService.addOnUpdateCartListener((cartId) => {
      if (this.cartService.getCart().id === cartId) {
        this.cartService.refreshCart();
      }
    });
  }
}
