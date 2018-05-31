namespace PlanetHunters.Export.Methods
{
    using System;
    using System.IO;
    using Newtonsoft.Json;
    using PlanetHunters.Data.Utilities;

    public static class JsonExport
    {
        public static void ExportPlanetsByTelescope(string telescopeName)
        {
            var planets = DataLoader.GetPlanetsByTelescope(telescopeName);
            string json = JsonConvert.SerializeObject(planets, Formatting.Indented);
            //File.WriteAllText($"planets-by-{telescopeName}.", json);
            Console.WriteLine(json);
        }
        public static void ExportAstronomersByStarSystemName(string starSystemName)
        {
            var astronomers = DataLoader.GetAstronomerByStarSystemName(starSystemName);
            string json = JsonConvert.SerializeObject(astronomers, Formatting.Indented);
            //File.WriteAllText($"astronomers-of-{starSystemName}", json);
            Console.WriteLine(json);
        }
    }
}
