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

        //public List<ProductOfferDto> GetProductsOffer()
        //{

        //    var query = from p in Entities
        //                join c in _context.Categories on p.CategoryId equals c.Id
        //                where p.IsDeleted == false && p.IsOfferable == true
        //                select new ProductOfferDto
        //                {
        //                    CategoryName = c.CategoryName,
        //                    Id = p.Id,
        //                    Price = p.Price,
        //                    ProductName = p.ProductName
        //                };
        //    return query.ToList();

        //}
        public List<GetProductDto> GetUserProducts(string userId)
        {
            var query = from product in Entities
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
                        };
            return query.ToList();
        }
    }
}
