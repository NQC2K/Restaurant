using Restaurant.Models;
using System.Data.Entity;


namespace Restaurant.DAL
{
    public class FoodDbContext : DbContext
    {
        public FoodDbContext() : base("ConnectionString")
        {
        }
        public DbSet<Food> Foods { set; get; }
        public DbSet<Order> Orders { set; get; }
        public DbSet<OrderDetail> OrderDetails { set; get; }
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }
    }
}