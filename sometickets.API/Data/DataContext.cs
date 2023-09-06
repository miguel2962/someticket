using Microsoft.EntityFrameworkCore;
using sometickets.Shared.Entities;

namespace sometickets.API.Data
{
    public class DataContext: DbContext
    {
        public DataContext(DbContextOptions<DataContext> options): base(options)    
        {

            
        }

        public DbSet<Category> Categories { get; set; }
        public DbSet<WorkTypes> WorkTypes { get; set; }
        public DbSet<ClienteType> ClienteType { get; set; }
        public DbSet<UserRol> UserRols { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Category>().HasIndex(x => x.Description).IsUnique();
            modelBuilder.Entity<WorkTypes>().HasIndex(x => x.Description).IsUnique();
            modelBuilder.Entity<ClienteType>().HasIndex(x => x.Description).IsUnique();
            modelBuilder.Entity<UserRol>().HasIndex(x => x.Description).IsUnique();
        }
    }
}
