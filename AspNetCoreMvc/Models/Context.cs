using Microsoft.EntityFrameworkCore;

namespace AspNetCoreMvc.Models
{
    public class Context : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=(localdb)\\MSSQLLocalDB; " +
                "Database=Northwind; " +
                "Integrated Security=True");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<OrderDetails>()
                  .HasKey(od => new { od.OrderId, od.ProductId });
        }

        public DbSet<Product> Products { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<Customer> Customers { get; set; }
        public DbSet<UserMaster> UserMasters { get; set; }
        public DbSet<OrderDetails> OrderDetails { get; set; }
    }
}
