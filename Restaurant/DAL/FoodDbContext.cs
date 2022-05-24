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
    }
}