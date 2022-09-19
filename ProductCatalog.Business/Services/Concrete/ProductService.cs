using AutoMapper;
using ProductCatalog.Business.BusinessAspects.Autofac.JWT;
using ProductCatalog.Business.Constants;
using ProductCatalog.Business.Services.Abstract;
using ProductCatalog.Core.Utilities.Business;
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

        [SecuredOperation("admin")]
        public IResult Add(AddProductDto entity, string userId)
        {
            var product = _mapper.Map<Product>(entity);

            product.UserId = Convert.ToInt32(userId);
            product.IsOfferable = true;
            product.IsSold = false;
            _productRepository.Add(product);
            return new SuccessResult(Messages.ProductAdded);
        }

        public IResult Delete(int id)
        {
            var result = BusinessRules.Run(CheckIfProductInvalid(id));

            if (result != null)
            {
                return new ErrorResult(result.Message);
            }

            var productToDelete = _productRepository.GetById(id);
            _productRepository.Delete(productToDelete.Id);
            return new SuccessResult(Messages.ProductDeleted);
        }

        public IDataResult<List<GetProductDto>> GetAll()
        {
            var products = _productRepository.GetProducts();
            var result = _mapper.Map<List<GetProductDto>>(products);
            return new SuccessDataResult<List<GetProductDto>>(result);
        }

        public IResult Update(UpdateProductDto product, int id, string userId)
        {

            var productToUpdate = _productRepository.GetById(id);
            IResult result = BusinessRules.Run(CheckIfProductInvalid(id), CheckProductOwner(productToUpdate, userId));

            if (result != null)
            {
                return new ErrorResult(result.Message);
            }

            productToUpdate.Brand = product.Brand != default ? product.Brand : productToUpdate.Brand;
            productToUpdate.Description = product.Description != default ? product.Description : productToUpdate.Description;
            productToUpdate.Price = product.Price != default ? product.Price : productToUpdate.Price;
            productToUpdate.Color = product.Color != default ? product.Color : productToUpdate.Color;
            productToUpdate.ProductName = product.ProductName != default ? product.ProductName : productToUpdate.ProductName;

            _productRepository.Update(productToUpdate);
            return new SuccessResult(Messages.ProductUpdated);
        }
        
        public IDataResult<List<GetProductDto>> GetUserProducts(string userId)
        {
            if (string.IsNullOrWhiteSpace(userId))
            {
                return new ErrorDataResult<List<GetProductDto>>(Messages.UserInvalid);
            }
            return new SuccessDataResult<List<GetProductDto>>(_productRepository.GetUserProducts(userId),Messages.ProductsListed);
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
            if(product.UserId != Convert.ToInt32(userId))
            {
                return new ErrorResult(Messages.NotProductOwner);
            }
            return new SuccessResult();
        }
    }
}