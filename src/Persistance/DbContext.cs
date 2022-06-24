using Domain.Models;
using Microsoft.EntityFrameworkCore;

namespace Persistance
{
    public class DbContext : Microsoft.EntityFrameworkCore.DbContext
    {
        public DbSet<Image> Images => Set<Image>();

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseInMemoryDatabase("database");
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<Image>(e => e.HasKey(e => e.Id));

            base.OnModelCreating(builder);
        }
    }
}
