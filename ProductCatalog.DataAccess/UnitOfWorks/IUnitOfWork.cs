using ProductCatalog.DataAccess.NHibernate.Repositories.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductCatalog.DataAccess.UnitOfWorks
{
    public interface IUnitOfWork
    {
        IOfferRepository Offer { get; }
        IProductRepository Product { get; }
        ICategoryRepository Category { get; }
        IAccountRepository Account { get; }

    }
}
