using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ProductCatalog.Business.BusinessAspects.Autofac.JWT;
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
        public IActionResult Update([FromBody] UpdateOfferDto offer, int id) 
        {
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            var result = (_offerService.Update(offer, userId, id));
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

        [HttpPatch("ApproveOffer/{id}")]
        public IActionResult AproveOffer(int id)
        {
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            var result = _offerService.ApproveOffer(id, userId);
            if (result.Success)
            {
                return Ok(result); 
            }
            return BadRequest(result);
        }

        [HttpPatch("DeclineOffer/{id}")]
        public IActionResult DeclineOffer(int id)
        {
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            var result = _offerService.DeclineOffer(id, userId);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

        [HttpDelete("WithdrawOffer/{id}")]
        public IActionResult WithdrawOffer(int id)
        {
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            var result = _offerService.WithdrawTheOffer(id,userId);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }
    }
}
