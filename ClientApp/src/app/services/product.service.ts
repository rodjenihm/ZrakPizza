import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http'
import { Product } from '../models/product';
import { share } from 'rxjs/operators';

@Injectable({
  providedIn: 'root'
})
export class ProductService {
  private url = "api/api/products";

  private products: Product[];

  constructor(private http: HttpClient) {
    this.getAll(true)
      .subscribe(products => this.products = products);
  }

  getAll(includeProductOptions) {
    return this.http.get<Product[]>(this.url, { observe: 'body', params: { "includeProductOptions": includeProductOptions } }).pipe(share());
  }

  getAllLocal() {
    return this.products;
  }
}
