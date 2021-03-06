﻿using System.Collections.Generic;
using System.Threading.Tasks;
using ZrakPizza.DataAccess.Entities;

namespace ZrakPizza.DataAccess
{
    public interface IProductRepository
    {
        Task<IEnumerable<Product>> GetAll(bool includeProductOptions);
    }
}
