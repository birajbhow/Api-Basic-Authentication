using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ProductsApi.Models;

namespace ProductsApi.Controllers
{
    [Authorize]
    [ApiController]
    [Route("api/[Controller]")]
    public class ProductsController : ControllerBase
    {
        private readonly ILogger<ProductsController> _logger;

        public ProductsController(ILogger<ProductsController> logger)
        {
            _logger = logger;
        }

        [AllowAnonymous]
        [HttpGet("healthcheck")]
        public ActionResult<IEnumerable<Product>> Get()
        {
            return Ok();
        }

        [HttpGet]
        public ActionResult<IEnumerable<Product>> GetProducts()
        {
            var products = new List<Product>
            {
                new Product("Table", "Red"),
                new Product("Chair", "Black")
            };

            return Ok(products);
        }

        [HttpGet("{colour}")]
        public ActionResult<Product> GetProductByColour(string colour)
        {
            var products = new List<Product>
            {
                new Product("Table", "Red"),
                new Product("Chair", "Black")
            };

            var product = products.FirstOrDefault(p => p.Colour.Equals(colour, StringComparison.OrdinalIgnoreCase));
            if (product == null)
            {
                return NoContent();
            } 
            return Ok(product);
        }
    }
}
