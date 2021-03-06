﻿namespace Client.Methods
{
    using Data;
    using Models;
    using Newtonsoft.Json;
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;

    public static class JSONMethods
    {

        public static void ExportData(ProductsShopContext ctx)
        {
            ExportUsersAndProducts(ctx);
            ExportCategoriesByProductsCount(ctx);
            ExportUsersWithSells(ctx);
            ExportProductsInRangeToJSON(ctx);
        }

        public static void SeedData(ProductsShopContext ctx)
        {
            SeedUsers(ctx);
            SeedProducts(ctx);
            SeedCategories(ctx);
            ctx.SaveChanges();
        }

        private static void ExportUsersAndProducts(ProductsShopContext ctx)
        {
            var users = ctx.Users.Where(u => u.ProductsSold.Count > 0);
            var usersWithSells = new
            {
                usersCount = users.Count(),
                usersAndProducts = users
                    .OrderByDescending(u => u.ProductsSold.Count())
                    .ThenBy(u => u.LastName).Select(u => new
                    {
                        firstName = u.FirstName,
                        lastName = u.LastName,
                        age = u.Age,
                        soldProducts = new
                        {
                            count = u.ProductsSold.Count(),
                            products = u.ProductsSold.Select(p => new
                            {
                                name = p.Name,
                                price = p.Price,
                            })
                        }
                    })
            };

            string json = JsonConvert.SerializeObject(usersWithSells, Formatting.Indented);
            File.WriteAllText("../../../Export-Json/users-and-products.json", json);
        }

        private static void ExportCategoriesByProductsCount(ProductsShopContext ctx)
        {
            var categories = ctx.Categories.OrderBy(c => c.Name).Select(c => new
            {
                category = c.Name,
                productsCount = c.Products.Count(),
                averagePrice = c.Products.Average(p => p.Price),
                totalRevenue = c.Products.Sum(p => p.Price)
            });


            string json = JsonConvert.SerializeObject(categories, Formatting.Indented);
            File.WriteAllText("../../../Export-Json/categories-by-products.json", json);
        }

        private static void ExportUsersWithSells(ProductsShopContext ctx)
        {
            var users = ctx.Users
                            .Where(u => u.ProductsSold.Count() > 0)
                            .OrderBy(u => u.LastName)
                            .ThenBy(u => u.FirstName)
                            .Select(u => new
                            {
                                firstName = u.FirstName,
                                lastName = u.LastName,
                                soldProducts = u.ProductsSold.Select(p => new
                                {
                                    name = p.Name,
                                    price = p.Price,
                                    //buyerFirstName = p.Buyer.FirstName??"",
                                    buyerFirstName = p.Buyer.FirstName,
                                    buyerLastName = p.Buyer.LastName
                                })
                            });
            string json = JsonConvert.SerializeObject(users, Formatting.Indented);
            File.WriteAllText("../../../Export-Json/users-sold-products.json", json);
        }

        private static void ExportProductsInRangeToJSON(ProductsShopContext ctx)
        {
            var products = ctx.Products
                            .Where(p => p.Price >= 500 && p.Price <= 1000)
                            .Select(p => new
                            {
                                p.Name,
                                p.Price,
                                SellerName = (p.Seller.FirstName ?? "") + " " + p.Seller.LastName
                            })
                            .OrderBy(p => p.Price);
            string json = JsonConvert.SerializeObject(products, Formatting.Indented);
            System.IO.File.WriteAllText("../../../Export-Json/products-in-range.json", json);
        }

        private static void SeedCategories(ProductsShopContext ctx)
        {
            string jsonFile = File.ReadAllText("../../../Import-Json-Resources/categories.json");
            IEnumerable<Category> categories = JsonConvert.DeserializeObject<IEnumerable<Category>>(jsonFile);

            int productsCount = ctx.Products.Count();
            Random rnd = new Random();
            var products = ctx.Products;
            foreach (Category category in categories)
            {
                for (int i = 0; i < productsCount / 3; i++)
                {
                    Product product = products.Find(rnd.Next(1, productsCount + 1));
                    category.Products.Add(product);
                }
            }

            ctx.Categories.AddRange(categories);
            ctx.SaveChanges();

        }

        private static void SeedProducts(ProductsShopContext ctx)
        {
            string jsonFile = File.ReadAllText("../../../Import-Json-Resources/products.json");
            IEnumerable<Product> products = JsonConvert.DeserializeObject<IEnumerable<Product>>(jsonFile);

            Random rand = new Random();
            int usersCount = ctx.Users.Count();

            foreach (Product product in products)
            {
                double shouldHaveBuyer = rand.NextDouble();
                product.SellerId = rand.Next(1, usersCount + 1);
                if (shouldHaveBuyer <= 0.9)
                {
                    product.BuyerId = rand.Next(1, usersCount + 1);
                }
            }

            ctx.Products.AddRange(products);
            ctx.SaveChanges();
        }

        private static void SeedUsers(ProductsShopContext ctx)
        {
            string jsonFile = File.ReadAllText("../../../Import-Json-Resources/users.json");
            IEnumerable<User> users = JsonConvert.DeserializeObject<IEnumerable<User>>(jsonFile);
            ctx.Users.AddRange(users);
            ctx.SaveChanges();

        }
    }
}
