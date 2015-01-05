using System.Web.Mvc;
using Microsoft.Practices.Unity;
using Unity.Mvc3;
using WebShop.Data;
using WebShop.Data.Repositories;
using WebShop.Services;

namespace WebShop
{
    public static class Bootstrapper
    {
        public static void Initialise()
        {
            var container = BuildUnityContainer();
            DependencyResolver.SetResolver(new UnityDependencyResolver(container));
        }

        private static IUnityContainer BuildUnityContainer()
        {
            var container = new UnityContainer();

            container.RegisterType<IRepositoryFactory, RepositoryFactory>();
            container.RegisterType<IUserRepository, UserRepository>();
            
            container.RegisterType<IServiceFactory, ServiceFactory>();
            container.RegisterType<IUserService, UserService>();

            container.RegisterType<IApplicationConfig, ApplicationConfig>();

            return container;
        }
    }
}