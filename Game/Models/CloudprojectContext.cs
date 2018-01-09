using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace Game.Models
{
    public partial class CloudprojectContext : DbContext
    {
        public virtual DbSet<Games> Games { get; set; }

        public CloudprojectContext(DbContextOptions<CloudprojectContext> options)
    : base(options)
        { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Games>(entity =>
            {
                entity.HasKey(e => e.GameId);

                entity.Property(e => e.Developer).IsRequired();

                entity.Property(e => e.GameName).IsRequired();

                entity.Property(e => e.ReleaseYear).IsRequired();

                entity.Property(e => e.Score).IsRequired();
            });
        }
    }
}
