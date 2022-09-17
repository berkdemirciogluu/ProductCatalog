using AutoMapper;
using ProductCatalog.Business.Constants;
using ProductCatalog.Business.Services.Abstract;
using ProductCatalog.Core.Utilities.Results;
using ProductCatalog.DataAccess.NHibernate.Repositories.Abstract;
using ProductCatalog.Entities.Concrete;
using ProductCatalog.Entities.DTOs.Product;

namespace ProductCatalog.Business.Services.Concrete
{
    public class ProductService : IProductService
    {
        private readonly IProductRepository _productRepository;
        private readonly IMapper _mapper;

        public ProductService(IProductRepository productRepository, IMapper mapper)
        {
            _productRepository = productRepository;
            _mapper = mapper;
        }

        public IResult Add(AddProductDto entity)
        {
            var product = _mapper.Map<Product>(entity);
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

        public IDataResult<List<GetProductDto>> GetAll()
        {
            var products = _productRepository.GetAll();
            var result = _mapper.Map<List<GetProductDto>>(products);
            return new SuccessDataResult<List<GetProductDto>>(result); 
        }
    }
}
