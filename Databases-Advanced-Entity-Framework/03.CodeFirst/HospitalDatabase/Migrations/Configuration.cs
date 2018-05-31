namespace HospitalDatabase.Migrations
{
    using System.Data.Entity.Migrations;
    using Models;
    using System;
    using System.Data.Entity;

    internal sealed class Configuration : DropCreateDatabaseAlways<HospitalContext>
    {
        //public Configuration()
        //{
        //    this.AutomaticMigrationsEnabled = true;
        //}

        protected override void Seed(HospitalContext context)
        {
            //This method will be called after migrating to the latest version.

            //You can use the DbSet<T>.AddOrUpdate() helper extension method
            //to avoid creating duplicate seed data.E.g.

            context.Patients.AddOrUpdate(
              new Patient
              {
                  FirstName = "Andrew",
                  Lastname = "Peters",
                  Address = "adress",
                  Email = "asd@gmail.com",
                  DateOfBirth = new DateTime(2002, 01, 01)
              },
              new Patient
              {
                  FirstName = "Brice",
                  Lastname = "Lambson",
                  Address = "adress",
                  Email = "asd@gmail.com",
                  DateOfBirth = new DateTime(2001, 01, 01)
              }, new Patient
              {
                  FirstName = "Rowan",
                  Lastname = "Miller",
                  Address = "adress",
                  Email = "asd@gmail.com",
                  DateOfBirth = new DateTime(2002, 01, 01)
              }
            );
            context.SaveChanges();
            base.Seed(context);
        }
    }
}