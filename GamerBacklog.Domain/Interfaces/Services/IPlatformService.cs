using System.Collections.Generic;
using GamerBacklog.Domain.Entities;

namespace GamerBacklog.Domain.Interfaces.Services
{
    public interface IPlatformService : IServiceBase<Platform>
    {
        IEnumerable<Platform> BuscarPorNome(string nome);
    }
}
