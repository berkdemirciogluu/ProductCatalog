using FluentNHibernate.Mapping;
using ProductCatalog.Entities.Concrete;

namespace ProductCatalog.DataAccess.NHibernate.Mappings
{
    public class OperationClaimMap : ClassMap<OperationClaim>
    {
        public OperationClaimMap()
        {
            Table("tbloperationclaim");

            Id(x => x.Id);

            Map(b => b.Name)
                .Not.Nullable();

        }
    }
}
