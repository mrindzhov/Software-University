namespace CarDealer.Client.Methods
{
    using Models;
    using Data;
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;
    using Newtonsoft.Json;

    public class JSONMethods
    {
        public static void ImportData(CarDealerContext ctx)
        {
            ImportSuppliersDataFromJSON(ctx);
            ImportPartsDataFromJSON(ctx);
            ImportCarsDataFromJSON(ctx);
            ImportCustomersDataFromJSON(ctx);
            ImportSalesRecords(ctx);
        }

        public static void ExportData(CarDealerContext ctx)
        {
            ExportCustomersTotalSales(ctx);

            ExportCarsWithParts(ctx);

            ExportLocalSuppliers(ctx);

            ExportOrderedCustomers(ctx);

            ExportToyotaCars(ctx);

            ExportSalesWithDiscount(ctx);
        }

        #region Export Methods

        private static void ExportSalesWithDiscount(CarDealerContext ctx)
        {
            var salesWithDiscout = ctx.Sales.Where(s => s.Discount != 0).ToList().Select(s => new
            {
                car = new
                {
                    s.Car.Make,
                    s.Car.Model,
                    s.Car.TravelledDistance
                },
                customerName = s.Customer.Name,
                s.Discount,
                price = s.Car.Parts.Sum(p => p.Price),
                priceWithDiscount = s.Car.Parts.Sum(p => p.Price) - (s.Car.Parts.Sum(p => p.Price) * (decimal)s.Discount)
            });
            string json = JsonConvert.SerializeObject(salesWithDiscout, Formatting.Indented);
            File.WriteAllText("../../../Export-Json/06.sales-discounts.json", json);
            //Console.WriteLine(json);
        }

        private static void ExportCustomersTotalSales(CarDealerContext ctx)
        {
            var customersTotalSales = ctx.Customers.Where(c => c.Sales.Count > 0).Select(c => new
            {
                fullName = c.Name,
                boughtCars = c.Sales.Count(),
                spentMoney = c.Sales.Sum(s => s.Car.Parts.Sum(p => p.Price))
            }).ToList().OrderByDescending(c => c.spentMoney).ThenByDescending(c => c.boughtCars);

            string json = JsonConvert.SerializeObject(customersTotalSales, Formatting.Indented);
            File.WriteAllText("../../../Export-Json/05.customers-total-sales.json", json);
            //Console.WriteLine(json);
        }

        private static void ExportCarsWithParts(CarDealerContext ctx)
        {
            var carsWithParts = ctx.Cars.ToList().Select(c => new
            {
                car = new
                {
                    c.Make,
                    c.Model,
                    c.TravelledDistance
                },
                parts = c.Parts.Select(p => new
                {
                    p.Name,
                    p.Price
                })
            });


            string json = JsonConvert.SerializeObject(carsWithParts, Formatting.Indented);
            File.WriteAllText("../../../Export-Json/04.cars-and-parts.json", json);
            //Console.WriteLine(json);
        }

        private static void ExportLocalSuppliers(CarDealerContext ctx)
        {
            var suppliers = ctx.Suppliers.Where(s => s.IsImporter == false).ToList().Select(s => new
            {
                s.Id,
                s.Name,
                s.Parts.Count
            });
            string json = JsonConvert.SerializeObject(suppliers, Formatting.Indented);
            File.WriteAllText("../../../Export-Json/03.local-suppliers.json", json);
            //Console.WriteLine(json);
        }

        private static void ExportToyotaCars(CarDealerContext ctx)
        {
            var cars = ctx.Cars.Where(c => c.Make == "Toyota").ToList().OrderBy(c => c.Model)
                .ThenByDescending(c => c.TravelledDistance).Select(c => new
                {
                    c.Id,
                    c.Make,
                    c.Model,
                    c.TravelledDistance
                });
            string json = JsonConvert.SerializeObject(cars, Formatting.Indented);
            File.WriteAllText("../../../Export-Json/02.toyota-cars.json", json);
            //Console.WriteLine(json);
        }

        private static void ExportOrderedCustomers(CarDealerContext ctx)
        {
            var customers = ctx.Customers.ToList().OrderBy(c => c.BirthDate)
                            .ThenBy(c => c.isYoungDriver != true).Select(c => new
                            {
                                c.Id,
                                c.Name,
                                c.BirthDate,
                                c.isYoungDriver,
                                Sales = c.Sales.Select(s => new
                                {
                                    s.Id,
                                    s.CarId,
                                    s.CustomerId,
                                    s.Discount
                                })
                            });
            string json = JsonConvert.SerializeObject(customers, Formatting.Indented);
            File.WriteAllText("../../../Export-Json/01.ordered-customers.json", json);
            //Console.WriteLine(json);
        }

        #endregion

        #region Import Methods

        private static void ImportSalesRecords(CarDealerContext ctx)
        {
            double[] discounts = new double[] { 0, 0.05, 0.10, 0.20, 0.30, 0.40, 0.50 };
            //Randomly select cars, customers and discounts
            Random rnd = new Random();
            List<Car> cars = ctx.Cars.ToList();
            List<Customer> customers = ctx.Customers.ToList();
            for (int i = 0; i < 63; i++)
            {
                Car car = cars[rnd.Next(cars.Count())];
                Customer customer = customers[rnd.Next(customers.Count())];
                double discount = discounts[rnd.Next(discounts.Count())];
                if (customer.isYoungDriver)
                {
                    discount += 0.05;
                }
                Sale sale = new Sale()
                {
                    Car = car,
                    Customer = customer,
                    Discount = discount
                };
                ctx.Sales.Add(sale);
            }
            ctx.SaveChanges();

        }

        private static void ImportCustomersDataFromJSON(CarDealerContext ctx)
        {
            string jsonFile = File.ReadAllText("../../../Import-Json/customers.json");
            IEnumerable<Customer> customers = JsonConvert.DeserializeObject<IEnumerable<Customer>>(jsonFile);
            ctx.Customers.AddRange(customers);
            ctx.SaveChanges();
        }

        private static void ImportPartsDataFromJSON(CarDealerContext ctx)
        {
            string jsonFile = File.ReadAllText("../../../Import-Json/parts.json");
            IEnumerable<Part> parts = JsonConvert.DeserializeObject<IEnumerable<Part>>(jsonFile);
            //Set random supplier
            Random rnd = new Random();
            int suppliersCount = ctx.Suppliers.Count();
            var suppliers = ctx.Suppliers.ToList();
            foreach (Part part in parts)
            {
                part.Supplier = suppliers[rnd.Next(suppliersCount)];
            }
            ctx.Parts.AddRange(parts);
            ctx.SaveChanges();
        }

        private static void ImportCarsDataFromJSON(CarDealerContext ctx)
        {
            string jsonFile = File.ReadAllText("../../../Import-Json/cars.json");
            IEnumerable<Car> cars = JsonConvert.DeserializeObject<IEnumerable<Car>>(jsonFile);
            //Add between 10 and 20 random parts to each car
            Random rnd = new Random();
            List<Part> parts = ctx.Parts.ToList();
            foreach (Car car in cars)
            {
                int randomPartsCount = rnd.Next(10, 21);
                for (int i = 0; i < randomPartsCount; i++)
                {
                    car.Parts.Add(parts[rnd.Next(parts.Count())]);
                }
            }
            ctx.Cars.AddRange(cars);
            ctx.SaveChanges();
        }

        private static void ImportSuppliersDataFromJSON(CarDealerContext ctx)
        {
            string jsonFile = File.ReadAllText("../../../Import-Json/suppliers.json");
            IEnumerable<Supplier> suppliers = JsonConvert.DeserializeObject<IEnumerable<Supplier>>(jsonFile);
            ctx.Suppliers.AddRange(suppliers);
            ctx.SaveChanges();
        }

        #endregion
    }
}
