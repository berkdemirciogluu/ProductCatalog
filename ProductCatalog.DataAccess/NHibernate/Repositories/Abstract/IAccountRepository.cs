using ProductCatalog.DataAccess.NHibernate.Repositories.Base;
using ProductCatalog.Entities.Concrete;

namespace ProductCatalog.DataAccess.NHibernate.Repositories.Abstract
{
    public interface IAccountRepository : IHibernateRepository<Account>
    {
    }
}
