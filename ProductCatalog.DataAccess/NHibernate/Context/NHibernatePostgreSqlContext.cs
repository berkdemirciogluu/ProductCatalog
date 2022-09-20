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
        private static ISessionFactory CreateSession()
        {
            if (_session != null)
            {
                return _session;
            }

            var configuration = GetConfiguration();
            var conString = configuration.GetConnectionString("PostgreSqlConnection");

            FluentConfiguration _config = Fluently.Configure()
                .Database(PostgreSQLConfiguration.Standard
                .ConnectionString(c => c.Is(conString)))
                //Database(PostgreSQLConfiguration.Standard.ConnectionString(c => c.Host("localhost").Port(5432).Database("productcatalog").Username("postgres").Password("hilal71OKTAY11")))
                .Mappings(m => m.FluentMappings.AddFromAssembly(Assembly.GetExecutingAssembly()))
                .ExposeConfiguration(cfg => new SchemaUpdate(cfg).Execute(true, true)); //false,true

             _session = _config.BuildSessionFactory();

            return _session;
        }

        public static ISession SessionOpen()
        {
            return CreateSession().OpenSession();
        }

        public static IConfigurationRoot GetConfiguration()
        {
            var builder = new ConfigurationBuilder().SetBasePath(Directory.GetCurrentDirectory()).AddJsonFile("appsettings.json", optional: true,reloadOnChange:true);
            return builder.Build();

        }

    }
}
