using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ProductCatalog.Business.Abstract;
using ProductCatalog.Entities.Concrete;

namespace ProductCatalog.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoriesController : ControllerBase
    {
        private readonly ICategoryService _categoryService;

        public CategoriesController(ICategoryService categoryService)
        {
            _categoryService = categoryService;
        }

        [HttpGet("GetAll")]
        public IActionResult GetAll()
        {
            var result = _categoryService.GetAll(); //The method to obtain all the items in the list.
            if (result.Success)
            {
                return Ok(result); //If the process was successful, it will return 200 status code with a relevant message.
            }
            return BadRequest(result);
        }

        [HttpPost("Add")]
        public IActionResult Add([FromBody] Category category) //This method of adding the instance with the parameters taken from body to the list.
        {
            var result = _categoryService.Add(category);
            if (result.Success)
            {
                return Ok(result); //If the process was successful, it will return 200 status code with a relevant message.
            }
            return BadRequest(result);//If the process was fail, it will return 400 status code with a relevant message.
        }
    }
}
