using System.Data.Entity;
using Microsoft.AspNet.Identity.EntityFramework;

namespace DAL.Models
{
    public class ShopContext : IdentityDbContext<User>
    {
        public ShopContext() : base("DefaultConnection")
        { }
        public DbSet<Order> Orders { get; set; }
        public DbSet<OrderDetail> OrderDetails { get; set; }
        public DbSet<Product> Products { get; set; }
    }
}
