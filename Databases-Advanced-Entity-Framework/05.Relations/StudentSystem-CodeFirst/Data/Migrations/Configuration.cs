namespace Data.Migrations
{
    using Models;
    using System;
    using System.Collections.Generic;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<StudentsContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
            AutomaticMigrationDataLossAllowed = false;
        }

        protected override void Seed(StudentsContext context)
        {
            context.Courses.AddOrUpdate(course => course.Name,
                new Course()
                {
                    Name = "C#",
                    Description = "some sharp",
                    EndDate = new DateTime(2017, 2, 3),
                    Price = 2,
                    Homeworks = new List<Homework>()
                    {
                        new Homework()
                        {
                        Content = "C# homework",
                        ContentType = ContentType.Application,
                        SubmissionDate = DateTime.Today,
                        Student = new Student()
                        {
                            Name = "Pesho",
                            RegistrationDate = DateTime.Today,
                            PhoneNumber = "08869899899"
                        }
                        },
                        new Homework()
                        {
                           Content = "java homework",
                        ContentType = ContentType.Pdf,
                        SubmissionDate = DateTime.Today,
                        Student = new Student()
                        {
                            Name = "Stancho",
                            RegistrationDate = DateTime.Today,
                            PhoneNumber = "08869899899"
                        }
                        }
                    },
                    StartDate = new DateTime(2017, 01, 14),
                    Students = new List<Student>()
                    {
                        new Student()
                        {
                            Name = "Ivo",
                            RegistrationDate = DateTime.Today,
                            PhoneNumber = "08869899899"
                        } ,
                         new Student()
                        {
                            Name = "Reni",
                            RegistrationDate = DateTime.Today,
                            PhoneNumber = "08869899899"
                        }
                    },
                    Resources = new List<Resource>()
                    {
                        new Resource()
                        {
                            Name = "rsrc",
                            Type = ResourceType.Document,
                            URL = "usadl"
                        },
                        new Resource()
                        {
                             Name = "redasdas",
                             Type = ResourceType.Document,
                             URL = "fsafasf"
                        }
                    }
                });
        }
    }
}
