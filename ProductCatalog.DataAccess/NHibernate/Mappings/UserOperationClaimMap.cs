using FluentNHibernate.Mapping;
using ProductCatalog.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductCatalog.DataAccess.NHibernate.Mappings
{
    public class UserOperationClaimMap : ClassMap<UserOperationClaim>
    {
        public UserOperationClaimMap()
        {
            Table("useroperationclaim");

            Id(x => x.Id)
                .GeneratedBy.Identity();

            References(x => x.User);

            Map(x => x.OperationClaimId)
                .Not.Nullable();

            Map(b => b.CreatedDate)
                .Not.Nullable();
        }
    }
}
