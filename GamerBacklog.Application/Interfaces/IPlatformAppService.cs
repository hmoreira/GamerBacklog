using System.Collections.Generic;
using GamerBacklog.Domain.Entities;

namespace GamerBacklog.Application.Interfaces
{
    public interface IPlatformAppService : IAppServiceBase<Platform>
    {
        IEnumerable<Platform> BuscarPorNome(string nome);
    }
}
