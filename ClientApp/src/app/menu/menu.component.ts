import { Component, OnInit } from '@angular/core';
import { ProductService } from '../services/product.service';

@Component({
  selector: 'app-menu',
  templateUrl: './menu.component.html',
  styleUrls: ['./menu.component.css']
})
export class MenuComponent implements OnInit {
  productService: ProductService;

  constructor(productService: ProductService) {
    this.productService = productService;
  }

  ngOnInit() {
  }
}
