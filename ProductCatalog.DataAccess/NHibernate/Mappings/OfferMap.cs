using FluentNHibernate.Mapping;
using NHibernate;
using NHibernate.Mapping.ByCode;
using ProductCatalog.Entities.Concrete;

namespace ProductCatalog.DataAccess.NHibernate.Mappings
{
    public class OfferMap : ClassMap<Offer>
    {
        public OfferMap()
        {
            Table("tbloffer");

            Id(x => x.Id);

            Map(b => b.UserId);

            Map(b => b.ProductId);

            Map(b => b.IsApproved)
                .Not.Nullable();

            Map(b => b.IsSold)
                .Not.Nullable();

            Map(b => b.OfferedPrice)
                .Not.Nullable();
            Map(b => b.IsDeleted);
        }
    }
}
