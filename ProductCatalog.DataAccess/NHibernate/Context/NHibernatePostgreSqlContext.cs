using FluentNHibernate.Cfg;
using FluentNHibernate.Cfg.Db;
using Microsoft.Extensions.Configuration;
using NHibernate;
using NHibernate.Tool.hbm2ddl;
using System.Reflection;

namespace ProductCatalog.DataAccess.NHibernate.Context
{
    public class NHibernatePostgreSqlContext
    {
        private static ISessionFactory _session;
        //public IConfiguration _configuration { get; }
        //private string host;

        //public NHibernatePostgreSqlContext(IConfiguration configuration)
        //{
        //    _configuration = configuration;
        //    host = _configuration.GetRequiredSection

        private static ISessionFactory CreateSession()
        {
            if (_session != null)
            {
                return _session;
            }

            FluentConfiguration _config = Fluently.Configure().
                Database(PostgreSQLConfiguration.Standard.ConnectionString(c => c.Host("localhost").Port(5432).Database("productcatalog").Username("postgres").Password("hilal71OKTAY11")))
                .Mappings(m => m.FluentMappings.AddFromAssembly(Assembly.GetExecutingAssembly()))
                .ExposeConfiguration(cfg => new SchemaUpdate(cfg).Execute(true, true)); //false,true

             _session = _config.BuildSessionFactory();

            return _session;
        }

        public static ISession SessionOpen()
        {
            return CreateSession().OpenSession();
        }
    }
}
