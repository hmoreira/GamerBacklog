using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using GamerBacklog.Domain.Entities;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Data.Entity.ModelConfiguration;
using GamerBacklog.Infrastructure.Data.EntityConfig;

namespace GamerBacklog.Infrastructure.Data
{
    public class GamerBacklogContext : DbContext       
    {
        public GamerBacklogContext() : base("GamerBacklog") { }

        public DbSet<Platform> Platforms { get; set; }
        public DbSet<Game> Games { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
            modelBuilder.Conventions.Remove<OneToManyCascadeDeleteConvention>();
            modelBuilder.Conventions.Remove<ManyToManyCascadeDeleteConvention>();

            modelBuilder.Properties()
                .Where(p => p.Name == p.ReflectedType.Name + "Id")
                .Configure(p => p.IsKey());

            modelBuilder.Properties<string>()
                .Configure(p => p.HasColumnType("varchar"));

            modelBuilder.Properties<string>()
                .Configure(p => p.HasMaxLength(100));

            modelBuilder.Configurations.Add(new PlatformConfiguration());
            modelBuilder.Configurations.Add(new GameConfiguration());
        }
    }
}
