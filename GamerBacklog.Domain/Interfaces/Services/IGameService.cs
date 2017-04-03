using System.Collections.Generic;
using GamerBacklog.Domain.Entities;

namespace GamerBacklog.Domain.Interfaces.Services
{
    public interface IGameService : IServiceBase<Game>
    {
        IEnumerable<Game> BuscarPorNome(string nome);
    }
}
