namespace PlanetHunters.Data.Utilities
{
    using System.Collections.Generic;
    using System.Linq;
    using System.Xml.Linq;

    public class Export
    {
        public static void ExportStars()
        {
            using (var ctx = new PlanetHuntersContext())
            {
                ICollection<XElement> elements = new List<XElement>();

                ctx.Stars.Where(s => s.DiscoveryId != null).ToList().Select(s => new
                {
                    s.Name,
                    s.TemperatureInKelvin,
                    StarSystemName = s.HostStarSystem.Name,
                    s.Discovery.DateMade,
                    TelescopeName = s.Discovery.TelescopeUsed.Name,
                    Astronomers = s.Discovery.Pioneers.OrderBy(p => p.FirstName)
                }).ToList().ForEach(s =>
                {
                    XElement element = new XElement("Star",
                                            new XElement("Name", s.Name),
                                            new XElement("Temeperature", s.TemperatureInKelvin),
                                            new XElement("StarSystem", s.StarSystemName),
                                            new XElement("DiscoveryInfo",
                                                new XAttribute("DiscoveryDate", s.DateMade.ToShortDateString()),
                                                new XAttribute("TelescopeName", s.TelescopeName)));

                    elements.Add(element);
                });
                XDocument doc = new XDocument();
                doc.Add(new XElement("Stars", elements));
                doc.Save("../../../Export/stars.xml");
            }
        }
    }
}
