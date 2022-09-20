using Autofac;
using Autofac.Extras.DynamicProxy;
using AutoMapper;
using Castle.DynamicProxy;
using ProductCatalog.Business.Services.Abstract;
using ProductCatalog.Business.Services.Concrete;
using ProductCatalog.Core.Utilities.Interceptors;
using ProductCatalog.Core.Utilities.Security.JWT;
using ProductCatalog.DataAccess.NHibernate.Repositories.Abstract;
using ProductCatalog.DataAccess.NHibernate.Repositories.Concrete;
using ProductCatalog.Entities.MappingProfiles;

namespace ProductCatalog.Business.DependecyResolvers.Autofac
{
    public class BusinessModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {

            builder.RegisterType<ProductService>().As<IProductService>().SingleInstance();
            builder.RegisterType<ProductRepository>().As<IProductRepository>().SingleInstance();

            builder.RegisterType<CategoryService>().As<ICategoryService>().SingleInstance();
            builder.RegisterType<CategoryRepository>().As<ICategoryRepository>().SingleInstance();


            builder.RegisterType<OfferService>().As<IOfferService>().SingleInstance();
            builder.RegisterType<OfferRepository>().As<IOfferRepository>().SingleInstance();

            builder.RegisterType<UserService>().As<IUserService>();
            builder.RegisterType<UserRepository>().As<IUserRepository>();

            builder.RegisterType<AuthService>().As<IAuthService>();
            builder.RegisterType<JwtHelper>().As<ITokenHelper>();


            var assembly = System.Reflection.Assembly.GetExecutingAssembly();

            builder.RegisterAssemblyTypes(assembly).AsImplementedInterfaces()
                .EnableInterfaceInterceptors(new ProxyGenerationOptions()
                {
                    Selector = new AspectInterceptorSelector()
                }).SingleInstance();

        }
    }
}
