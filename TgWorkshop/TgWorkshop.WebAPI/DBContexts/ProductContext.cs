using Microsoft.EntityFrameworkCore;
using TgWorkshop.WebAPI.Models;

namespace TgWorkshop.WebAPI.DBContexts
{
    public class ProductContext:DbContext
    {
        public ProductContext(DbContextOptions<ProductContext> options) : base(options)
        {

        }
        public DbSet<Product> Products { get; set; }
        public DbSet<Category> Categories { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Category>().HasData(
                new Category { Id = 1, Name = "Kişisel Bakım", Description = "Cilt Bakımı" },
                new Category { Id = 2, Name = "Kişisel Bakım", Description = "Parfüm" },
                new Category { Id = 3, Name = "Kişisel Bakım", Description = "Güneş Bakım" }
                );
        }
    }
}
