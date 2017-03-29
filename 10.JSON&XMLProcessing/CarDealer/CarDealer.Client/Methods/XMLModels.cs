namespace CarDealer.Client.Methods
{
    using Models;
    using Data;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Xml.Linq;

    public class XMLModels
    {
        public static void ImportData(CarDealerContext ctx)
        {
            ImportCarsDataFromXML(ctx);

            ImportSuppliersDataFromXML(ctx);

            ImportPartsDataFromXML(ctx);

            ImportCustomersDataFromXML(ctx);

            ImportSalesRecords(ctx);
        }

        public static void ExportData(CarDealerContext ctx)
        {
            ExportCarsWithBigDistanceTravelled(ctx);

            ExportFerrariCars(ctx);

            ExportLocalSuppliers(ctx);

            ExportCarsWithParts(ctx);

            ExportCustomersTotalSales(ctx);

            ExportSalesWithDiscount(ctx);
        }

        #region Export Methods

        private static void ExportSalesWithDiscount(CarDealerContext ctx)
        {
            ICollection<XElement> elements = new List<XElement>();

            ctx.Sales.Where(s => s.Discount != 0).ToList().Select(s => new
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
            }).ToList().ForEach(s =>
            {
                XElement element=new XElement("sale",new XElement("car",
                                new XAttribute("make", s.car.Make),
                                new XAttribute("model", s.car.Model),
                                new XAttribute("travelled-distance", s.car.TravelledDistance)),
                                new XElement("customer-name",s.customerName),
                                new XElement("discount",s.Discount),
                                new XElement("price",s.price),
                                new XElement("price-with-discount", s.priceWithDiscount));
                
                elements.Add(element);
            });
            XDocument doc = new XDocument();
            doc.Add(new XElement("sales", elements));
            doc.Save("../../../Export-XML/06.sales-discounts.xml");
        }

        private static void ExportCustomersTotalSales(CarDealerContext ctx)
        {
            ICollection<XElement> elements = new List<XElement>();

            ctx.Customers.Where(c => c.Sales.Count > 0).Select(c => new
            {
                fullName = c.Name,
                boughtCars = c.Sales.Count(),
                spentMoney = c.Sales.Sum(s => s.Car.Parts.Sum(p => p.Price))
            }).ToList().OrderByDescending(c => c.spentMoney).ThenByDescending(c => c.boughtCars).ToList().ForEach(c =>
            {
                elements.Add(new XElement("customer",
                                new XAttribute("full-name", c.fullName),
                                new XAttribute("bought-cars", c.boughtCars),
                                new XAttribute("spent-money", c.spentMoney)));
            });
            XDocument doc = new XDocument();
            doc.Add(new XElement("customers", elements));
            doc.Save("../../../Export-XML/05.customers-total-sales.xml");
        }

        private static void ExportCarsWithParts(CarDealerContext ctx)
        {
            ICollection<XElement> elements = new List<XElement>();

            ctx.Cars.ToList().Select(c => new
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
            }).ToList().ForEach(c =>
            {
                XElement element = new XElement("car",
                                new XAttribute("make", c.car.Make),
                                new XAttribute("model", c.car.Model),
                                new XAttribute("travelled-distance", c.car.TravelledDistance),
                                new XElement("parts"));
                c.parts.ToList().ForEach(p =>
                {
                    element.Element("parts").Add(new XElement("part",
                        new XAttribute("name", p.Name),
                        new XAttribute("price", p.Price)));
                });
                elements.Add(element);

            });
            XDocument doc = new XDocument();
            doc.Add(new XElement("cars", elements));
            doc.Save("../../../Export-XML/04.cars-and-parts.xml");

        }

        private static void ExportLocalSuppliers(CarDealerContext ctx)
        {
            ICollection<XElement> elements = new List<XElement>();
            ctx.Suppliers.Where(s => s.IsImporter == false).Select(s => new
            {
                s.Id,
                s.Name,
                PartsCount = s.Parts.Count
            }).ToList().ForEach(s =>
            {
                elements.Add(new XElement("supplier",
                                new XAttribute("id", s.Id),
                                new XAttribute("model", s.Name),
                                new XAttribute("parts-count", s.PartsCount)));
            });
            XDocument doc = new XDocument();
            doc.Add(new XElement("suppliers", elements));
            doc.Save("../../../Export-XML/03.local-suppliers.xml");

        }

        private static void ExportFerrariCars(CarDealerContext ctx)
        {
            ICollection<XElement> elements = new List<XElement>();

            ctx.Cars.Where(c => c.Make == "Ferrari").ToList()
                .OrderBy(c => c.Model)
                .ThenByDescending(c => c.TravelledDistance).Select(c => new
                {
                    c.Id,
                    c.Model,
                    c.TravelledDistance
                }).ToList().ForEach(c =>
                {
                    elements.Add(new XElement("car",
                                    new XAttribute("id", c.Id),
                                    new XAttribute("model", c.Model),
                                    new XAttribute("travelled-distance", c.TravelledDistance)));
                });
            XDocument doc = new XDocument();
            doc.Add(new XElement("cars", elements));
            doc.Save("../../../Export-XML/02.ferrari-cars.xml");


        }

        private static void ExportCarsWithBigDistanceTravelled(CarDealerContext ctx)
        {
            ICollection<XElement> elements = new List<XElement>();

            ctx.Cars.Where(c => c.TravelledDistance > 2_000_000)
                .OrderBy(c => c.Make).ThenBy(c => c.Model).Select(c => new
                {
                    c.Make,
                    c.Model,
                    c.TravelledDistance

                }).ToList().ForEach(c =>
                {
                    elements.Add(new XElement("car",
                                    new XElement("make", c.Make),
                                    new XElement("model", c.Model),
                                    new XElement("travelled-distance", c.TravelledDistance)));
                });
            XDocument doc = new XDocument();
            doc.Add(new XElement("cars", elements));
            doc.Save("../../../Export-XML/01.cars.xml");
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

        private static void ImportCustomersDataFromXML(CarDealerContext ctx)
        {
            XDocument xmlData = XDocument.Load("../../../Import-XML/customers.xml");
            ICollection<Customer> customers = new HashSet<Customer>();
            xmlData.Root.Elements().ToList().ForEach(u =>
            {
                string name = u.Attribute("name").Value;
                DateTime birthDate = DateTime.Parse(u.Element("birth-date").Value);
                bool IsYoungDriver = bool.Parse(u.Element("is-young-driver").Value);
                customers.Add(new Customer
                {
                    Name = name,
                    BirthDate = birthDate,
                    isYoungDriver = IsYoungDriver
                });
            });
            ctx.Customers.AddRange(customers);
            ctx.SaveChanges();
        }

        private static void ImportCarsDataFromXML(CarDealerContext ctx)
        {
            XDocument xmlData = XDocument.Load("../../../Import-XML/cars.xml");
            ICollection<Car> cars = new HashSet<Car>();
            xmlData.Root.Elements().ToList().ForEach(c =>
            {
                string make = c.Element("make").Value;
                string model = c.Element("model").Value;
                long travelledDistance = long.Parse(c.Element("travelled-distance").Value);
                Car car = new Car
                {
                    Make = make,
                    Model = model,
                    TravelledDistance = travelledDistance
                };
                cars.Add(car);
            });

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

        private static void ImportPartsDataFromXML(CarDealerContext ctx)
        {
            XDocument xmlData = XDocument.Load("../../../Import-XML/parts.xml");
            ICollection<Part> parts = new HashSet<Part>();
            xmlData.Root.Elements().ToList().ForEach(u =>
            {
                string name = u.Attribute("name")?.Value;
                decimal price = decimal.Parse(u.Attribute("price").Value);
                int quantity = int.Parse(u.Attribute("quantity").Value);
                Part part = new Part
                {
                    Name = name,
                    Price = price,
                    Quantity = quantity
                };

                parts.Add(part);
            });
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

        private static void ImportSuppliersDataFromXML(CarDealerContext ctx)
        {
            XDocument xmlData = XDocument.Load("../../../Import-XML/suppliers.xml");
            ICollection<Supplier> suppliers = new HashSet<Supplier>();
            xmlData.Root.Elements().ToList().ForEach(u =>
            {
                string name = u.Attribute("name")?.Value;
                bool isImporter = bool.Parse(u.Attribute("is-importer").Value);
                suppliers.Add(new Supplier
                {
                    Name = name,
                    IsImporter = isImporter
                });
            });
            ctx.Suppliers.AddRange(suppliers);
            ctx.SaveChanges();
        }

        #endregion
    }
}
