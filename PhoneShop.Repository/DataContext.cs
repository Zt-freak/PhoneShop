using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using PhoneShop.Models;

namespace PhoneShop.Repository
{
    public class DataContext : IdentityDbContext<User, IdentityRole<int>, int>
    {
        public DataContext(){}
        public DataContext(DbContextOptions options) : base(options){}

        public DbSet<Brand> Brands { get; set; }
        public DbSet<Department> Departments { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<ProductsPerOrder> ProductsPerOrders { get; set; }
        public DbSet<Product> Phones { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            //optionsBuilder.UseSqlServer("Server=localhost,1433;User Id=SA;Database=PhoneShop;Password=yourStrong(!)Password;");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<User>()
                .HasDiscriminator(u => u.Type)
                .HasValue<User>(-1)
                .HasValue<Employee>(0)
                .HasValue<Customer>(1);

            modelBuilder.Entity<ProductsPerOrder>()
                .HasKey(p => new { p.OrderId, p.ProductId });
        }
    }
}
