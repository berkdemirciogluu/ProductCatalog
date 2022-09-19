using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ProductCatalog.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OffersController : ControllerBase
    {
        IOfferService _offerservice;
        public OffersController()
        {

        }

        [HttpPut("WithdrawTheOffer/{id}")]
        public IActionResult WithdrawTheOffer(int id)
        {

        }

    }
}
