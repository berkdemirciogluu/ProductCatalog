using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ProductCatalog.Business.Services.Abstract;
using System.Security.Claims;

namespace ProductCatalog.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
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
                return Ok(result); //If the process was successful, it will return 200 status code with a relevant message.
            }
            return BadRequest(result);//If the process was fail, it will return 400 status code with a relevant message.
        }

        [HttpGet("GetUserProductOffers")]
        public IActionResult GetUserOfferedProducts()
        {
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            var result = _accountService.GetUserOfferedProducts(userId);
            if (result.Success)
            {
                return Ok(result); //If the process was successful, it will return 200 status code with a relevant message.
            }
            return BadRequest(result);//If the process was fail, it will return 400 status code with a relevant message.
        }

    }
}
