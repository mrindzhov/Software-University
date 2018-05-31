namespace Client
{
    using Client.Methods;
    using Data;

    class StartUp
    {
        static void Main(string[] args)
        {
            ProductsShopContext ctx = new ProductsShopContext();
            ctx.Database.Initialize(true);

            XMLMethods.SeedData(ctx);
            XMLMethods.ExportData(ctx);
        }
    }
}