import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { NavbarComponent } from './navbar/navbar.component';
import { ProductService } from './services/product.service';
import { HttpClientModule } from '@angular/common/http';
import { ProductComponent } from './product/product.component';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { CartService } from './services/cart.service';
import { MenuComponent } from './menu/menu.component';
import { CartComponent } from './cart/cart.component';
import { HomeComponent } from './home/home.component';
import { LoginComponent } from './login/login.component';
import { RegisterComponent } from './register/register.component';
import { AuthService } from './services/auth.service';
import { NotificationService } from './services/notification.service';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { ToastrModule } from 'ngx-toastr';
import { UserService } from './services/user.service';
import { CheckoutComponent } from './checkout/checkout.component';
import { OrderPlacedComponent } from './order-placed/order-placed.component';



@NgModule({
  declarations: [
    AppComponent,
    NavbarComponent,
    ProductComponent,
    MenuComponent,
    CartComponent,
    HomeComponent,
    LoginComponent,
    RegisterComponent,
    CheckoutComponent,
    OrderPlacedComponent
  ],
  imports: [
    BrowserModule,
    HttpClientModule,
    AppRoutingModule,
    FormsModule,
    ReactiveFormsModule,
    BrowserAnimationsModule,
    ToastrModule.forRoot()
  ],
  providers: [
    ProductService,
    CartService,
    AuthService,
    UserService,
    NotificationService
  ],
  bootstrap: [AppComponent]
})
export class AppModule { }
