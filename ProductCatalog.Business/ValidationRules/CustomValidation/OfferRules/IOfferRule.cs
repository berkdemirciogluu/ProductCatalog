using ProductCatalog.Core.Utilities.Results;
using ProductCatalog.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductCatalog.Business.ValidationRules.CustomValidation.OfferRules
{
    public interface IOfferRule
    {
        IResult CheckIfOfferInvalid(int id);
        IResult CheckOfferOwner(Offer offer, string userId);
        IResult CheckReceiveOwner(Offer offer, string userId);

        IResult CheckIfAlreadyAprroved(int offerId);
    }
}
