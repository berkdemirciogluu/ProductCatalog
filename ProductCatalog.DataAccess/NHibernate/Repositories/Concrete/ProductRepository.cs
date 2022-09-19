using ProductCatalog.DataAccess.NHibernate.Repositories.Abstract;
using ProductCatalog.DataAccess.NHibernate.Repositories.Base;
using ProductCatalog.Entities.Concrete;
using ProductCatalog.Entities.DTOs.Product;

namespace ProductCatalog.DataAccess.NHibernate.Repositories.Concrete
{
    public class ProductRepository : HibernateRepository<Product>, IProductRepository
    {
        ICategoryRepository _categoryRepository;

        public ProductRepository(ICategoryRepository categoryRepository)
        {
            _categoryRepository = categoryRepository;
        }

        public List<GetProductDto> GetProducts()
        {
            var query = (from product in Entities
                         join category in _categoryRepository.Entities on product.CategoryId equals category.Id
                         select new GetProductDto
                         {
                             Id = product.Id,
                             ProductName = product.ProductName,
                             Description = product.Description,
                             IsOfferable = product.IsOfferable,
                             CategoryName = category.CategoryName,
                             Color = product.Color,
                             Brand = product.Brand,
                             Price = product.Price,
                         }).ToList();

            return query;
        }

        public List<GetProductDto> GetProductsByCategoryId(int categoryId)
        {
            var query = (from product in Entities
                         join category in _categoryRepository.Entities on product.CategoryId equals category.Id
                         where product.CategoryId == categoryId
                         select new GetProductDto
                         {
                             Id = product.Id,
                             ProductName = product.ProductName,
                             Description = product.Description,
                             IsOfferable = product.IsOfferable,
                             CategoryName = category.CategoryName,
                             Color = product.Color,
                             Brand = product.Brand,
                             Price = product.Price,
                         }).ToList();

            return query;
        }

        public List<GetProductDto> GetUserProducts(string userId)
        {

            var query = (from product in Entities
                        join category in _categoryRepository.Entities on product.CategoryId equals category.Id
                        where product.UserId == Convert.ToInt32(userId)
                        select new GetProductDto
                        {
                            Id = product.Id,
                            ProductName = product.ProductName,
                            Description = product.Description,
                            IsOfferable = product.IsOfferable,
                            CategoryName = category.CategoryName,
                            Color = product.Color,
                            Brand = product.Brand,
                            Price = product.Price,
                        }).ToList();

            return query;
        }
    }
}
