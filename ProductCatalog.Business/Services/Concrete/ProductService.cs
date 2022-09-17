using ProductCatalog.Business.Constants;
using ProductCatalog.Business.Services.Abstract;
using ProductCatalog.Core.Utilities.Results;
using ProductCatalog.DataAccess.NHibernate.Repositories.Abstract;
using ProductCatalog.Entities.Concrete;

namespace ProductCatalog.Business.Services.Concrete
{
    public class ProductService : IProductService
    {
        private readonly IProductRepository _productRepository;

        public ProductService(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }

        public IResult Add(Product product)
        {
            _productRepository.Add(product);
            return new SuccessResult();
        }

        public IResult Delete(int id)
        {
            var productToDelete = _productRepository.GetById(id);
            if (productToDelete == null)
            {
                return new ErrorResult(Messages.ProductInvalid);
            }

            try
            {
                _productRepository.Delete(productToDelete.Id);
                return new SuccessResult(Messages.ProductDeleted);
            }
            catch (Exception ex)
            {

                return new ErrorResult(Messages.ProductNotDeleted);
            }
        }

        public IDataResult<List<Product>> GetAll()
        {
            return new SuccessDataResult<List<Product>>(_productRepository.GetAll()); 
        }
    }
}
