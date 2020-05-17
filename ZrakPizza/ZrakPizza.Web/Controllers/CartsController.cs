using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SignalR;
using System;
using System.Threading.Tasks;
using ZrakPizza.DataAccess;
using ZrakPizza.DataAccess.Entities;
using ZrakPizza.Web.Dto;
using ZrakPizza.Web.Hubs;

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

        [HttpGet]
        public async Task<IActionResult> Get(string id)
        {
            var cart = await _cartRepository.GetById(id);

            return Ok(cart);
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


        [HttpPost("clearCart")]
        public async Task<IActionResult> Clear(CartVariantDto cartVariantDto)
        {
            await _cartRepository.Clear(cartVariantDto.CartId);

            return Ok();
        }

        [HttpPost("addVariant")]
        public async Task<IActionResult> AddVariant(CartVariantDto cartVariantDto)
        {
            await _cartRepository.AddVariant(cartVariantDto.CartId, cartVariantDto.ProductVariantId);

            return Ok();
        }

        [HttpPost("removeVariant")]
        public async Task<IActionResult> RemoveVariant(CartVariantDto cartVariantDto)
        {
            await _cartRepository.RemoveVariant(cartVariantDto.CartId, cartVariantDto.ProductVariantId);

            return Ok();
        }
    }
}