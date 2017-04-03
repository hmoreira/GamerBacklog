using GamerBacklog.Domain.Entities;
using System.Linq;
using System.Collections.Generic;
using GamerBacklog.Domain.Interfaces.Repositories;

namespace GamerBacklog.Infrastructure.Data.Repositories
{
    public class GameRepository : RepositoryBase<Game>, IGameRepository
    {
        public IEnumerable<Game> BuscarPorNome(string nome)
        {
            return Db.Games.Where(g => g.Nome.Contains(nome));
        }
    }
}
