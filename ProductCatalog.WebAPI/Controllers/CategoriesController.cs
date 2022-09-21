using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ProductCatalog.Business.BusinessAspects.Autofac.JWT;
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
            var result = _categoryService.GetAll(); 
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

        [HttpPost("Add")]
        public IActionResult Add([FromBody] CommandCategoryDto entity) 
        {
            var result = _categoryService.Add(entity);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

        [HttpPut("Update/{id}")]
        public IActionResult Update([FromBody] CommandCategoryDto category, int id) 
        {
            var result = (_categoryService.Update(category, id));
            if (result.Success)
            {
                return Ok(result); 
            }
            return BadRequest(result);
        }

        [HttpDelete("Delete/{id}")]
        public IActionResult Delete(int id)
        {
            var result = _categoryService.Delete(id); 
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }
    }
}
