import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http'

@Injectable({
  providedIn: 'root'
})
export class ProductService {
  private url = "api/products";

  constructor(private http: HttpClient) { }

  getAll(includeProductOptions) {
    return this.http.get(this.url, { observe: 'body', params: { "includeProductOptions": includeProductOptions } });
  }
}
