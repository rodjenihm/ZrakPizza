using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using ZrakPizza.DataAccess;

namespace ZrakPizza.Web.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private readonly IProductRepository _productRepository;

        public ProductsController(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }

        [HttpGet]
        public async Task<IActionResult> Get(bool includeProductOptions)
        {
            var result = await _productRepository.GetAll(includeProductOptions: includeProductOptions);

            return Ok(result);
        }
    }
}