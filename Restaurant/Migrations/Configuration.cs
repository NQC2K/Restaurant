namespace Restaurant.Migrations
{
    using Restaurant.Models;
    using System.Data.Entity.Migrations;

    internal sealed class Configuration : DbMigrationsConfiguration<Restaurant.DAL.FoodDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(Restaurant.DAL.FoodDbContext context)
        {
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method
            //  to avoid creating duplicate seed data.
            context.Roles.AddOrUpdate(
                new Role
                {
                    Id = 1,
                    Name = "SuperAdmin"
                },
                new Role
                {
                    Id = 2,
                    Name = "Admin"
                },
                new Role
                {
                    Id = 3,
                    Name = "User"
                });
            context.Users.AddOrUpdate(
                new User
                {
                    UserId = "user1",
                    UserName = "Test",
                    Password = "123",
                    RoleId = 1
                },
                new User
                {
                    UserId = "user2",
                    UserName = "Test2",
                    Password = "123",
                    RoleId = 2
                },
                new User
                {
                    UserId = "user3",
                    UserName = "Test3",
                    Password = "123",
                    RoleId = 3
                });
            context.Foods.AddOrUpdate(
            new Food
            {
                FoodID = 1,
                FoodName = "Mandu",
                CateId = 1,
                Description = "Updating...",
                Price = 50000,                
                PriceDiscount = 30000,
                Image = "food-1.png"
            },
            new Food
            {
                FoodID = 2,
                FoodName = "Hamburger",
                CateId = 2,
                Description = "Updating...",
                Price = 50000,
                PriceDiscount = 30000,
                Image = "food-2.png"
            },
            new Food
            {
                FoodID = 3,
                FoodName = "Pizza",
                CateId = 3,
                Description = "Updating...",
                Price = 50000,
                PriceDiscount = 30000,
                Image = "food-3.png"
            },
            new Food
            {
                FoodID = 4,
                FoodName = "Hamburger",
                CateId = 2,
                Description = "Updating...",
                Price = 50000,
                PriceDiscount = 30000,
                Image = "food-4.png"
            },
            new Food
            {
                FoodID = 5,
                FoodName = "Pizza",
                CateId = 3,
                Description = "Updating...",
                Price = 50000,
                PriceDiscount = 30000,
                Image = "food-5.png"
            },
            new Food
            {
                FoodID = 6,
                FoodName = "Hamburger",
                CateId = 2,
                Description = "Updating...",
                Price = 50000,
                PriceDiscount = 30000,
                Image = "food-7.png"
            },
            new Food
            {
                FoodID = 7,
                FoodName = "Hamburger",
                CateId = 2,
                Description = "Updating...",
                Price = 50000,
                PriceDiscount = 30000,
                Image = "food-2.png"
            },
            new Food
            {
                FoodID = 8,
                FoodName = "Pizza",
                CateId = 3,
                Description = "Updating...",
                Price = 50000,
                PriceDiscount = 30000,
                Image = "food-6.png"
            },
            new Food
            {
                FoodID = 9,
                FoodName = "Pizza",
                CateId = 3,
                Description = "Updating...",
                Price = 50000,
                PriceDiscount = 30000,
                Image = "food-8.png"
            },
            new Food
            {
                FoodID = 10,
                FoodName = "Mandu",
                CateId = 1,
                Description = "Updating...",
                Price = 50000,
                PriceDiscount = 30000,
                Image = "food-1.png"
            });
            context.SaveChanges();
        }
    }
}