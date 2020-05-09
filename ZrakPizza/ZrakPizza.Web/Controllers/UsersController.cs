using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ZrakPizza.DataAccess;
using ZrakPizza.DataAccess.Entities;

namespace ZrakPizza.Web.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly IUserRepository _userRepository;

        public UsersController(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        [HttpPost]
        public async Task<IActionResult> Post(Dto.User user)
        {
            if (!ModelState.IsValid) return BadRequest(ModelState);

            var userId = Guid.NewGuid().ToString("N");

            User newUser = new User
            {
                Id = userId,
                UserName = user.UserName,
                Name = user.Name,
                PasswordHash = user.Password
            };

            await _userRepository.Create(newUser);

            return Created($"api/users/{userId}", user);
        }
    }
}