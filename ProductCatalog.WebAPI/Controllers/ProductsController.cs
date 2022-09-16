using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ProductCatalog.Business.Abstract;

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
    }
}
