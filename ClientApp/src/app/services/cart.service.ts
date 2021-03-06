import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Cart } from '../models/cart';
import { Observable } from 'rxjs';
import { share, map } from 'rxjs/operators';
import { ProductVariant } from '../models/product.variant';

@Injectable({
  providedIn: 'root'
})
export class CartService {
  private url = "api/api/carts";

  private localCart: Cart = { id: '', itemsCount: 0, itemsTotalPrice: 0, items: [] };

  constructor(private http: HttpClient) {
    this.initializeCart().subscribe(cart => this.localCart = cart);
  }

  private initializeCart(): Observable<Cart> {
    const cartId = localStorage.getItem('cartId');

    if (cartId) {
      return this.http.get<Cart>(this.url, { observe: 'body', params: { "id": cartId } }).pipe(share());
    } else {
      const newCart$ = this.http.post<Cart>(this.url + '/createCart', { observe: 'body' }).pipe(share());
      newCart$.subscribe(newCart => {
        if (newCart && newCart.id) localStorage.setItem('cartId', newCart['id']);
      });

      return newCart$;
    }
  }

  refreshCart() {
    this.initializeCart().subscribe(cart => this.localCart = cart);
  }

  getCart(): Cart {
    return this.localCart;
  }

  addToCart(productVariant: ProductVariant) {
    return this.http.post(this.url + '/addVariant', { "cartId": this.localCart.id, "productVariantId": productVariant.id }, { observe: 'response' })
      .pipe(
        map(response => {
          if (response.status === 200) {
            this.localCart.items.push(productVariant);
            this.localCart.itemsCount++;
            this.localCart.itemsTotalPrice += productVariant.price;
            return true;
          }
          return false;
        })
      )
  }

  removeFromCart(productVariant: ProductVariant) {
    const idx = this.localCart.items.findIndex(i => i.id === productVariant.id);
    return this.http.post(this.url + '/removeVariant', { "cartId": this.localCart.id, "productVariantId": productVariant.id }, { observe: 'response' })
      .pipe(
        map(response => {
          if (response.status === 200) {
            this.localCart.items.splice(idx, 1);
            this.localCart.itemsCount--;
            this.localCart.itemsTotalPrice -= productVariant.price;
            return true;
          }
          return false;
        })
      )
  }

  clearCart() {
    return this.http.post(this.url + '/clearCart', { "cartId": this.localCart.id }, { observe: 'response' })
      .pipe(
        map(response => {
          if (response.status === 200) {
            this.localCart.items = [];
            this.localCart.itemsCount = 0;
            this.localCart.itemsTotalPrice = 0;
            return true;
          }
          return false;
        })
      )
  }
}

