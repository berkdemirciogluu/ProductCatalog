using FluentNHibernate.Mapping;
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
            Table("user");

            Id(x => x.Id)
                .GeneratedBy.Identity();

            Map(b => b.FirstName)
                .Not.Nullable();

            Map(b => b.LastName)
                .Not.Nullable();

            Map(b => b.UserName)
                .Not.Nullable();

            Map(b => b.Email)
                .Not.Nullable();

            Map(b => b.PasswordHash)
                .Not.Nullable();

            Map(b => b.PasswordSalt)
                .Not.Nullable();

            Map(b => b.Status)
                .Not.Nullable();

            Map(b => b.LastActivity)
                .Not.Nullable();

            Map(b => b.CreatedDate)
                .Not.Nullable();
        }
    }
}
