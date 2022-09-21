using ProductCatalog.DataAccess.NHibernate.Repositories.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductCatalog.DataAccess.UnitOfWorks
{
    public class UnitOfWork : IUnitOfWork
    {
        public IOfferRepository Offer { get; }

        public IProductRepository Product { get; }

        public ICategoryRepository Category { get; }

        public IAccountRepository Account { get; }

        public UnitOfWork(IOfferRepository offer, IProductRepository product,IAccountRepository account, ICategoryRepository category)
        {

            Category = category;

            Offer = offer;
            Product = product;

            Account = account;
        }
    }
}
