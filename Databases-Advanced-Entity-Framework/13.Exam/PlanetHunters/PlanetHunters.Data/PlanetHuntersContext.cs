namespace PlanetHunters.Data
{
    using System.Data.Entity;
    using PlanetHunters.Models;

    public class PlanetHuntersContext : DbContext
    {

        public PlanetHuntersContext()
            : base("name=PlanetHuntersContext")
        {
            //Database.SetInitializer(new DropCreateDatabaseAlways<PlanetHuntersContext>());
        }

        public virtual DbSet<Astronomer> Astronomers { get; set; }
        public virtual DbSet<Discovery> Discoveries { get; set; }
        public virtual DbSet<Planet> Planets { get; set; }
        public virtual DbSet<Star> Stars { get; set; }
        public virtual DbSet<StarSystem> StarSystems { get; set; }
        public virtual DbSet<Telescope> Telescopes { get; set; }
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Astronomer>()
                .HasMany(a => a.ObservedDiscoveries)
                .WithMany(d => d.Observers)
                .Map(ca =>
                {
                    ca.MapLeftKey("AstronomerId");
                    ca.MapRightKey("ObservedDiscoveryId");
                    ca.ToTable("AstronomersObservedDiscoveries");
                });
            modelBuilder.Entity<Astronomer>()
                .HasMany(a => a.PioneeredDiscoveries)
                .WithMany(d => d.Pioneers)
            .Map(ca =>
             {
                 ca.MapLeftKey("AstronomerId");
                 ca.MapRightKey("PioneeredDiscoveryId");
                 ca.ToTable("AstronomersPioneeredDiscoveries");
             });
            base.OnModelCreating(modelBuilder);
        }
    }
}