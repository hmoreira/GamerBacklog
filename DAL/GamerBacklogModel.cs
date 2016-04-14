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

        public virtual DbSet<Game> Games { get; set; }
        public virtual DbSet<GamePlatform> GamePlatforms { get; set; }
        public virtual DbSet<Platform> Platforms { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Game>()
                .HasMany(e => e.GamePlatforms)
                .WithRequired(e => e.Game)
                .WillCascadeOnDelete(false);            
        }
    }
}
