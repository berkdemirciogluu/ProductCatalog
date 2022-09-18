using ProductCatalog.DataAccess.NHibernate.Repositories.Abstract;
using ProductCatalog.DataAccess.NHibernate.Repositories.Base;
using ProductCatalog.Entities.Concrete;
using ProductCatalog.Entities.DTOs.Product;

namespace ProductCatalog.DataAccess.NHibernate.Repositories.Concrete
{
    public class ProductRepository : HibernateRepository<Product>, IProductRepository
    {
        public List<ProductOfferDto> GetProductsOffer()
        {

            var query = from p in Entities
                        join c in _context.Categories on p.CategoryId equals c.Id
                        where p.IsDeleted == false && p.IsOfferable == true
                        select new ProductOfferDto
                        {
                            CategoryName = c.CategoryName,
                            Id = p.Id,
                            Price = p.Price,
                            ProductName = p.ProductName
                        };
            return query.ToList();

        }
    }
}
