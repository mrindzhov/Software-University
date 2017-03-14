namespace Client
{
    using Data;
    using System;
    using System.Data.Entity.SqlServer;
    using System.Linq;

    class StartUp
    {
        static void Main(string[] args)
        {
            var ctx = new StudentsContext();
            //   ctx.Database.Initialize(true);
            #region //List all students and their homeworks
            //ctx.Students.ToList().ForEach(s =>
            //{
            //    Console.WriteLine("Student: " + s.Name);
            //    if (s.Homeworks.Count == 0)
            //    {
            //        Console.WriteLine("No available homeworks");
            //    }
            //    else
            //    {
            //        Console.WriteLine("Homeworks: ");
            //        s.Homeworks.ToList().ForEach(h =>
            //        {
            //            Console.WriteLine("Content: " + h.Content);
            //            Console.WriteLine("Content type : " + h.ContentType);
            //        });
            //    }
            //    Console.WriteLine();
            //});
            #endregion
            #region //List all courses and resourses
            //ctx.Courses.ToList().ForEach(c =>
            //{
            //    Console.WriteLine("Course: " + c.Name);
            //    Console.WriteLine("Description: " + c.Description);
            //    if (c.Resources.Count== 0)
            //    {
            //        Console.WriteLine("No available resources");
            //    }
            //    else
            //    {
            //        Console.WriteLine("Resources: ");
            //        c.Resources.ToList().ForEach(r =>
            //        {
            //            Console.WriteLine("Id: "+ r.Id);
            //            Console.WriteLine("Name: " + r.Name);
            //            Console.WriteLine("Type: "+ r.Type);
            //            Console.WriteLine("URL: "+ r.URL);
            //            Console.WriteLine();
            //        });
            //    }
            //});
            #endregion
            #region //List all courses with more than 5 resourses
            //if (ctx.Courses.Any(c => c.Resources.Count > 5))
            //{
            //    ctx.Courses.Where(c => c.Resources.Count > 5).OrderByDescending(c => c.Resources.Count)
            //        .ThenByDescending(c => c.StartDate)
            //        .ToList().ForEach(c =>
            //        {
            //            Console.WriteLine("Course: " + c.Name);
            //            Console.WriteLine("Resources: " + c.Resources.Count);
            //        });
            //}
            //else
            //{
            //    Console.WriteLine("No course with more than 5 resources");
            //}
            #endregion
            #region //List all courses active on a given date
            //Console.Write("Enter date(ex. 2010 02 17): ");
            //DateTime date2 = DateTime.Parse(Console.ReadLine());
            //if (ctx.Courses.Any(c => c.StartDate <= date2 && date2 <= c.EndDate))
            //{
            //    ctx.Courses.Where(c => c.StartDate <= date2 && date2 <= c.EndDate)
            //        .OrderByDescending(c => c.Students.Count)
            //        .ThenByDescending(c => SqlFunctions.DateDiff("day", c.StartDate, c.EndDate))
            //      .ToList().ForEach(c =>
            //        {
            //            Console.WriteLine("Course: " + c.Name);
            //            Console.WriteLine("EndDate: " + c.StartDate.ToShortDateString());
            //            Console.WriteLine("StartDate: " + c.EndDate.ToShortDateString());
            //            Console.WriteLine("Course Duration: " + (c.EndDate - c.StartDate).Duration().Days + " days");
            //            Console.WriteLine("Students: " + c.Students.Count);
            //        });
            //}
            //else
            //{
            //    Console.WriteLine("No course active on the given date");
            //}
            #endregion
            #region //Student's courses
            //ctx.Students
            //    .OrderByDescending(s => s.Courses.Sum(c=>c.Price))
            //    .ThenByDescending(s=>s.Courses.Count)
            //    .ThenBy(s=>s.Name)
            //    .ToList().ForEach(s =>
            //  {
            //      Console.WriteLine("Student: "+s.Name);
            //      Console.WriteLine("Courses involved in: "+s.Courses.Count);
            //      decimal totalPrice = s.Courses.Sum(c=>c.Price);
            //      Console.WriteLine("Total price: "+totalPrice);
            //      if (totalPrice != 0)
            //      {
            //          Console.WriteLine("Average price: "+totalPrice / s.Courses.Count);
            //      }
            //      Console.WriteLine();
            //  });
            #endregion
        }
    }
}
