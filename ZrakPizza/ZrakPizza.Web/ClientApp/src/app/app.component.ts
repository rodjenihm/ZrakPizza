import { Component, OnInit } from '@angular/core';
import { ProductService } from './services/product.service';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.css']
})
export class AppComponent implements OnInit {
  products$;
  constructor(private productService: ProductService) { }

  ngOnInit(): void {
    this.products$ = this.productService.getAll(true);
  }
}
