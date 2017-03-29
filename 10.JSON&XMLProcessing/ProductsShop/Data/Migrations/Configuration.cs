namespace Data.Migrations
{
    using Models;
    using Newtonsoft.Json;
    using System;
    using System.Collections.Generic;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.IO;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<Data.ProductsShopContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
            AutomaticMigrationDataLossAllowed = true;
        }
        
        protected override void Seed(ProductsShopContext ctx)
        {
            //TO DO : FIX paths


            //ctx.SaveChanges();

        }

        private static void SeedCategories(ProductsShopContext ctx)
        {
            string jsonFile = File.ReadAllText("./Import-Json-Resources/categories.json");
            IEnumerable<Category> categories = JsonConvert.DeserializeObject<IEnumerable<Category>>(jsonFile);

            int productsCount = ctx.Products.Count();
            Random rnd = new Random();
            foreach (Category category in categories)
            {
                for (int i = 0; i < productsCount / 3; i++)
                {
                    Product product = ctx.Products.Find(rnd.Next(1, productsCount + 1));
                    category.Products.Add(product);
                }
            }

            ctx.Categories.AddRange(categories);
        }

        private static void SeedProducts(ProductsShopContext ctx)
        {
            string jsonFile = File.ReadAllText("/Import-Json-Resources/products.json");
            IEnumerable<Product> products = JsonConvert.DeserializeObject<IEnumerable<Product>>(jsonFile);

            Random rand = new Random();
            foreach (Product product in products)
            {
                double shouldHaveBuyer = rand.NextDouble();
                product.SellerId = rand.Next(1, ctx.Users.Count() + 1);
                if (shouldHaveBuyer <= 0.9)
                {
                    product.BuyerId = rand.Next(1, ctx.Users.Count() + 1);
                }
            }

            ctx.Products.AddRange(products);

        }

        private static void SeedUsers(ProductsShopContext ctx)
        {
            string jsonFile = File.ReadAllText("./Import-Json-Resources/users.json");
            IEnumerable<User> users = JsonConvert.DeserializeObject<IEnumerable<User>>(jsonFile);
            ctx.Users.AddRange(users);
        }

    }
}