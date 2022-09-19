using ProductCatalog.Core.Utilities.Results;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductCatalog.Business.ValidationRules.CustomValidation.CategoryRules
{
    public interface ICategoryRules
    {
        IResult CheckIfCategoryNameExist(string categoryName);
        IResult CheckIfCategoryInvalid(int id);
    }
}
