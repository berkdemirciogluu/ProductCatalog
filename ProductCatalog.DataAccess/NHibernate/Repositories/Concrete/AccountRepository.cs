﻿using NHibernate;
using ProductCatalog.Core.DataAccess.NHibernate;
using ProductCatalog.DataAccess.NHibernate.Repositories.Abstract;
using ProductCatalog.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductCatalog.DataAccess.NHibernate.Repositories.Concrete
{
    public class AccountRepository : HibernateRepository<Account>, IAccountRepository
    {
        //private readonly ISession _session;

        //public AccountRepository(ISession session) : base(session)
        //{
        //    _session = session;
        //}
    }
}
