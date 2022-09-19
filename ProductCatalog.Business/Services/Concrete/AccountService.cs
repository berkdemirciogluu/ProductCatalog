using ProductCatalog.Business.Constants;
using ProductCatalog.Business.Services.Abstract;
using ProductCatalog.Core.Utilities.Results;
using ProductCatalog.DataAccess.NHibernate.Repositories.Abstract;
using ProductCatalog.Entities.DTOs.Offer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductCatalog.Business.Services.Concrete
{
    public class AccountService : IAccountService
    {
        private readonly IOfferRepository _offerRepository;

        public AccountService(IOfferRepository offerRepository)
        {
            _offerRepository = offerRepository;
        }

        public IDataResult<List<GetUserOfferDto>> GetUserOfferedProducts(string userId)
        {
            //var result = _offerRepository.Entities.Where(x => x.UserId == Convert.ToInt32(userId)).ToList();
            //if (result.Count == 0)
            //{
            //    return new ErrorDataResult<List<GetUserOfferDto>>(Messages.NoUserProductOffer);
            //}
            return new SuccessDataResult<List<GetUserOfferDto>>(_offerRepository.GetUserOfferedProducts(userId),Messages.ProductsListed);
        }

        public IDataResult<List<GetUserOfferDto>> GetUserOffers(string userId)
        {
            var result = _offerRepository.Entities.Where(x => x.UserId == Convert.ToInt32(userId)).ToList();
            if (result.Count == 0)
            {
                return new ErrorDataResult<List<GetUserOfferDto>>(Messages.NoUserOffer);
            }
            return new SuccessDataResult<List<GetUserOfferDto>>(_offerRepository.GetUserOffers(userId), Messages.OffersListed);
        }
    }
}
