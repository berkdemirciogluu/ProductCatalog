using Microsoft.AspNetCore.Mvc;
using ProductCatalog.Business.Services.Abstract;
using ProductCatalog.Entities.Concrete;
using ProductCatalog.Entities.DTOs.Category;

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
        public IActionResult Add([FromBody] CommandCategoryDto entity) //This method of adding the instance with the parameters taken from body to the list.
        {
            var result = _categoryService.Add(entity);
            if (result.Success)
            {
                return Ok(result); //If the process was successful, it will return 200 status code with a relevant message.
            }
            return BadRequest(result);//If the process was fail, it will return 400 status code with a relevant message.
        }

        [HttpPut("Update/{id}")]
        public IActionResult Update([FromBody] CommandCategoryDto category, int id) //This method of updating the instance according to the parameters taken from body to the list.
        {
            var result = (_categoryService.Update(category, id));
            if (result.Success)
            {
                return Ok(result); //If the process was successful, it will return 200 status code with a relevant message.
            }
            return BadRequest(result);//If the process was fail, it will return 400 status code with a relevant message.
        }

        [HttpDelete("Delete/{id}")]
        public IActionResult Delete(int id)
        {
            var result = _categoryService.Delete(id); //This method of deleting the instance according to id.
            if (result.Success)
            {
                return Ok(result);//If the process was successful, it will return 200 status code with a relevant message.
            }
            return BadRequest(result);//If the process was fail, it will return 400 status code with a relevant message.
        }
    }
}
