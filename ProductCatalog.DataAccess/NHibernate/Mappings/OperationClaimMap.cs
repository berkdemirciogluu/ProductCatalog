using FluentNHibernate.Mapping;
using NHibernate;
using NHibernate.Mapping.ByCode;
using ProductCatalog.Entities.Concrete;

namespace ProductCatalog.DataAccess.NHibernate.Mappings
{
    public class OperationClaimMap : ClassMap<OperationClaim>
    {
        public OperationClaimMap()
        {
            Table("operationclaim");

            Id(x => x.Id)
                .GeneratedBy.Identity();

            Map(b => b.Name)
                .Not.Nullable();

            Map(b => b.IsDeleted)
                .Not.Nullable();

            Map(b => b.CreatedDate)
                .Not.Nullable();
        }
    }
}
