using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ProductCatalog.Business.Services.Abstract;
using System.Security.Claims;

namespace ProductCatalog.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class AccountsController : ControllerBase
    {
        private readonly IAccountService _accountService;

        public AccountsController(IAccountService accountService)
        {
            _accountService = accountService;
        }

        [HttpGet("GetUserOffers")]
        public IActionResult GetUserOffers()
        {
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            var result = _accountService.GetUserOffers(userId);
            if (result.Success)
            {
                return Ok(result); 
            }
            return BadRequest(result);
        }

        [HttpGet("GetUserProductOffers")]
        public IActionResult GetUserOfferedProducts()
        {
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            var result = _accountService.GetUserOfferedProducts(userId);
            if (result.Success)
            {
                return Ok(result); 
            }
            return BadRequest(result);
        }

    }
}
