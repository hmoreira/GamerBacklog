using System.Data.Entity.ModelConfiguration;
using GamerBacklog.Domain.Entities;

namespace GamerBacklog.Infrastructure.Data.EntityConfig
{
    public class GameConfiguration : EntityTypeConfiguration<Game>
    {
        public GameConfiguration()
        {
            HasKey(p => p.GameId);
            HasMany(p => p.Platforms)
                .WithMany(p => p.Games)
                .Map(m =>
                {
                    m.MapLeftKey("GameId");
                    m.MapRightKey("PlatformId");
                    m.ToTable("GamePlatform");
                });            
        }
    }
}
