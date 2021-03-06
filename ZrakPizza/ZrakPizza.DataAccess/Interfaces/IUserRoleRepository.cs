﻿using System.Collections.Generic;
using System.Threading.Tasks;
using ZrakPizza.DataAccess.Entities;

namespace ZrakPizza.DataAccess
{
    public interface IUserRoleRepository
    {
        Task<IEnumerable<Role>> GetRolesForUser(string userId);
    }
}
