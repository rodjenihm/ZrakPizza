﻿using System.Threading.Tasks;
using ZrakPizza.DataAccess.Entities;

namespace ZrakPizza.DataAccess
{
    public interface IUserRepository
    {
        Task Create(User user);
        Task<User> GetByUsername(string username);
    }
}
