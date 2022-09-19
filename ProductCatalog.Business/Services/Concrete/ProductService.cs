using AutoMapper;
using ProductCatalog.Business.BusinessAspects.Autofac.JWT;
using ProductCatalog.Business.Constants;
using ProductCatalog.Business.Services.Abstract;
using ProductCatalog.Business.ValidationRules.CustomValidation.CategoryRules;
using ProductCatalog.Business.ValidationRules.CustomValidation.ProductRules;
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
        private readonly IProductRules _productRules;
        private readonly ICategoryRules _categoryRules;

        public ProductService(IProductRepository productRepository, IMapper mapper, IProductRules productRules,ICategoryRules categoryRules)
        {
            _productRepository = productRepository;
            _mapper = mapper;
            _productRules = productRules;
            _categoryRules = categoryRules;
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
            var result = BusinessRules.Run(_productRules.CheckIfProductInvalid(id));

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
            var result = BusinessRules.Run(_productRules.CheckIfProductInvalid(id),_productRules.CheckProductOwner(productToUpdate, userId));

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

        public IDataResult<List<GetProductDto>> GetProductsByCategoryId(int categoryId)
        {
            var result = BusinessRules.Run(_categoryRules.CheckIfCategoryInvalid(categoryId));
            if (result != null)
            {
                return new ErrorDataResult<List<GetProductDto>>(result.Message);
            }
            return new SuccessDataResult<List<GetProductDto>>(_productRepository.GetProductsByCategoryId(categoryId),Messages.ProductsListed);
        }



    }
}