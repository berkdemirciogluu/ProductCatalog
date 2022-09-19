using FluentNHibernate.Mapping;
using ProductCatalog.Entities.Concrete;

namespace ProductCatalog.DataAccess.NHibernate.Mappings
{
    public class UserOperationClaimMap : ClassMap<UserOperationClaim>
    {
        public UserOperationClaimMap()
        {
            Table("tbluseroperationclaim");

            Id(x => x.Id);

            Map(x => x.UserId).Not.Nullable();

            Map(x => x.OperationClaimId)
                .Not.Nullable();
            Map(b => b.IsDeleted);
        }
    }
}
