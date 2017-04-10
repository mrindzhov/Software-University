namespace PlanetHunters.Data.Utilities
{
    using System.Linq;
    using System;
    using System.Data.Entity.Migrations;
    using System.Xml.Linq;
    using PlanetHunters.Dtos;
    using PlanetHunters.Models;
    using System.Collections.Generic;
    using System.Data.Entity.Validation;

    public class QueryMethods
    {

        public static void AddAstronome(Astronomer astronomer)
        {
            using (var ctx = new PlanetHuntersContext())
            {
                try
                {
                    ctx.Astronomers.AddOrUpdate(a => new { a.FirstName, a.LastName }, astronomer);
                    ctx.SaveChanges();
                    Printer.PrintSuccess(astronomer.FirstName + " " + astronomer.LastName);
                }
                catch (Exception)
                {
                    ctx.Astronomers.Remove(astronomer);
                    Printer.PrintError();
                }
            }
        }

        public static void AddDiscovery(XElement discoveryDto)
        {
            using (var ctx = new PlanetHuntersContext())
            {
                try
                {
                    string dateString = discoveryDto.Attribute("DateMade")?.Value;
                    DateTime date = DateTime.Parse(dateString);
                    string telescopeName = discoveryDto.Attribute("Telescope")?.Value;
                    IEnumerable<string> starsNames = discoveryDto.Element("Stars").Elements().Select(e => e.Value);
                    IEnumerable<string> planetsNames = discoveryDto.Element("Planets").Elements().Select(e => e.Value);
                    IEnumerable<string> pioneersNames = discoveryDto.Element("Pioneers").Elements().Select(e => e.Value);
                    IEnumerable<string> observersNames = discoveryDto.Element("Observers").Elements().Select(e => e.Value);

                    foreach (var star in starsNames)
                    {
                        if (!Check.IsStarExisting(star))
                        {
                            Printer.PrintError();
                            return;
                        }
                    }
                    foreach (var planet in planetsNames)
                    {
                        if (!Check.IsPlanetExisting(planet))
                        {
                            Printer.PrintError();
                            return;
                        }
                    }
                    foreach (var astronomer in pioneersNames)
                    {

                        string[] astronomerArgs = astronomer.Split(new string[] { ", " }, StringSplitOptions.RemoveEmptyEntries).ToArray();
                        if (!Check.IsAstronomerExisting(astronomerArgs[1], astronomerArgs[0]))
                        {
                            Printer.PrintError();
                            return;
                        }
                    }
                    foreach (var astronomer in observersNames)
                    {
                        string[] astronomerArgs = astronomer.Split(new string[] { ", " }, StringSplitOptions.RemoveEmptyEntries).ToArray();
                        if (!Check.IsAstronomerExisting(astronomerArgs[1], astronomerArgs[0]))
                        {
                            Printer.PrintError();
                            return;
                        }
                    }
                    if (!Check.IsTelescopeExisting(telescopeName))
                    {
                        Printer.PrintError();
                        return;
                    }

                    Discovery discovery = new Discovery
                    {
                        DateMade = date
                    };
                    var telescopeId = DataLoader.GetTelescopeByName(telescopeName).Id;
                    var stars = starsNames.Select(s => DataLoader.GetStarByName(s)).ToList();
                    var planets = planetsNames.Select(p => DataLoader.GetPlanetByName(p)).ToList();
                    var pioneers = pioneersNames.Select(a => DataLoader.GetAstronomerByName(a)).ToList();
                    var observers = observersNames.Select(a => DataLoader.GetAstronomerByName(a)).ToList();
                    if (telescopeId != 0)
                    {
                        discovery.TelescopeUsedId = telescopeId;
                    }
                    if (stars.Count != 0)
                    {
                        discovery.Stars = stars;
                    }
                    if (planets.Count != 0)
                    {
                        discovery.Planets = planets;
                    }
                    if (pioneers.Count != 0)
                    {
                        discovery.Pioneers = pioneers;
                    }
                    if (observers.Count != 0)
                    {
                        discovery.Observers = observers;
                    }

                    ctx.Discoveries.Add(discovery);

                    ctx.SaveChanges();
                    Printer.PrintSuccessDiscovery($"({dateString}-{telescopeName}) with {starsNames.Count()} star(s), {planetsNames.Count()} planet(s), {pioneersNames.Count()} pioneer(s) and {observersNames.Count()} observer(s)");
                }
                catch (Exception)
                {
                    Printer.PrintError();
                }
                //catch (DbEntityValidationException e)
                //{
                //    foreach (var eve in e.EntityValidationErrors)
                //    {
                //        Console.WriteLine("Entity of type \"{0}\" in state \"{1}\" has the following validation errors:",
                //            eve.Entry.Entity.GetType().Name, eve.Entry.State);
                //        foreach (var ve in eve.ValidationErrors)
                //        {
                //            Console.WriteLine("- Property: \"{0}\", Error: \"{1}\"",
                //                ve.PropertyName, ve.ErrorMessage);
                //        }
                //    }
                //    throw;
                //}
            }
        }

        public static void AddStar(XElement starDto)
        {
            using (var ctx = new PlanetHuntersContext())
            {
                try
                {
                    string name = starDto.Element("Name")?.Value;
                    int temperature = int.Parse(starDto.Element("Temperature").Value);
                    string starSystemName = starDto.Element("StarSystem")?.Value;
                    if (name == null || temperature < 2400 || starSystemName == null)
                    {
                        Printer.PrintError();
                        return;
                    }
                    var star = new Star
                    {
                        Name = name,
                        TemperatureInKelvin = temperature
                    };
                    if (!Check.IsSystemExisting(starSystemName))
                    {
                        AddStarSystem(starSystemName);
                    }
                    star.HostStarSystemId = DataLoader.GetStarSystemByName(starSystemName).Id;

                    ctx.Stars.AddOrUpdate(s => s.Name, star);
                    ctx.SaveChanges();
                    Printer.PrintSuccess(star.Name);
                }
                catch (Exception e)
                {
                    Printer.PrintError();
                }
            }

        }

        public static void AddTelescope(TelescopeDto telescopeDto)
        {
            using (var ctx = new PlanetHuntersContext())
            {
                try
                {
                    var telescope = new Telescope
                    {
                        Name = telescopeDto.Name,
                        Location = telescopeDto.Location,
                        MirrorDiameter = telescopeDto.MirrorDiameter ?? 0
                    };
                    ctx.Telescopes.AddOrUpdate(t => t.Name, telescope);
                    ctx.SaveChanges();
                    Printer.PrintSuccess(telescope.Name);
                }
                catch (Exception)
                {
                    Printer.PrintError();
                }
            }
        }


        public static void AddPlanet(PlanetDto planetDto)
        {
            using (var ctx = new PlanetHuntersContext())
            {
                try
                {
                    var planet = new Planet
                    {
                        Name = planetDto.Name,
                        Mass = planetDto.Mass ?? 0
                    };
                    if (!Check.IsSystemExisting(planetDto.StarSystem))
                    {
                        AddStarSystem(planetDto.StarSystem);
                    }
                    planet.HostStarSystemId = DataLoader.GetStarSystemByName(planetDto.StarSystem).Id;

                    ctx.Planets.Add(planet);
                    ctx.SaveChanges();
                    Printer.PrintSuccess(planet.Name);
                }
                catch (Exception)
                {
                    Printer.PrintError();
                }
            }
        }

        private static void AddStarSystem(string starSystemName)
        {
            using (var ctx = new PlanetHuntersContext())
            {
                try
                {
                    ctx.StarSystems.Add(new StarSystem
                    {
                        Name = starSystemName
                    });
                    ctx.SaveChanges();
                    Printer.PrintSuccess(starSystemName);
                }
                catch (Exception)
                {
                    Printer.PrintError();
                }
            }
        }

    }
}
