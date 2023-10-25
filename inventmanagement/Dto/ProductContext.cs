using Microsoft.EntityFrameworkCore;

namespace inventmanagement.Dto
{
    public class ProductContext:DbContext
    {
        public ProductContext(DbContextOptions options):base(options) { }
        public DbSet<Product> Products { get; set; }
    }
}
