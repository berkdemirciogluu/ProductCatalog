using ProductCatalog.DataAccess.NHibernate.Repositories.Base;
using ProductCatalog.Entities.Concrete;
using ProductCatalog.Entities.DTOs.Product;

namespace ProductCatalog.DataAccess.NHibernate.Repositories.Abstract
{
    public interface IProductRepository : IHibernateRepository<Product>
    {
        public List<GetProductDto> GetUserProducts(string userId);
        public List<GetProductDto> GetProducts();
        public List<GetProductDto> GetProductsByCategoryId(int categoryId);
        public List<GetProductOffersDto> GetProductsForOffer();

    }
}
