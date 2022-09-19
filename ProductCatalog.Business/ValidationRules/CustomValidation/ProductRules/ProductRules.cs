using ProductCatalog.Business.Constants;
using ProductCatalog.Core.Utilities.Results;
using ProductCatalog.DataAccess.NHibernate.Repositories.Abstract;
using ProductCatalog.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductCatalog.Business.ValidationRules.CustomValidation.ProductRules
{
    public class ProductRules : IProductRules
    {
        IProductRepository _productRepository;

        public ProductRules(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }

        public IResult CheckIfProductInvalid(int id)
        {
            var result = _productRepository.GetById(id);
            if (result == null)
            {
                return new ErrorResult(Messages.ProductInvalid);
            }
            return new SuccessResult();
        }

        public IResult CheckProductOwner(Product product, string userId)
        {
            if (product.UserId != Convert.ToInt32(userId))
            {
                return new ErrorResult(Messages.NotProductOwner);
            }
            return new SuccessResult();
        }
    }
}
