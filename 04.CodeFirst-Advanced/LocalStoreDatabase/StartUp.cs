//using _03.CodeFirst_Advanced.Models;
//using System.Data.Entity.Migrations;

//namespace _03.CodeFirst_Advanced
//{
//    class StartUp
//    {
//        static void Main(string[] args)
//        {
//            LocalStoreContext context = new LocalStoreContext();
//            context.Database.Initialize(true);

//            context.Products.AddOrUpdate(new Product() { Name = "mlqko" });
//            context.Products.AddOrUpdate(new Product() { Name = "hlqb" });
//            context.Products.AddOrUpdate(new Product() { Name = "meso" });
//            context.Products.AddOrUpdate(new Product() { Name = "mivka" });
//            context.SaveChanges();
//        }
//    }
//}