using ProductCatalog.DataAccess.NHibernate.Repositories.Abstract;
using ProductCatalog.DataAccess.NHibernate.Repositories.Base;
using ProductCatalog.Entities.Concrete;

namespace ProductCatalog.DataAccess.NHibernate.Repositories.Concrete
{
    public class ProductRepository : HibernateRepository<Product>, IProductRepository
    {

    }
}
