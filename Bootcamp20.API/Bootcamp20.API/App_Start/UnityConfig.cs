using System.Web.Http;
using Bootcamp20.API.BussineesLogic.Service;
using Bootcamp20.API.BussineesLogic.Service.Master;
using Bootcamp20.API.Common.Repository;
using Bootcamp20.API.Common.Repository.Master;
using Unity;
using Unity.WebApi;

namespace Bootcamp20.API
{
    public static class UnityConfig
    {
        public static void RegisterComponents()
        {
			var container = new UnityContainer();

            // register all your components with the container here
            // it is NOT necessary to register your controllers

            // e.g. container.RegisterType<ITestService, TestService>();
            container.RegisterType<ISupplierService, SupplierService>();
            container.RegisterType<ISupplierRepository, SupplierRepository>();
            container.RegisterType<IItemService, ItemService>();
            container.RegisterType<IItemRepository, ItemRepository>();
            GlobalConfiguration.Configuration.DependencyResolver = new UnityDependencyResolver(container);
        }
    }
}