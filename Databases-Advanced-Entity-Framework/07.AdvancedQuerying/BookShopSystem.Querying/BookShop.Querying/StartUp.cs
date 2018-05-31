﻿namespace ConsoleApplication1
{
    using BookShopSystem.Data;
    using System;
    using System.Data.SqlClient;
    using System.Linq;

    class StartUp
    {
        static void Main(string[] args)
        {
            var ctx = new BookShopContext();

            #region 1.	Books Titles by Age Restriction
            //string ageRestrict = Console.ReadLine();
            //ctx.Books.Where(b => b.AgeRestriction.ToString().ToLower() == ageRestrict.ToString().ToLower())
            //    .ToList()
            //    .ForEach(b => Console.WriteLine(b.Title));
            #endregion

            #region 2.	Golden Books
            //ctx.Books.Where(b => b.Copies < 5000 && b.EditionType.ToString() == "Gold")
            //    .OrderBy(b => b.Id)
            //    .Select(b => b.Title)
            //    .ToList()
            //    .ForEach(b => Console.WriteLine(b));
            #endregion

            #region 3.	Books by Price
            //ctx.Books.Where(b => b.Price < 5 || b.Price > 40)
            //    .OrderBy(b => b.Id)
            //    .Select(b =>new
            //    {
            //        b.Title,
            //        b.Price
            //    })
            //    .ToList()
            //    .ForEach(b => Console.WriteLine(b.Title+" - $"+b.Price));
            #endregion

            #region 4.	Not Released Books
            //Console.Write("Enter year: ");
            //int year = int.Parse(Console.ReadLine());
            //ctx.Books.Where(b => b.ReleaseDate.Value.Year!=year)
            //    .OrderBy(b => b.Id)
            //    .Select(b => new
            //    {
            //        b.Title
            //    })
            //    .ToList()
            //    .ForEach(b => Console.WriteLine(b.Title));
            #endregion

            #region 5.	Book Titles by Category
            //Console.Write("Enter categories: ");
            //string[] categories = Console.ReadLine()
            //    .Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries).ToArray();
            //ctx.Books
            //.Where(b => b.Categories.Any(c => categories.Any(cc => cc.ToLower() == c.Name.ToLower())))
            //.OrderBy(b => b.Id)
            //.ToList()
            //.ForEach(book => Console.WriteLine($"{book.Title}"));
            #endregion

            #region 6.	Books Released Before Date
            //Console.Write("Enter year: ");
            //DateTime year = DateTime.Parse(Console.ReadLine());
            //ctx.Books.Where(b => b.ReleaseDate.Value < year)
            //    .Select(b => new
            //    {
            //        b.Title,
            //        b.EditionType,
            //        b.Price
            //    })
            //    .ToList()
            //    .ForEach(b => Console.WriteLine(b.Title + " - " + b.EditionType + " - " + b.Price));
            #endregion

            #region 7.	Authors Search
            //Console.Write("Enter name ending: ");
            //string ending = Console.ReadLine();
            //ctx.Books.Where(b => b.Title.ToLower().Contains(ending.ToLower()))
            //    .Select(b => new
            //    {
            //    b.Title
            //    })
            //    .ToList()
            //    .ForEach(b => Console.WriteLine(b.Title));
            #endregion

            #region 8.	Books Search
            //Console.Write("Enter name ending: ");
            //string ending = Console.ReadLine();
            //ctx.Books.Where(b => b.Title.ToLower().Contains(ending.ToLower()))
            //    .Select(b => new
            //    {
            //    b.Title
            //    })
            //    .ToList()
            //    .ForEach(b => Console.WriteLine(b.Title));
            #endregion

            #region 9.	Book Titles Search
            //Console.Write("Enter name start: ");
            //string ending = Console.ReadLine();
            //ctx.Books.Where(b => b.Author.LastName.ToLower().StartsWith(ending.ToLower()))
            //    .OrderBy(b => b.Id)
            //    .Select(b => new
            //    {
            //        b.Title,
            //        b.Author.FirstName,
            //        b.Author.LastName
            //    })

            //    .ToList()
            //    .ForEach(b => Console.WriteLine($"{b.Title} ({b.FirstName} {b.LastName})"));
            #endregion

            #region 10.	Count Books
            //Console.Write("Enter title length: ");
            //int length= int.Parse(Console.ReadLine());
            //int count=ctx.Books.Where(b => b.Title.Length > length)
            //    .OrderBy(b => b.Id)
            //    .Select(b => new
            //    {
            //        b.Title,
            //        b.Author.FirstName,
            //        b.Author.LastName
            //    }).Count();
            //Console.WriteLine(count);
            #endregion

            #region 11.	Total Book Copies
            //ctx.Authors.OrderByDescending(a => a.Books.Sum(b => b.Copies)).ToList().ForEach(a =>
            //    {
            //        Console.WriteLine(a.FirstName + " " + a.LastName + " " + a.Books.Sum(b => b.Copies));
            //    });
            #endregion

            #region 12.	Find Profit
            //ctx.Categories.OrderByDescending(c => c.Books.Sum(b => (b.Price * b.Copies)))
            //    .ThenBy(c => c.Name)
            //    .ToList()
            //    .ForEach(c =>
            //    {
            //        Console.WriteLine($"{c.Name} - ${c.Books.Sum(b => (b.Price * b.Copies))}");
            //    });
            #endregion

            #region 13.	Most Recent Books
            //ctx.Categories.OrderByDescending(c => c.Books.Count())
            //    .Where(c => c.Books.Count > 35)
            //    .Select(c => new
            //    {
            //        c.Name,
            //        c.Books
            //    })
            //    .ToList()
            //    .ForEach(c =>
            //    {
            //        Console.WriteLine($"--{c.Name}: {c.Books.Count} books");
            //        c.Books.OrderByDescending(b => b.ReleaseDate)
            //        .ThenBy(b => b.Title)
            //        .Take(3)
            //        .Select(b => new
            //        {
            //            b.Title,
            //            b.ReleaseDate
            //        }).ToList().ForEach(book =>
            //        {
            //            Console.WriteLine($"{book.Title} ({book.ReleaseDate.Value.Year})");
            //        });
            //    });
            #endregion

            #region 14.	Increase Book Copies
            //DateTime date = DateTime.Parse("06 - Jun - 2013");
            //int addedBooks = 0;
            //ctx.Books.Where(b => b.ReleaseDate.Value > date).ToList().ForEach(b =>
            //{
            //    b.Copies += 44;
            //    addedBooks += 44;
            //});
            //ctx.SaveChanges();
            //Console.WriteLine(addedBooks);
            #endregion

            #region 15.	Remove Books
            //ctx.Books.RemoveRange(ctx.Books.Where(b => b.Copies < 4200));
            //Console.WriteLine(ctx.SaveChanges() + " books were deleted");
            #endregion

            #region 16.	Stored Procedure
                #region Procedure in MSSQL
            //            create PROCEDURE GetBooksCountByAuthor
            //    (@firstName varchar(30), @lastName Varchar(30))
            //As
            //Begin
            //select COUNT(*) from Books
            //where AuthorId = (
            //    Select Id from Authors as a
            //              where a.FirstName = @firstName and a.LastName = @lastName)
            //End   
            #endregion
            Console.Write("Enter author first and last name: ");
            string[] names = Console.ReadLine().Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);

            SqlParameter param1 = new SqlParameter("@firstName", names[0]);
            SqlParameter param2 = new SqlParameter("@lastName", names[1]);

            int result = ctx.Database
                .SqlQuery<int>("exec dbo.GetBooksCountByAuthor @firstName, @lastName", param1, param2)
                .First();

            Console.WriteLine($"{names[0]} {names[1]} has written {result} books");
            #endregion

        }
    }
}
