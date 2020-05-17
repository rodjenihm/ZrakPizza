using Microsoft.AspNetCore.SignalR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ZrakPizza.Web.Dto;

namespace ZrakPizza.Web.Hubs
{
    public class CartHub : Hub
    {
        public async Task NotifyUpdateCart(string cartId)
        {
            await Clients.Others.SendAsync("updateCart", cartId);
        }
    }
}
