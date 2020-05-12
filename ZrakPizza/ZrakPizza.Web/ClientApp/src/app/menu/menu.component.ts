import { Component, OnInit } from '@angular/core';
import { ProductService } from '../services/product.service';

@Component({
  selector: 'app-menu',
  templateUrl: './menu.component.html',
  styleUrls: ['./menu.component.css']
})
export class MenuComponent implements OnInit {
  products$;

  constructor(private productService: ProductService) { }

  ngOnInit() {
    this.products$ = this.productService.getAll(true);
  }
}
