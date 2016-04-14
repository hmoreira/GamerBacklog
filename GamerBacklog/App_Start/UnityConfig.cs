using System.Web.Mvc;
using Microsoft.Practices.Unity;
using Unity.Mvc5;
using Domain.Model;  

namespace GamerBacklog
{
    public static class UnityConfig
    {
        public static void RegisterComponents()
        {
			var container = new UnityContainer();
            container.RegisterType<Repositories.IRepository<Game, int>, Repositories.GameRepository>();                                      
            DependencyResolver.SetResolver(new UnityDependencyResolver(container));
        }
    }
}