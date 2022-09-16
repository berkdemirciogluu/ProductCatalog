using Microsoft.Extensions.DependencyInjection;
using NHibernate.Cfg;
using NHibernate.Cfg.MappingSchema;
using NHibernate.Dialect;
using NHibernate.Mapping.ByCode;
using ProductCatalog.DataAccess.NHibernate.Mappings;

namespace ProductCatalog.WebAPI.Entensions
{
    //public static class NHibernateExtensions
    //{
    //    // This extension allows us to use NHibernate Database by performing a mapping process. 
    //    // At the starting stage of the program, this is executed and adds related services.
    //    public static IServiceCollection AddNHibernatePosgreSql(this IServiceCollection services, string connectionString)
    //    {
    //        var mapper = new ModelMapper();
    //        mapper.AddMappings(typeof(DefaultMapping).Assembly.ExportedTypes);
    //        HbmMapping domainMapping = mapper.CompileMappingForAllExplicitlyAddedEntities();

    //        var configuration = new Configuration();
    //        configuration.DataBaseIntegration(c =>
    //        {
    //            c.Dialect<PostgreSQLDialect>();
    //            c.ConnectionString = connectionString;
    //            c.KeywordsAutoImport = Hbm2DDLKeyWords.AutoQuote;
    //            c.SchemaAction = SchemaAutoAction.Create;
    //            c.LogFormattedSql = true;
    //            c.LogSqlInConsole = true;
    //        });
    //        configuration.AddMapping(domainMapping);

    //        var sessionFactory = configuration.BuildSessionFactory();

    //        services.AddSingleton(sessionFactory);
    //        services.AddScoped(factory => sessionFactory.OpenSession());

    //        return services;
    //    }
    //}
}
