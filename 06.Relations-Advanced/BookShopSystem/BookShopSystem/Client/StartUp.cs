using BookShopSystem.Data;
using BookShopSystem.Migrations;
using Models;
using System;
using System.Data.Entity;
using System.Linq;

namespace BookShopSystem
{
    class StartUp
    {
        static void Main(string[] args)
        {
            var ctx = new BookShopContext();
            #region 0.      previous task
            //ctx.Database.Initialize(true);
            //var migrationStrategy = new MigrateDatabaseToLatestVersion<BookShopContext, Configuration>();
            //Database.SetInitializer(migrationStrategy);

            //var books = ctx.Books
            //                    .Take(3)
            //                    .ToList();
            //books[0].RelatedBooks.Add(books[1]);
            //books[1].RelatedBooks.Add(books[0]);
            //books[0].RelatedBooks.Add(books[2]);
            //books[2].RelatedBooks.Add(books[0]);

            //ctx.SaveChanges();

            //var booksFromQuery = ctx.Books.Take(3);

            //foreach (var book in booksFromQuery)
            //{
            //    Console.WriteLine("--{0}", book.Title);
            //    foreach (var relatedBook in book.RelatedBooks)
            //    {
            //        Console.WriteLine(relatedBook.Title);
            //    }
            //}
            #endregion

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
            ctx.Categories.OrderByDescending(c => c.Books.Count())
                .Where(c=>c.Books.Count>35)
                .Select(c => new
                {
                    c.Name,
                    c.Books
                })
                .ToList()
                .ForEach(c =>
                {
                    Console.WriteLine($"--{c.Name}: {c.Books.Count} books");
                    foreach (var book in c.Books
                    .OrderByDescending(b => b.ReleaseDate)
                    .ThenBy(b => b.Title)
                    .Take(3)
                    .Select(b => new
                    {
                        b.Title,
                        b.ReleaseDate
                    }))
                    {
                        Console.WriteLine($"{book.Title} ({book.ReleaseDate.Value.Year})");
                    }
                });
            #endregion

        }
    }
}
