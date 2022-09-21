﻿using ProductCatalog.DataAccess.NHibernate.Repositories.Base;
using ProductCatalog.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductCatalog.DataAccess.NHibernate.Repositories.Abstract
{
    public interface IOperationClaimRepository : IHibernateRepository<OperationClaim>
    {
    }
}
