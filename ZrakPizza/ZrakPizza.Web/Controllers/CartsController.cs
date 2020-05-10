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
    public class CartsController : ControllerBase
    {
        private readonly ICartRepository _cartRepository;

        public CartsController(ICartRepository cartRepository)
        {
            _cartRepository = cartRepository;
        }

        [HttpPost("createCart")]
        public async Task<IActionResult> CreateCart()
        {
            var cartId = Guid.NewGuid().ToString("N");

            var newCart = new Cart
            {
                Id = cartId,
                ItemsCount = 0,
                ItemsTotalPrice = 0
            };

            await _cartRepository.Create(newCart);

            return Ok(newCart);
        }
    }
}