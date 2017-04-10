namespace PlanetHunters.Data.Utilities
{
    using System;
    using System.Linq;

    public static class Check
    {
        public static bool IsSystemExisting(string starSystemName)
        {
            using (var ctx = new PlanetHuntersContext())
            {
                return ctx.StarSystems.Any(ss => ss.Name == starSystemName);
            }
        }
        public static bool IsPlanetExisting(string planetName)
        {
            using (var ctx = new PlanetHuntersContext())
            {
                return ctx.Planets.Any(p => p.Name == planetName);
            }
        }
        public static bool IsStarExisting(string starName)
        {
            using (var ctx = new PlanetHuntersContext())
            {
                return ctx.Stars.Any(s => s.Name == starName);
            }
        }
        public static bool IsAstronomerExisting(string firstName, string lastName)
        {
            using (var ctx = new PlanetHuntersContext())
            {
                return ctx.Astronomers.Any(a => a.FirstName == firstName && a.LastName == lastName);
            }
        }

        public static bool IsTelescopeExisting(string telescopeName)
        {
            using (var ctx = new PlanetHuntersContext())
            {
                return ctx.Telescopes.Any(t => t.Name == telescopeName);
            }
        }
    }
}
