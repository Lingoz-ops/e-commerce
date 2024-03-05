using Ecommerce.Models.Models;
using Microsoft.AspNetCore.Mvc;
using Services.Interfaces;

namespace Ecommerce.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly IProduct _product;

        public ProductController(IProduct product)
        {
            _product = product;
        }

        [HttpPost("product")]
        public ActionResult<Order> CreateProduct(Product product)
        {
            var result = _product.CreateProduct(product);
            return Ok(result);
        }

        [HttpGet("{productId}")]
        public ActionResult<Product> GetProduct(string productId)
        {
            var result = _product.GetProduct(productId);
            return Ok(result);
        }

        [HttpGet]
        public ActionResult<IEnumerable<Product>> GetAllProducts()
        {
            var products = _product.GetAllProducts();
            return Ok(products);
        }

        [HttpPut("{productId}")]
        public ActionResult<Product> UpdateProductById(string productId, Product product)
        {
            var result = _product.UpdateProductById(productId, product);
            return Ok(result);
        }
    }
}
