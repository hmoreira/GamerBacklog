using System.Collections.Generic;

namespace GamerBacklog.Domain.Entities
{
    public class Platform
    {
        public int PlatformId { get; set; }
        public string Nome { get; set; }        
      
        public virtual ICollection<Game> Games { get; set; }
    }
}
