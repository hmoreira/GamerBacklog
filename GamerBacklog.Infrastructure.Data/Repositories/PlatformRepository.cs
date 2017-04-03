using GamerBacklog.Domain.Entities;
using System.Collections.Generic;
using GamerBacklog.Domain.Interfaces;
using System.Linq;
using GamerBacklog.Domain.Interfaces.Repositories;

namespace GamerBacklog.Infrastructure.Data.Repositories
{
    public class PlatformRepository : RepositoryBase<Platform>, IPlatformRepository
    {
        public IEnumerable<Platform> BuscarPorNome(string nome)
        {
            return Db.Platforms.Where(g => g.Nome.Contains(nome));
        }
    }
}
