using ProductCatalog.Core.Utilities.Results;
using ProductCatalog.Entities.DTOs.Offer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductCatalog.Business.Services.Abstract
{
    public interface IOfferService
    {
        IResult Add(MakeOfferDto entity, string userId);
        IResult Delete(int offerId);
        IResult ApproveOffer(int offerId, string userId);
        IResult DeclineOffer(int offerId, string userId);
        IResult Update(UpdateOfferDto entity, string userId, int id);

        IResult WithdrawTheOffer(int offerId, string userId);
    }
}
