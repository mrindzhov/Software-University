namespace StoreDatabase
{
    using Models;
    using System;
    using System.Data.Entity.Migrations;

    class StartUp
    {
        static void Main(string[] args)
        {

            SalesContext context = new SalesContext();
            //context.Database.Initialize(true);

            //context.Products.Add(new Product()
            //{
            //    Name = "MegaQko3Bate",
            //    Quantity = 2,
            //    Price = 25.23m
            //});
            context.Customers.Add(new Customer()
            {
                FirstName = "proba",
                LastName = "proba"
            });
            context.SaveChanges();
            //context.Customers.AddRange(new[]
            //{
            //     new Customer
            //     {
            //         FirstName = "novo2",
            //         LastName = "novo2"
            //     }
            //});

            //context.SaveChanges();
            //foreach (var customer in context.Customers)
            //{
            //    Console.WriteLine(customer.Age);
            //}

        }
    }
}
