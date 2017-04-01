using System.Collections.Generic;

namespace GamerBacklog.Domain.Entities
{
    public class Game
    {
        public int GameId { get; set; }
        public string Nome { get; set; }
        public virtual ICollection<Platform> Platforms { get; set; }
    }
}
