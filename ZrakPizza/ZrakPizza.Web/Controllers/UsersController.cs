using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Data.SqlClient;
using System.Threading.Tasks;
using ZrakPizza.DataAccess;
using ZrakPizza.DataAccess.Entities;
using ZrakPizza.Services;
using ZrakPizza.Web.Dto;
using ZrakPizza.Web.Resources;

namespace ZrakPizza.Web.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly IPasswordService _passwordService;
        private readonly IUserRepository _userRepository;
        private readonly IMapper _mapper;

        public UsersController(IPasswordService passwordService, IUserRepository userRepository, IMapper mapper)
        {
            _passwordService = passwordService;
            _userRepository = userRepository;
            _mapper = mapper;
        }

        [HttpPost]
        public async Task<IActionResult> Post(UserDto userDto)
        {
            if (!ModelState.IsValid) return BadRequest(ModelState);

            var userId = Guid.NewGuid().ToString("N");

            var newUser = _mapper.Map<User>(userDto);
            newUser.Id = userId;
            newUser.PasswordHash = _passwordService.HashPassword(userDto.Password);

            try
            {
                await _userRepository.Create(newUser);
            }
            catch (SqlException e)
            {
                var errorMessage = e.Message;

                if (e.Number == 2601) errorMessage = $"UserName {userDto.UserName} is already taken.";

                return BadRequest(new { errorMessage = errorMessage });
            }

            var userResource = _mapper.Map<UserResource>(newUser);

            return Created($"api/users/{userId}", userResource);
        }
    }
}