using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using ZrakPizza.Services;
using ZrakPizza.Web.Dto;

namespace ZrakPizza.Web.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthenticateController : ControllerBase
    {
        private readonly IAuthenticateService _authenticateService;

        public AuthenticateController(IAuthenticateService authenticateService)
        {
            _authenticateService = authenticateService;
        }

        [HttpPost]
        public async Task<IActionResult> Post(UserCredentialsDto userCredentialsDto)
        {
            var token = await _authenticateService.GenerateToken(userCredentialsDto.Username, userCredentialsDto.Password);

            if (token == null)
                return Ok("Username and/or password are incorrect");

            return Ok(new { token = token });
        }
    }
}