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
    public class UserMap : ClassMap<User>
    {
        public UserMap()
        {
            Table("tbluser");

            Id(x => x.Id);

            Map(b => b.FirstName)
                .Not.Nullable();

            Map(b => b.LastName)
                .Not.Nullable();

            Map(b => b.UserName)
                .Not.Nullable();

            Map(b => b.Email)
                .Not.Nullable();

            Map(b => b.PasswordHash);

            Map(b => b.PasswordSalt);

            Map(b => b.Status);

        }
    }
}
