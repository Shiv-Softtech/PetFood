using System.Web.Mvc;
using Unity;
using Unity.Mvc5;
using PetFood.Data;
using PetFood.Repository;
using PetFood.Service;

namespace PetFood
{
    public static class UnityConfig
    {
        public static void RegisterComponents()
        {
			var container = new UnityContainer();
            
            // register all your components with the container here
            // it is NOT necessary to register your controllers
            
        container.RegisterType<IPetFoodFactoryData, PetFoodFactoryData>();
        container.RegisterType<IUserRepository, UserRepository>();
        container.RegisterType<IUserService, UserService>();
        container.RegisterType<IProductRepository, ProductRepository>();
        container.RegisterType<IProductService, ProductService>();
          

            
            DependencyResolver.SetResolver(new UnityDependencyResolver(container));
        }
    }
}