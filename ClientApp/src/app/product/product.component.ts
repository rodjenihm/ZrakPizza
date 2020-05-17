import { SignalRService } from './../services/signal-r.service';
import { Component, OnInit, Input } from '@angular/core';
import { Product } from '../models/product';
import { ProductOption } from '../models/product.option';
import { CartService } from '../services/cart.service';
import { ProductVariant } from '../models/product.variant';
import { NotificationService } from '../services/notification.service';

@Component({
  selector: 'app-product',
  templateUrl: './product.component.html',
  styleUrls: ['./product.component.css']
})
export class ProductComponent implements OnInit {
  @Input() product: Product;

  selectedOption: ProductOption;

  constructor(
    private cartService: CartService,
    private notificationService: NotificationService,
    private signalRService: SignalRService) {
  }

  ngOnInit() {
    this.selectedOption = this.product.productOptions[0];
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

    this.cartService.addToCart(productVariant).subscribe(result => {
      if (result) {
        this.signalRService.notifyUpdateCart(this.cartService.getCart().id);
        this.notificationService.showSuccess(`${this.product.name}, ${this.selectedOption.description}`, 'Added to cart');
      }
      else this.notificationService.showError('Failed to add product to cart', 'Error');
    });
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

    const idx = this.cartService.getCart().items.findIndex(i => i.id === productVariant.id);
    if (idx > -1) {
      this.cartService.removeFromCart(productVariant).subscribe(result => {
        if (result) {
          this.signalRService.notifyUpdateCart(this.cartService.getCart().id);
          this.notificationService.showSuccess(`${this.product.name}, ${this.selectedOption.description}`, 'Removed from cart');
        }
        else this.notificationService.showError('Failed to remove product from cart', 'Error');
      });
    }
  }

  selectedOptionInCartCount() {
    return this.cartService.getCart().items.reduce((acc, cur) => cur.id === this.selectedOption.id ? ++acc : acc, 0);
  }
}
