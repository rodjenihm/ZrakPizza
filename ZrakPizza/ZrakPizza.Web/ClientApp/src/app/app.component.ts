import { Component, OnInit } from '@angular/core';
import { ProductService } from './services/product.service';
import { CartService } from './services/cart.service';


@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.css']
})
export class AppComponent implements OnInit {
  products$;

  constructor(
    private productService: ProductService,
    private cartService: CartService) {
  }

  ngOnInit() {
  }
}
