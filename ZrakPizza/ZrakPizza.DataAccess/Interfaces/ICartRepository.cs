using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using ZrakPizza.DataAccess.Entities;

namespace ZrakPizza.DataAccess
{
    public interface ICartRepository
    {
        Task Create(Cart cart);
        Task<Cart> GetById(string cartId);
        Task Clear(string cartId);
        Task AddVariant(string cartId, string productOptionId);
        Task RemoveVariant(string cartId, string productOptionId);
    }
}
