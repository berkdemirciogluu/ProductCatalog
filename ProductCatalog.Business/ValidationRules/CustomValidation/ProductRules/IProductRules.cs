using ProductCatalog.Core.Utilities.Results;
using ProductCatalog.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductCatalog.Business.ValidationRules.CustomValidation.ProductRules
{
    public interface IProductRules
    {
        IResult CheckProductOwner(Product product, string userId);
        IResult CheckIfProductInvalid(int id);
    }
}
