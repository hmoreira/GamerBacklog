using System.Collections.Generic;
using GamerBacklog.Domain.Entities;

namespace GamerBacklog.Application.Interfaces
{
    public interface IGameAppService : IAppServiceBase<Game>
    {
        IEnumerable<Game> BuscarPorNome(string nome);
    }
}
