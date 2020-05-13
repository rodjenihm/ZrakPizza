import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http'
import { Product } from '../models/product';
import { share } from 'rxjs/operators';

@Injectable({
  providedIn: 'root'
})
export class ProductService {
  private url = "api/products";

  constructor(private http: HttpClient) { }

  getAll(includeProductOptions) {
    return this.http.get<Product[]>(this.url, { observe: 'body', params: { "includeProductOptions": includeProductOptions } }).pipe(share());
  }
}
