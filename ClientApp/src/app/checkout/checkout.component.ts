import { Component, OnInit } from '@angular/core';
import { NotificationService } from '../services/notification.service';
import { FormBuilder, FormGroup, FormControl, Validators } from '@angular/forms';
import { CartService } from '../services/cart.service';
import { Router } from '@angular/router';
import { SignalRService } from '../services/signal-r.service';


@Component({
  selector: 'app-checkout',
  templateUrl: './checkout.component.html',
  styleUrls: ['./checkout.component.css']
})
export class CheckoutComponent implements OnInit {
  checkoutForm: FormGroup;
  orderDetails = { address: '', phone: '' };

  get address() { return this.checkoutForm.get('address'); }
  get phone() { return this.checkoutForm.get('phone'); }


  constructor(
    private cartService: CartService,
    private signalRService: SignalRService,
    private router: Router,
    private formBuilder: FormBuilder) { }

  ngOnInit(): void {
    this.checkoutForm = this.formBuilder.group({
      address: new FormControl(this.orderDetails.address, [
        Validators.required,
      ]),
      phone: new FormControl(this.orderDetails.phone, [
        Validators.required
      ])
    });
  }

  checkout(orderDetails) {
    if (window.confirm('Please make sure that provided contact informations are correct. Otherwise our courier won\'t be able to deliver the package. ')) {
      this.router.navigate(['/order-placed']);
      this.cartService.clearCart().subscribe(result => {
        if (result) {
          this.signalRService.notifyUpdateCart(this.cartService.getCart().id);
        };
      })
    }
  }
}