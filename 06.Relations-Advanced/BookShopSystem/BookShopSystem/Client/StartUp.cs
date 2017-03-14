using BookShopSystem.Data;
using BookShopSystem.Migrations;
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
            //ctx.Database.Initialize(true);
            //var migrationStrategy = new MigrateDatabaseToLatestVersion<BookShopContext, Configuration>();
            //Database.SetInitializer(migrationStrategy);

            var books = ctx.Books
                                .Take(3)
                                .ToList();
            books[0].RelatedBooks.Add(books[1]);
            books[1].RelatedBooks.Add(books[0]);
            books[0].RelatedBooks.Add(books[2]);
            books[2].RelatedBooks.Add(books[0]);

            ctx.SaveChanges();

            var booksFromQuery = ctx.Books.Take(3);

            foreach (var book in booksFromQuery)
            {
                Console.WriteLine("--{0}", book.Title);
                foreach (var relatedBook in book.RelatedBooks)
                {
                    Console.WriteLine(relatedBook.Title);
                }
            }
        }
    }
}
