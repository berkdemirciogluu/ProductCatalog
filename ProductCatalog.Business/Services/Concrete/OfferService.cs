using AutoMapper;
using ProductCatalog.Business.Constants;
using ProductCatalog.Business.Services.Abstract;
using ProductCatalog.Business.ValidationRules.CustomValidation.OfferRules;
using ProductCatalog.Business.ValidationRules.CustomValidation.ProductRules;
using ProductCatalog.Core.Utilities.Business;
using ProductCatalog.Core.Utilities.Results;
using ProductCatalog.DataAccess.NHibernate.Repositories.Abstract;
using ProductCatalog.Entities.Concrete;
using ProductCatalog.Entities.DTOs.Offer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductCatalog.Business.Services.Concrete
{
    public class OfferService : IOfferService
    {
        private readonly IMapper _mapper;
        private readonly IProductRepository _productRepository;
        private readonly IOfferRepository _offerRepository;
        private readonly IProductRule _productRules;
        private readonly IOfferRule _offerRules;
        public OfferService(IMapper mapper, IProductRepository productRepository, IOfferRepository offerRepository, IProductRule productRules, IOfferRule offerRule)
        {
            _mapper = mapper;
            _productRepository = productRepository;
            _offerRepository = offerRepository;
            _productRules = productRules;
            _offerRules = offerRule;
        }

        public IResult Delete(int offerId)
        {
            IResult result = BusinessRules.Run(_offerRules.CheckIfOfferInvalid(offerId));

            if (result != null)
            {
                return new ErrorResult(result.Message);
            }

            var offerToDelete = _offerRepository.GetById(offerId);
            offerToDelete.IsDeleted = true;
            _offerRepository.Update(offerToDelete);

            return new SuccessResult(Messages.OfferDeleted);
        }

        public IResult Add(MakeOfferDto entity, string userId)
        {
            BusinessRules.Run(_productRules.CheckIfProductInvalid(entity.ProductId));

            var product = _productRepository.GetById(entity.ProductId);
            if (!product.IsOfferable)
            {
                return new ErrorResult(Messages.ProductNotSaled);
            }

            var offer = _mapper.Map<Offer>(entity);
            offer.UserId = Convert.ToInt32(userId);
            offer.IsApproved = false;
            offer.IsSold = false;
            _offerRepository.Add(offer);
            return new SuccessResult(Messages.OfferAccepted);

        }

        public IResult Update(UpdateOfferDto entity, string userId, int offerId)
        {
            var offer = _offerRepository.GetById(offerId);

            IResult result = BusinessRules.Run(_offerRules.CheckIfOfferInvalid(offerId), _productRules.CheckIfProductInvalid(entity.ProductId), 
                _offerRules.CheckOfferOwner(offer,userId));

            if (result != null)
            {
                return new ErrorResult(result.Message);
            }

            offer.ProductId = entity.ProductId != default ? entity.ProductId : offer.ProductId;
            offer.OfferedPrice = entity.OfferedPrice != default ? entity.OfferedPrice : offer.OfferedPrice;

            _offerRepository.Update(offer);
            return new SuccessResult(Messages.OfferUpdated);
        }

        public IResult ApproveOffer(int offerId)
        {
            
            IResult result = BusinessRules.Run(_offerRules.CheckIfOfferInvalid(offerId));

            var offer = _offerRepository.GetById(offerId);

            if (result != null)
            {
                return new ErrorResult(result.Message);
            }

            if (offer.IsApproved)
            {
                offer.IsSold = true;
            }
            else
            {
                offer.IsSold = false;
            }

            return new SuccessResult(Messages.OfferApproved);
        }

        public IResult WithDrawTheOffer(int offerId)
        {
            var result = BusinessRules.Run(_offerRules.CheckIfOfferInvalid(offerId));

            if (result != null)
            {
                return new ErrorResult(result.Message);
            }

            var offer = _offerRepository.GetById(offerId);

            if (offer.IsApproved)
            {
                return new ErrorResult(Messages.OfferCannotWitdrawn);
            }

            offer.IsDeleted = true;
            _offerRepository.Update(offer);

            return new SuccessResult(Messages.OfferWithdrawn);
        }
    }
}
