﻿using FluentNHibernate.Mapping;
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

            References(b => b.User);

            References(b => b.Product);

            References(b => b.Offer);

            //Map(b => b.UserId);
        }
    }
}
