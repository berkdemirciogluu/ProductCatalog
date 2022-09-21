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
            var result = _productService.GetAll(); //The method to obtain all the items in the list.
            if (result.Success)
            {
                return Ok(result); //If the process was successful, it will return 200 status code with a relevant message.
            }
            return BadRequest(result);
        }

        [HttpPost("Add")]
        public IActionResult Add([FromBody] AddProductDto product) //This method of adding the instance with the parameters taken from body to the list.
        {
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            var result = _productService.Add(product, userId);
            if (result.Success)
            {
                return Ok(result); //If the process was successful, it will return 200 status code with a relevant message.
            }
            return BadRequest(result);//If the process was fail, it will return 400 status code with a relevant message.
        }

        [HttpDelete("Delete/{id}")]
        public IActionResult Delete(int id)
        {
            var result = _productService.Delete(id); //This method of deleting the instance according to id.
            if (result.Success)
            {
                return Ok(result);//If the process was successful, it will return 200 status code with a relevant message.
            }
            return BadRequest(result);//If the process was fail, it will return 400 status code with a relevant message.
        }

        [HttpPut("Update/{id}")]
        public IActionResult Update([FromBody] UpdateProductDto product, int id) //This method of updating the instance according to the parameters taken from body to the list.
        {
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            var result = _productService.Update(product, id, userId);
            if (result.Success)
            {
                return Ok(result); //If the process was successful, it will return 200 status code with a relevant message.
            }
            return BadRequest(result);//If the process was fail, it will return 400 status code with a relevant message.

        }

        [HttpGet("GetUserProducts")]
        public IActionResult GetUserProducts()
        {
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            var result = _productService.GetUserProducts(userId);
            if (result.Success)
            {
                return Ok(result); //If the process was successful, it will return 200 status code with a relevant message.
            }
            return BadRequest(result);//If the process was fail, it will return 400 status code with a relevant message.
        }

        [HttpGet("GetProductsByCategoryId")]
        public IActionResult GetProductsByCategoryId([FromQuery] int categoryId)
        {
            var result = _productService.GetProductsByCategoryId(categoryId); //The method to obtain all the items in the list.
            if (result.Success)
            {
                return Ok(result); //If the process was successful, it will return 200 status code with a relevant message.
            }
            return BadRequest(result);
        }

        [HttpPut("SellProduct")]
        public IActionResult SellProduct(SellProductDto sellproduct)
        {
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            _productService.SellProduct(sellproduct, userId);
            return Ok();
        }
    }
}
