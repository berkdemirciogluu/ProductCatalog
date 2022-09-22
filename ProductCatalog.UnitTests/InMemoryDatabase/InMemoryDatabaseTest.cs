using NHibernate;
using NHibernate.ByteCode.Castle;
using NHibernate.Cfg;
using NHibernate.Dialect;
using NHibernate.Driver;
using NHibernate.Tool.hbm2ddl;
using System.Reflection;
using Environment = NHibernate.Cfg.Environment;

namespace ProductCatalog.UnitTests.InMemoryDatabase
{
    public class InMemoryDatabaseTest : IDisposable
	{
		private static Configuration Configuration;
		private static ISessionFactory SessionFactory;
		protected ISession session;

		public InMemoryDatabaseTest(Assembly assemblyContainingMapping)
		{
			if (Configuration == null)
			{
				Configuration = new Configuration ()
					.SetProperty(Environment.ReleaseConnections, "on_close")
					.SetProperty(Environment.Dialect, typeof(SQLiteDialect).AssemblyQualifiedName)
					.SetProperty(Environment.ConnectionDriver, typeof(SQLite20Driver).AssemblyQualifiedName)
					.SetProperty(Environment.ConnectionString, "data source=:memory:")
					.SetProperty(Environment.ProxyFactoryFactoryClass, typeof(ProxyFactoryFactory).AssemblyQualifiedName)
					.AddAssembly(assemblyContainingMapping);

				SessionFactory = Configuration.BuildSessionFactory();
			}

			session = SessionFactory.OpenSession();

			new SchemaExport(Configuration).Execute(true, false, false, session.Connection, Console.Out);
		}

		public void Dispose()
		{
			session.Dispose();
		}
	}
}
