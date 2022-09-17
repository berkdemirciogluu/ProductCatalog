using FluentValidation;
using ProductCatalog.Business.Constants;
using ProductCatalog.Entities.DTOs.Category;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductCatalog.Business.ValidationRules.FluentValidation.CategoryValidation
{
    public class CommandCategoryDtoValidator : AbstractValidator<CommandCategoryDto>
    {
        public CommandCategoryDtoValidator()
        {
            RuleFor(c => c.CategoryName).NotNull().WithMessage(Messages.CategoryNameWarning);
        }        
    }
}
