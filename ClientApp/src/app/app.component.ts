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
    private titleService: Title) {
  }

  ngOnInit() {
    this.titleService.setTitle(this.appTitle);
  }
}
