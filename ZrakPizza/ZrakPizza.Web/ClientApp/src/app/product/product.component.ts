import { Component, OnInit, Input } from '@angular/core';
import { Product } from '../models/product';
import { ProductOption } from '../models/product.option';
import { CartService } from '../services/cart.service';
import { Cart } from '../models/cart';
import { ProductVariant } from '../models/product.variant';

@Component({
  selector: 'app-product',
  templateUrl: './product.component.html',
  styleUrls: ['./product.component.css']
})
export class ProductComponent implements OnInit {
  @Input() product: Product;

  selectedOption: ProductOption;

  cart: Cart;

  constructor(private cartService: CartService) {
  }

  ngOnInit() {
    this.selectedOption = this.product.productOptions[0];
    this.cart = this.cartService.getCart();
  }

  addToCart() {
    const productVariant: ProductVariant = {
      id: this.selectedOption.id,
      name: this.product.name,
      description: this.product.description,
      category: this.product.category,
      imageUrl: this.product.imageUrl,
      variantdescription: this.selectedOption.description,
      price: this.selectedOption.price
    };

    this.cartService.addToCart(productVariant);
  }
}
