
namespace UsersDatabase.Migrations
{
    using Models;
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;

    public class MyConfiguration : DropCreateDatabaseAlways<UsersContext>
    {
        protected override void Seed(UsersContext context)
        {
            //This method will be called after migrating to the latest version.

            //You can use the DbSet<T>.AddOrUpdate() helper extension method
            //to avoid creating duplicate seed data.E.g.
            context.Users.AddOrUpdate(new User
            {
                Age = 15,
                Email = "daspf@abv.com",
                IsDeleted = true,
                LastTimeLoggedIn = new DateTime(1992, 11, 29),
                Password = "hel$A-_99lo",
                //  ProfilePicture = File.ReadAllBytes(@"picture path"),
                RegisteredOn = new DateTime(1992, 11, 28),
                Username = "Bai Stenly",
                FirstName = "Stanislav",
                LastName = "Karagiozov",
            },
            new User
            {
                Age = 110,
                Email = "bdas@gam.com",
                IsDeleted = true,
                LastTimeLoggedIn = new DateTime(1993, 1, 20),
                Password = "heds-alA2_lo",
                // ProfilePicture = File.ReadAllBytes(@"picture path"),
                RegisteredOn = new DateTime(1992, 11, 28),
                FirstName = "Atanas",
                LastName = "Stamatov",
                Username = "Bai Nasko"
            });

            context.SaveChanges();
            base.Seed(context);
        }
    }
}
