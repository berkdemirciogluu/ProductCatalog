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
            Table("offer");

            Id(x => x.Id)
                .GeneratedBy.Identity();

            References(b => b.User);

            References(b => b.Product);

            Map(b => b.IsApproved)
                .Not.Nullable();

            Map(b => b.IsSold)
                .Not.Nullable();

            Map(b => b.OfferedPrice)
                .Not.Nullable();

            Map(b => b.CreatedDate)
                .Not.Nullable();
        }
    }
}
