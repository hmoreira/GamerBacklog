namespace DAL
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;
    using Domain.Model;  

    [Table("Game")]
    public partial class GameDAL
    {
        public GameDAL()
        {
            GamePlatforms = new HashSet<GamePlatform>();
        }
                
        private GamerBacklogModel db = new GamerBacklogModel();
        public ICollection<GamePlatform> GamePlatforms;

        public Game GetDetails(int? id)
        {
            Game game = db.Game.Find(id);
            if (game == null)
                return new Game();
            else
                return game; 
        }
    }
}
