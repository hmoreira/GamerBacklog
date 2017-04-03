using System;
using System.Collections.Generic;
using GamerBacklog.Domain.Entities;
using GamerBacklog.Domain.Interfaces.Repositories;
using GamerBacklog.Domain.Interfaces.Services;

namespace GamerBacklog.Domain.Services
{
    public class PlatformService : ServiceBase<Platform>, IPlatformService
    {
        private readonly IPlatformRepository _platformRepository;

        public PlatformService(IPlatformRepository platformRepository) : base(platformRepository)
        {
            _platformRepository = platformRepository;
        }

        public IEnumerable<Platform> BuscarPorNome(string nome)
        {
            return _platformRepository.BuscarPorNome(nome);
        }
    }
}
