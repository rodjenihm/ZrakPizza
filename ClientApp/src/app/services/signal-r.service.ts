import { Injectable } from '@angular/core';
import * as signalR from "@aspnet/signalr";

@Injectable({
  providedIn: 'root'
})
export class SignalRService {

  private hubConnection: signalR.HubConnection;

  constructor() { }

  public startConnection = () => {
    this.hubConnection = new signalR.HubConnectionBuilder()
      .withUrl('api/CartHub')
      .build();

    this.hubConnection
      .start()
      .then(() => console.log('Connection started'))
      .catch(err => console.log('Error while starting connection: ' + err));
  }

  public notifyUpdateCart(cartId) {
    this.hubConnection.invoke('NotifyUpdateCart', cartId);
  }

  public addOnUpdateCartListener = (func) => {
    this.hubConnection.on('updateCart', (data) => {
      func(data);
    });
  }
}
