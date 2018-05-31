namespace PlanetHunters.Export
{
    using PlanetHunters.Data.Utilities;
    using PlanetHunters.Export.Methods;

    class Startup
    {
        static void Main(string[] args)
        {
            JsonExport.ExportPlanetsByTelescope("Kepler");
            //JsonExport.ExportAstronomersByStarSystemName("Kepler-413A");
            //Export.ExportStars();
        }
    }
}
