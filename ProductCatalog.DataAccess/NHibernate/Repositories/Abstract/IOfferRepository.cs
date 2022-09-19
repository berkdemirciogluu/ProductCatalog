using ProductCatalog.DataAccess.NHibernate.Repositories.Base;
using ProductCatalog.Entities.Concrete;
using ProductCatalog.Entities.DTOs.Offer;

namespace ProductCatalog.DataAccess.NHibernate.Repositories.Abstract
{
    public interface IOfferRepository : IHibernateRepository<Offer>
    {
        List<GetUserOfferDto> GetUserOffers(string userId);
        List<GetUserOfferDto> GetUserOfferedProducts(string userId);
    }
}
