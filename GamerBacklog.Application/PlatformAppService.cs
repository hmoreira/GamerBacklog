using System.Collections.Generic;
using GamerBacklog.Application.Interfaces;
using GamerBacklog.Domain.Entities;
using GamerBacklog.Domain.Interfaces.Services;

namespace GamerBacklog.Application
{
    public class PlatformAppService : AppServiceBase<Platform>, IPlatformAppService
    {
        private readonly IPlatformService _platformService;

        public PlatformAppService(IPlatformService platformService) : base(platformService)
        {
            _platformService = platformService;
        }

        public IEnumerable<Platform> BuscarPorNome(string nome)
        {
            return _platformService.BuscarPorNome(nome);
        }
    }
}
