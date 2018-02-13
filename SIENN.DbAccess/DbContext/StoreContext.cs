using Microsoft.EntityFrameworkCore;
using SIENN.DbAccess.Data;

namespace SIENN.DbAccess.Repositories
{
    public class StoreContext : DbContext
    {
        public StoreContext(DbContextOptions<StoreContext> options) : base(options)
        {  }
      
        public DbSet<Category> Categories { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<Type> Types { get; set; }
        public DbSet<Unit> Units { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<ProductCategory>()
                .HasKey(t => new { t.ProductId, t.CategoryId });

            //TODO make unique code for all codes
            modelBuilder.Entity<Product>()
                .HasIndex(u => u.Code)
                .IsUnique();
        }
    }
}

