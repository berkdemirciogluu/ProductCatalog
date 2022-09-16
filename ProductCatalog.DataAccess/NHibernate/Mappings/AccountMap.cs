using FluentNHibernate.Mapping;
using NHibernate;
using NHibernate.Mapping.ByCode;
using NHibernate.Mapping.ByCode.Conformist;
using ProductCatalog.Entities.Concrete;

namespace ProductCatalog.DataAccess.NHibernate.Mappings
{
    public class AccountMap : ClassMap<Account>
    {
        public AccountMap()
        {
            Table("account");

            Id(x => x.Id);

            Map(b => b.UserId)
                .Not.Nullable();

            Map(b => b.ProductId)
                .Not.Nullable();

            Map(b => b.OfferId)
                .Not.Nullable();

            Map(b => b.IsDeleted)
                .Not.Nullable();

            Map(b => b.CreatedDate)
                .Not.Nullable();

        }
    }
}
