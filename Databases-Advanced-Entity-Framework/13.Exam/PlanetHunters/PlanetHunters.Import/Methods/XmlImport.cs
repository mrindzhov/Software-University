namespace PlanetHunters.Import.Methods
{
    using System.Linq;
    using System.Xml.Linq;
    using PlanetHunters.Data.Utilities;

    public static class XmlImport
    {
        public static void ImportData()
        {
            ImportStars();
            ImportDiscoveries();
        }

        private static void ImportDiscoveries()
        {
            XDocument xmlData = XDocument.Load("../../../Resources/discoveries.xml");
            xmlData.Root.Elements().ToList().ForEach(discovery =>
            {
                QueryMethods.AddDiscovery(discovery);
            });
        }

        private static void ImportStars()
        {
            XDocument xmlData = XDocument.Load("../../../Resources/stars.xml");
            xmlData.Root.Elements().ToList().ForEach(star =>
            {
                QueryMethods.AddStar(star);
            });
        }
    }
}
