using FluentNHibernate.Mapping;
using ProductCatalog.Core.Entities.Concrete;
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
            Table("tbluseroperationclaim");

            Id(x => x.Id);

            Map(x => x.UserId).Not.Nullable();

            Map(x => x.OperationClaimId)
                .Not.Nullable();
        }
    }
}
