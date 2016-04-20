namespace DAL
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;
    using Domain.Model;

    public partial class GamerBacklogModel : DbContext
    {
        public GamerBacklogModel()
            : base("name=GamerBacklog")
        {
        }

        static GamerBacklogModel() 
        {
            Database.SetInitializer(new DropCreateDatabaseIfModelChanges<GamerBacklogModel>()); 
        } 

        public virtual DbSet<Game> Game { get; set; }
        public virtual DbSet<GamePlatform> GamePlatform { get; set; }
        public virtual DbSet<Platform> Platform { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
                            
        }
    }
}
