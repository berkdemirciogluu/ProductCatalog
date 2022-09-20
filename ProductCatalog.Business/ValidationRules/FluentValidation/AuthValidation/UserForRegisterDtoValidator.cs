using FluentValidation;
using ProductCatalog.Business.Constants;
using ProductCatalog.Entities.DTOs.User;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductCatalog.Business.ValidationRules.FluentValidation.AuthValidation
{
    public class UserForRegisterDtoValidator : AbstractValidator<UserForRegisterDto>
    {
        public UserForRegisterDtoValidator()
        {
            RuleFor(c => c.Email).NotEmpty().WithMessage(Messages.EmailRequired);
            RuleFor(c => c.Password).NotEmpty().WithMessage(Messages.PasswordRequired);
            RuleFor(c => c.Password).MinimumLength(8).MaximumLength(20);
        }
    }
}
