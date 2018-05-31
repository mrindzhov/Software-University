namespace SimpleMapping.Migrations
{
    using System;
    using System.Collections.Generic;
    using System.Data.Entity.Migrations;

    public sealed class Configuration : DbMigrationsConfiguration<EmployeesContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
        }

        protected override void Seed(EmployeesContext context)
        {
            context.Employees.AddOrUpdate(e => new { e.FirstName,e.LastName},
               new Employee()
               {
                   FirstName = "Steve",
                   LastName = "Jobbsen",
                   BirthDay = new DateTime(1967, 11, 11),
                   Salary = 60300.20m,
                   Adress = "Sofia",
                   isOnVacation = false,
                   Subordinates = new HashSet<Employee>(){
                        new Employee()
                        {
                            FirstName = "Stephen",
                            LastName = "Bjorn",
                            BirthDay = new DateTime(1987, 11, 11),
                            Salary = 4300.00m,
                            Adress = "Germany"
                        },
                        new Employee()
                        {
                            FirstName = "Kirilyc",
                            LastName = "Lefi",
                            BirthDay = new DateTime(1977, 11, 11),
                            Salary = 4400.00m,
                            Adress = "Sofia"
                        }
                    }
               },
                new Employee()
                {
                    FirstName = "Carl",
                    LastName = "Kormac",
                    BirthDay = new DateTime(1978, 11, 11),
                    Salary = 4000.00m,
                    Adress = "Sofia",
                    Subordinates = new HashSet<Employee>()
                    {
                        new Employee()
                        {
                            FirstName = "Jurgen",
                            LastName = "Stratus",
                            BirthDay = new DateTime(1979, 11, 11),
                            Salary = 1000.45m,
                            Adress = "Sofia",
                            isOnVacation = false,

                        },
                        new Employee()
                        {
                            FirstName = "Moni",
                            LastName = "Kozinac",
                            BirthDay = new DateTime(1997, 11, 11),
                            Salary = 2030.99m,
                            Adress = "Sofia",
                            isOnVacation = false,

                        },
                        new Employee()
                        {
                            FirstName = "Kopp",
                            LastName = "Spidok",
                            BirthDay = new DateTime(1997, 11, 11),
                            Salary =2000.21m,
                            Adress = "Sofia"
                        }
                    }
            });
            context.SaveChanges();
            base.Seed(context);

        }
    }
}