using GamerBacklog.Application;
using GamerBacklog.Application.Interfaces;
using GamerBacklog.Domain.Interfaces.Repositories;
using GamerBacklog.Domain.Interfaces.Services;
using GamerBacklog.Domain.Services;
using GamerBacklog.Infrastructure.Data.Repositories;
using Microsoft.Practices.Unity;

namespace GamerBacklog.Infrastructure.CrossCutting.IoC
{
    public class UnityConfiguration
    {
        public void Register(IUnityContainer container)
        {
            container.RegisterType(typeof(IAppServiceBase<>), typeof(AppServiceBase<>));
            container.RegisterType<IGameAppService, GameAppService>();
            container.RegisterType<IPlatformAppService, PlatformAppService>();

            container.RegisterType(typeof(IServiceBase<>), typeof(ServiceBase<>));
            container.RegisterType<IPlatformService, PlatformService>();
            container.RegisterType<IGameService, GameService>();

            container.RegisterType(typeof(IRepositoryBase<>), typeof(RepositoryBase<>));
            container.RegisterType<IPlatformRepository, PlatformRepository>();
            container.RegisterType<IGameRepository, GameRepository>();

            //container.RegisterType<AbstractValidator<InfoRetorno>, InfoRetornoValidation>();
        }
    }
}
