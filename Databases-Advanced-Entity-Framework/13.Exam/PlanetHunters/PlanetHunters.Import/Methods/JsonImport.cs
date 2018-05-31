namespace PlanetHunters.Import.Methods
{
    using System.Collections.Generic;
    using System.IO;
    using Newtonsoft.Json;
    using PlanetHunters.Data.Utilities;
    using PlanetHunters.Dtos;
    using PlanetHunters.Models;

    public static class JsonImport
    {

        public static void ImportData()
        {
            ImportAstronomers();
            ImportTelescopes();
            ImportPlanets();
        }

        private static void ImportPlanets()
        {
            string jsonFile = File.ReadAllText("../../../Resources/planets.json");
            var planets = JsonConvert.DeserializeObject<IEnumerable<PlanetDto>>(jsonFile);
            foreach (var planetDto in planets)
            {
                if (planetDto.Name == null ||
                    planetDto.StarSystem == null ||
                    planetDto.Mass <= 0 ||
                    planetDto.Mass == null)
                {
                    Printer.PrintError();
                    continue;
                }
                QueryMethods.AddPlanet(planetDto);
            }
        }

        private static void ImportTelescopes()
        {
            string jsonFile = File.ReadAllText("../../../Resources/telescopes.json");
            var telescopes = JsonConvert.DeserializeObject<IEnumerable<TelescopeDto>>(jsonFile);
            foreach (var telescopeDto in telescopes)
            {
                if (telescopeDto.Name == null ||
                    telescopeDto.MirrorDiameter == null ||
                    telescopeDto.MirrorDiameter <= 0 ||
                    telescopeDto.Location == null)
                {
                    Printer.PrintError();
                    continue;
                }
                QueryMethods.AddTelescope(telescopeDto);
            }
        }

        private static void ImportAstronomers()
        {
            string jsonFile = File.ReadAllText("../../../Resources/astronomers.json");
            var astronomers = JsonConvert.DeserializeObject<IEnumerable<AstronomerDto>>(jsonFile);
            foreach (var astronom in astronomers)
            {
                if (astronom.FirstName == null || astronom.LastName == null)
                {
                    Printer.PrintError();
                    continue;
                }
                var astronomer = new Astronomer
                {
                    FirstName = astronom.FirstName,
                    LastName = astronom.LastName
                };
                QueryMethods.AddAstronome(astronomer);
            }
        }
    }
}
