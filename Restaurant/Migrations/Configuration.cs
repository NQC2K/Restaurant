namespace Restaurant.Migrations
{
    using Restaurant.Models;
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

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
            }
            );
            context.SaveChanges();
        }
    }
}
