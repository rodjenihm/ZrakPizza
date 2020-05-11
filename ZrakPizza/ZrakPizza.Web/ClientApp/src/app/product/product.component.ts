import { Component, OnInit, Input } from '@angular/core';

@Component({
  selector: 'app-product',
  templateUrl: './product.component.html',
  styleUrls: ['./product.component.css']
})
export class ProductComponent implements OnInit {
  @Input() product;

  selectedOption;

  constructor() { }

  ngOnInit(): void {
    this.selectedOption = this.product.productOptions[0];
  }

  addToCart() {

  }
}
