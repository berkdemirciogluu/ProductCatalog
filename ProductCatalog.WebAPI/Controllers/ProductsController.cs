using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ProductCatalog.Business.Services.Abstract;
using ProductCatalog.Entities.Concrete;
using ProductCatalog.Entities.DTOs.Product;
using System.Linq;
using System.Security.Claims;

namespace ProductCatalog.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class ProductsController : ControllerBase
    {
        private readonly IProductService _productService;

        public ProductsController(IProductService productService)
        {
            _productService = productService;
        }

        [HttpGet("GetAll")]
        public IActionResult GetAll()
        {
            var result = _productService.GetAll(); 
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

        [HttpPost("Add")]
        public IActionResult Add([FromBody] AddProductDto product) 
        {
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            var result = _productService.Add(product, userId);
            if (result.Success)
            {
                return Ok(result); 
            }
            return BadRequest(result);
        }

        [HttpDelete("Delete/{id}")]
        public IActionResult Delete(int id)
        {
            var result = _productService.Delete(id); 
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

        [HttpPut("Update/{id}")]
        public IActionResult Update([FromBody] UpdateProductDto product, int id) 
        {
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            var result = _productService.Update(product, id, userId);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);

        }

        [HttpGet("GetUserProducts")]
        public IActionResult GetUserProducts()
        {
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            var result = _productService.GetUserProducts(userId);
            if (result.Success)
            {
                return Ok(result); 
            }
            return BadRequest(result);
        }

        [HttpGet("GetProductsByCategoryId")]
        public IActionResult GetProductsByCategoryId([FromQuery] int categoryId)
        {
            var result = _productService.GetProductsByCategoryId(categoryId); 
            if (result.Success)
            {
                return Ok(result); 
            }
            return BadRequest(result);
        }

    }
}
