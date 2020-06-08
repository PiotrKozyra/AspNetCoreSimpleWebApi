using Microsoft.EntityFrameworkCore;
using WholesaleApi.Models;

namespace WholesaleApi.Data {
    public class WholesaleContext : DbContext {
        public WholesaleContext (DbContextOptions<WholesaleContext> opt) : base (opt) {

        }

        public DbSet<Category> Categories { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<Supplier> Suppliers { get; set; }

    }
}