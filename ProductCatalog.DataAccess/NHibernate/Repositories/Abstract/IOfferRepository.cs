using ProductCatalog.Core.DataAccess.NHibernate;
using ProductCatalog.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductCatalog.DataAccess.NHibernate.Repositories.Abstract
{
    internal interface IOfferRepository : IHibernateRepository<Offer>
    {
    }
}
