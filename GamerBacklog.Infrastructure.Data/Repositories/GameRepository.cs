using GamerBacklog.Domain.Entities;
using System.Linq;
using System.Collections.Generic;
using GamerBacklog.Domain.Interfaces.Repositories;

namespace GamerBacklog.Infrastructure.Data.Repositories
{
    public class GameRepository : RepositoryBase<Game>, IGameRepository
    {
        public new void Add(Game obj)
        {
         
            List<Platform> platforms = new List<Platform>();   
            foreach (var item in obj.Platforms)
            {
                platforms.Add(Db.Platforms.Find(item.PlatformId));
            }

            obj.Platforms = platforms;
            Db.Games.Add(obj);
            Db.SaveChanges();
        }

        public IEnumerable<Game> BuscarPorNome(string nome)
        {
            return Db.Games.Where(g => g.Nome.Contains(nome));
        }
    }
}
