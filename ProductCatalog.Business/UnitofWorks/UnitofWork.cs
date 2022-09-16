using ProductCatalog.DataAccess.NHibernate.Repositories.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductCatalog.Business.UnitofWorks
{
    public class UnitofWork
    {
        public IAccountRepository Account { get; }
        public ICategoryRepository Category { get; }
        public IOfferRepository Offer { get; }
        public IProductRepository Product { get; }
        
        public UnitofWork (IOfferRepository offer, IProductRepository product,IAccountRepository accountDetail, ICategoryRepository category)
        {
            Category = category;
            Offer = offer;
            Product = product;
            Account = accountDetail;
        }
    }
}
