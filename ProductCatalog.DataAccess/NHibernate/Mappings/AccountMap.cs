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
            Table("tblaccount");

            Id(x => x.Id);
            Map(b => b.UserId);
            Map(b => b.ProductId);
            Map(b => b.OfferId);
            Map(b => b.IsDeleted);

        }
    }
}
