using System.Collections.Generic;
using GamerBacklog.Domain.Entities;

namespace GamerBacklog.Domain.Interfaces.Repositories
{
    public interface IGameRepository : IRepositoryBase<Game>
    {
        IEnumerable<Game> BuscarPorNome(string nome);
    }
}
