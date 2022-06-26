using Domain.Models;
using Microsoft.EntityFrameworkCore;

namespace Persistance
{
    public class DbContext : Microsoft.EntityFrameworkCore.DbContext
    {
        public DbSet<Image> Images => Set<Image>();
        public DbSet<ImageGroup> ImageGroups => Set<ImageGroup>();

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseInMemoryDatabase("database");
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder
                .Entity<Image>()
                .HasKey(e => e.Id);
            builder
                .Entity<Image>()
                .HasOne(i => i.ImageGroup)
                .WithMany(i => i.Images)
                .HasForeignKey(i => i.ImageGroupId);

            builder
                .Entity<ImageGroup>()
                .HasKey(e => e.Id);
            builder
                .Entity<ImageGroup>()
                .HasMany(i => i.Images)
                .WithOne(i => i.ImageGroup)
                .HasForeignKey(i => i.ImageGroupId);

            base.OnModelCreating(builder);
        }
    }
}
