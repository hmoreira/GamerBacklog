using GamerBacklog.Infrastructure.CrossCutting.IoC;
using Microsoft.Practices.Unity;

namespace GamerBacklog.MVC
{
    public static class UnityConfig
    {
        private static UnityContainer _container;

        public static void RegisterComponents()
        {
            _container = new UnityContainer();

            new UnityConfiguration().Register(_container);
        }

        public static T Resolve<T>()
        {
            return _container.Resolve<T>();
        }
    }
}