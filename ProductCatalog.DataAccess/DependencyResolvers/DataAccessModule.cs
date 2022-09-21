using Microsoft.Extensions.DependencyInjection;
using ProductCatalog.Core.Utilities.IoC;
using ProductCatalog.DataAccess.NHibernate.Repositories.Abstract;
using ProductCatalog.DataAccess.NHibernate.Repositories.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductCatalog.DataAccess.DependencyResolvers
{
    public static class DataAccessModule 
    {
        public static void AddDataAccessServices(this IServiceCollection services)
        {
            services.AddSingleton<IOperationClaimRepository, OperationClaimRepository>();
            services.AddSingleton<IUserOperationClaimRepository, UserOperationClaimRepository>();
        }
    }
}
