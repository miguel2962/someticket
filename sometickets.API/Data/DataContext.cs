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

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Category>().HasIndex(x => x.Description).IsUnique();
        }
    }
}
