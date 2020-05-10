using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using ZrakPizza.DataAccess.Entities;

namespace ZrakPizza.DataAccess
{
    public interface IUserRepository
    {
        Task Create(User user);
        Task<User> GetByUsername(string username);
    }
}
