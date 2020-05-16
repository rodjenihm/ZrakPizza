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
        public async Task AddProduct(CartVariantDto cartVariant) =>
            await Clients.All.SendAsync("onProductAdded", cartVariant);

        public async Task RemoveProduct(CartVariantDto cartVariant) =>
            await Clients.All.SendAsync("onProductRemoved", cartVariant);
    }
}
