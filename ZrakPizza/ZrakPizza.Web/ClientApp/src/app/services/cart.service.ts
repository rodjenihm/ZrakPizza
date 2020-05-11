import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';

@Injectable({
  providedIn: 'root'
})
export class CartService {
  private url = "api/carts";

  constructor(private http: HttpClient) { }
}
