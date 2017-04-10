namespace PlanetHunters.Import
{
    using PlanetHunters.Data.Utilities;
    using PlanetHunters.Import.Methods;

    class Startup
    {
        static void Main(string[] args)
        {
            Initializer.InitDb();
            JsonImport.ImportData();
            XmlImport.ImportData();
        }
        
    }
}
