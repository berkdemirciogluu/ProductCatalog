using ProductCatalog.Core.Utilities.Results;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductCatalog.Business.ValidationRules.CustomValidation.AuthRules
{
    public interface IAuthRule
    {
        IResult CheckIfEmailExist(string email);
    }
}
