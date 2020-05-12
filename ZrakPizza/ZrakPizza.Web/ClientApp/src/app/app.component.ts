import { Component, OnInit } from '@angular/core';
import { ProductService } from './services/product.service';
import { CartService } from './services/cart.service';
import { Cart } from './models/cart';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.css']
})
export class AppComponent implements OnInit {
  products$;

  constructor(
    private productService: ProductService) { }

  async ngOnInit() {
    this.products$ = this.productService.getAll(true);
  }
}
