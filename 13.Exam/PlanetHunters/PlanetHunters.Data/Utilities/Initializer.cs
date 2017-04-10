namespace PlanetHunters.Data.Utilities
{
    public static class Initializer
    {
        public static void InitDb()
        {
            var ctx = new PlanetHuntersContext();
            ctx.Database.Initialize(true);
        }
    }
}
