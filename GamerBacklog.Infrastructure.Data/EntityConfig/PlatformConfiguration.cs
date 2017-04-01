using System.Data.Entity.ModelConfiguration;
using GamerBacklog.Domain.Entities;

namespace GamerBacklog.Infrastructure.Data.EntityConfig
{
    public class PlatformConfiguration : EntityTypeConfiguration<Platform>
    {
        public PlatformConfiguration()
        {
            HasKey(p => p.PlatformId);           
            Property(p => p.Nome)
                .IsRequired()
                .HasMaxLength(50);
        }
    }
}
