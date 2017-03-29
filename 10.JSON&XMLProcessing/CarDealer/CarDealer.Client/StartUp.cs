namespace CarDealer.Client
{
    using Data;
    using CarDealer.Client.Methods;

    class StartUp
    {
        static void Main(string[] args)
        {
            CarDealerContext ctx = new CarDealerContext();
            //ctx.Database.Initialize(true);

            //XMLModels.ImportData(ctx);
            //XMLModels.ExportData(ctx);

        }
    }
}
