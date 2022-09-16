using ProductCatalog.Core.DataAccess.NHibernate;
using ProductCatalog.DataAccess.NHibernate.Repositories.Abstract;
using ProductCatalog.Entities.Concrete;

namespace ProductCatalog.DataAccess.NHibernate.Repositories.Concrete
{
    public class ProductRepository : HibernateRepository<Product>, IProductRepository
    {
    //    private readonly ISession _session;

    //    public ProductRepository(ISession session) : base(session)
    //    {
    //        _session = session;
    //    }
    }
}
