using ProductCatalog.Business.Constants;
using ProductCatalog.Core.Utilities.Results;
using ProductCatalog.DataAccess.NHibernate.Repositories.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductCatalog.Business.ValidationRules.CustomValidation.OfferRules
{
    public class OfferRule : IOfferRule
    {
        IOfferRepository _offerRepository;

        public OfferRule(IOfferRepository offerRepository)
        {
            _offerRepository = offerRepository;
        }
        public IResult CheckIfOfferInvalid(int id)
        {
            var result = _offerRepository.GetById(id);
            if (result == null)
            {
                return new ErrorResult(Messages.OfferInvalid);
            }
            return new SuccessResult();
        }
    }
}
