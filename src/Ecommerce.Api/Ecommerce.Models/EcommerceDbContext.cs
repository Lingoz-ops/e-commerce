using Ecommerce.Models.Models;
using Microsoft.EntityFrameworkCore;

namespace Ecommerce.Models
{
    public class EcommerceDBContext : DbContext
    {

        public EcommerceDBContext(DbContextOptions opts) : base(opts)
        {
        }
        public DbSet<Customer> Customers { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<Product> Products { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer("Main;TrustServerCertificate=True");
            }
        }
    }

}
