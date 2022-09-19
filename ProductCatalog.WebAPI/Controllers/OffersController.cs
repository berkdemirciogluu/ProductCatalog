using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ProductCatalog.Business.Services.Abstract;
using ProductCatalog.Entities.DTOs.Offer;
using System.Security.Claims;

namespace ProductCatalog.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OffersController : ControllerBase
    {
        IOfferService _offerService;

        public OffersController(IOfferService offerservice)
        {
            _offerService = offerservice;
        }

        [HttpPost("MakeAnOffer")]
        public IActionResult Add([FromBody] MakeOfferDto offer)
        {
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            var result = _offerService.Add(offer, userId);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);

        }

        [HttpDelete("Delete/{id}")]
        public IActionResult Delete(int id)
        {
            var result = _offerService.Delete(id);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

        [HttpPut("Update/{id}")]
        public IActionResult Update([FromBody] UpdateOfferDto category, int id) //This method of updating the instance according to the parameters taken from body to the list.
        {
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            var result = (_offerService.Update(category, userId, id));
            if (result.Success)
            {
                return Ok(result); //If the process was successful, it will return 200 status code with a relevant message.
            }
            return BadRequest(result);//If the process was fail, it will return 400 status code with a relevant message.
        }

        [HttpPatch("ApproveOffer/{id}")]
        public IActionResult AproveOffer(int id)
        {
            var result = _offerService.ApproveOffer(id);
            if (result.Success)
            {
                return Ok(result); //If the process was successful, it will return 200 status code with a relevant message.
            }
            return BadRequest(result);//If the process was fail, it will return 400 status code with a relevant message.
        }
    }
}
