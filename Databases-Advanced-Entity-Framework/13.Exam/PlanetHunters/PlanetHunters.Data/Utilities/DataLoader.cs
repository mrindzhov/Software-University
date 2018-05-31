namespace PlanetHunters.Data.Utilities
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using PlanetHunters.Dtos;
    using PlanetHunters.Models;

    public static class DataLoader
    {
        public static StarSystem GetStarSystemByName(string starSystemName)
        {
            using (var ctx = new PlanetHuntersContext())
            {
                return ctx.StarSystems.FirstOrDefault(ss => ss.Name == starSystemName);
            }
        }

        public static object GetPlanetsByTelescope(string telescopeName)
        {
            using (var ctx = new PlanetHuntersContext())
            {
                var result = ctx.Telescopes.FirstOrDefault(t => t.Name == telescopeName)
                    .DiscoveriesMade.Select(d => new
                    {
                        planets = d.Planets.Select(p => new
                        {
                            p.Name,
                            p.Mass,
                            SolarSystemName = p.HostStarSystem.Name
                        })
                    }).ToList();
                return result;
            }
        }

        public static object GetDiscoveredStars()
        {
            using (var ctx = new PlanetHuntersContext())
            {

                //var result = ctx.Stars.ToList();

                var result = ctx.Stars.Where(s => s.DiscoveryId != null).ToList().Select(s => new
                {
                    s.Name,
                    s.TemperatureInKelvin,
                    StarSystemName = s.HostStarSystem.Name,
                    s.Discovery.DateMade,
                    TelescopeName = s.Discovery.TelescopeUsed.Name,
                    Astronomers = s.Discovery.Pioneers.OrderBy(p => p.FirstName)
                }).ToList();
                return result;
            }
        }

        public static HashSet<AstroDto> GetAstronomerByStarSystemName(string starSystemName)
        {
            using (var ctx = new PlanetHuntersContext())
            {
                var astrota = new HashSet<AstroDto>();

                ctx.StarSystems.Include("Planets").First(ss => ss.Name == starSystemName)
                    .Planets
                    .ToList().ForEach(p =>
                    {
                        if (p.Discovery != null)
                        {
                            var pioneers = p.Discovery.Pioneers.ToList();
                            pioneers.ForEach(pi =>
                            {
                                astrota.Add(new AstroDto
                                {
                                    Name = $"{pi.FirstName} {pi.LastName}",
                                    Role = "pioneer"
                                });
                            });
                            var observers = p.Discovery.Observers.ToList();
                            observers.ForEach(pi =>
                            {
                                astrota.Add(new AstroDto
                                {
                                    Name = $"{pi.FirstName} {pi.LastName}",
                                    Role = "observer"
                                });
                            });
                        }
                    });
                return astrota;

            }

        }


        public static Telescope GetTelescopeByName(string telescopeName)
        {
            using (var ctx = new PlanetHuntersContext())
            {
                return ctx.Telescopes.FirstOrDefault(t => t.Name == telescopeName);
            }
        }

        public static Star GetStarByName(string starName)
        {
            using (var ctx = new PlanetHuntersContext())
            {
                return ctx.Stars.Include("HostStarSystem").FirstOrDefault(s => s.Name == starName);
            }
        }
        public static Astronomer GetAstronomerByName(string astronomer)
        {
            string[] astronomerArgs = astronomer.Split(new string[] { ", " }, StringSplitOptions.RemoveEmptyEntries).ToArray();
            string firstName = astronomerArgs[1];
            string lastName = astronomerArgs[0];

            using (var ctx = new PlanetHuntersContext())
            {
                Astronomer astro = ctx.Astronomers.Include("ObservedDiscoveries").Include("PioneeredDiscoveries")
                    .FirstOrDefault(s => s.FirstName == firstName || s.LastName == lastName);
                return astro;
            }
        }
        public static Planet GetPlanetByName(string planetName)
        {
            using (var ctx = new PlanetHuntersContext())
            {
                return ctx.Planets.Include("HostStarSystem").FirstOrDefault(p => p.Name == planetName);
            }
        }
    }
}