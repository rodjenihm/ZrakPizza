import { Component, OnInit, Input } from '@angular/core';
import { Product } from '../models/product';
import { ProductOption } from '../models/product.option';
import { CartService } from '../services/cart.service';
import { ProductVariant } from '../models/product.variant';

@Component({
  selector: 'app-product',
  templateUrl: './product.component.html',
  styleUrls: ['./product.component.css']
})
export class ProductComponent implements OnInit {
  @Input() product: Product;

  selectedOption: ProductOption;

  constructor(private cartService: CartService) {
  }

  ngOnInit() {
    this.selectedOption = this.product.productOptions[0];
    this.cartService.getCart().items.reduce((acc, cur) => cur.id === this.selectedOption.id ? ++acc : acc, 0)
  }

  addToCart() {
    const productVariant: ProductVariant = {
      id: this.selectedOption.id,
      name: this.product.name,
      description: this.product.description,
      category: this.product.category,
      imageUrl: this.product.imageUrl,
      variantDescription: this.selectedOption.description,
      price: this.selectedOption.price
    };

    this.cartService.addToCart(productVariant);
  }

  removeFromCart() {
    const productVariant: ProductVariant = {
      id: this.selectedOption.id,
      name: this.product.name,
      description: this.product.description,
      category: this.product.category,
      imageUrl: this.product.imageUrl,
      variantDescription: this.selectedOption.description,
      price: this.selectedOption.price
    };

    this.cartService.removeFromCart(productVariant);
  }

  selectedOptionInCartCount() {
    return this.cartService.getCart().items.reduce((acc, cur) => cur.id === this.selectedOption.id ? ++acc : acc, 0);
  }
}
