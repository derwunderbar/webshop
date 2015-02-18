using System.Web.Http;
using System.Web.Mvc;
using Microsoft.Practices.Unity;
using Unity.Mvc3;
using WebShop.Data;
using WebShop.Data.Repositories;
using WebShop.Services;
using WebShop.Utilities;

namespace WebShop
{
    public static class Bootstrapper
    {
        public static void Initialise(HttpConfiguration config)
        {
            var container = BuildUnityContainer();
            DependencyResolver.SetResolver(new UnityDependencyResolver(container));
            config.DependencyResolver = new Unity.WebApi.UnityDependencyResolver(container);
        }

        private static IUnityContainer BuildUnityContainer()
        {
            var container = new UnityContainer();

            container.RegisterType<IRepositoryFactory, RepositoryFactory>();
            container.RegisterType<IUserRepository, UserRepository>();
            
            container.RegisterType<IServiceFactory, ServiceFactory>();
            container.RegisterType<IUserService, UserService>();

            container.RegisterType<ICatalogFacade, CatalogFacade>();

            container.RegisterType<IApplicationConfig, ApplicationConfig>();

            return container;
        }
    }
}