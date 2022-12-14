using FluentValidation;
using ProductCatalog.Entities.DTOs.Offer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductCatalog.Business.ValidationRules.FluentValidation.OfferValidation
{
    public class UpdateOfferDtoValidator : AbstractValidator<UpdateOfferDto>
    {
        public UpdateOfferDtoValidator()
        {
            RuleFor(o => o.ProductId).GreaterThan(0);
            RuleFor(o => o.OfferedPrice).GreaterThan(0);

        }
    }
}

