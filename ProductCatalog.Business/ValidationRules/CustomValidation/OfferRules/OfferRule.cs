using ProductCatalog.Business.Constants;
using ProductCatalog.Core.Utilities.Results;
using ProductCatalog.DataAccess.NHibernate.Repositories.Abstract;
using ProductCatalog.Entities.Concrete;
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
        IProductRepository _productRepository;

        public OfferRule(IOfferRepository offerRepository, IProductRepository productRepository)
        {
            _offerRepository = offerRepository;
            _productRepository = productRepository;
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

        public IResult CheckOfferOwner(Offer offer, string userId)
        {
            if (offer == null)
            {
                return new ErrorResult(Messages.OfferInvalid);
            }
            else if (offer.UserId != Convert.ToInt32(userId))
            {
                return new ErrorResult(Messages.NotOfferOwner);
            }
            return new SuccessResult();
        }

        public IResult CheckReceiveOwner(Offer offer, string userId)
        {
            var offers = _offerRepository.GetUserOfferedProducts(userId);

            if (offer == null)
            {
                return new ErrorResult(Messages.OfferInvalid);
            }

            var theProduct = offers.SingleOrDefault(offers => offers.Product.Id == offer.ProductId);
            if (theProduct == null)
            {
                return new ErrorResult(Messages.NotRelevantOffer);
            }
            return new SuccessResult();
        }


        public IResult CheckIfAlreadyOffered(Offer offer, string userId)
        {
            if (offer == null)
            {
                return new ErrorResult(Messages.OfferInvalid);
            }
            else if (offer.UserId != Convert.ToInt32(userId))
            {
                return new ErrorResult(Messages.NotOfferOwner);
            }
            return new SuccessResult();
        }

        public IResult CheckIfAlreadyAprroved(int offerId)
        {
            var result = _offerRepository.GetById(offerId);
            if (result == null)
            {
                return new ErrorResult(Messages.OfferInvalid);
            }
            else if (result.IsApproved == true)
            {
                return new ErrorResult(Messages.OfferAlreadyApproved);
            }
            return new SuccessResult();
        }
    }
}
