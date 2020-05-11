import { Component, OnInit, Input } from '@angular/core';
import { Product } from '../models/product';
import { ProductOption } from '../models/product.option';

@Component({
  selector: 'app-product',
  templateUrl: './product.component.html',
  styleUrls: ['./product.component.css']
})
export class ProductComponent implements OnInit {
  @Input() product: Product;

  selectedOption: ProductOption;

  constructor() { }

  ngOnInit(): void {
    this.selectedOption = this.product.productOptions[0];
  }

  addToCart() {
  }
}
