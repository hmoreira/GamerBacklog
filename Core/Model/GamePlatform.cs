using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Model
{
    public class GamePlatform
    {
        public int Id { get; set; }
        public int GameId { get; set; }
        public int PlatformId { get; set; }
        public virtual ICollection<Game> Games { get; set; }
        public virtual ICollection<Platform> Platforms { get; set; }        
    }
}
