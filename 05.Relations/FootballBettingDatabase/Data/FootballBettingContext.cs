namespace Data
{
    using Models;
    using System.Data.Entity;
    

    public class FootballBettingContext : DbContext
    {

        public FootballBettingContext()
            : base("name=FootballBettingContext")
        {
        }


        public virtual DbSet<Bet> Bets { get; set; }

        public virtual DbSet<BetGame> BetGames { get; set; }

        public virtual DbSet<Color> Colors { get; set; }

        public virtual DbSet<Competition> Competitions { get; set; }

        public virtual DbSet<CompetitionType> CompetitionTypes { get; set; }

        public virtual DbSet<Continent> Continents { get; set; }

        public virtual DbSet<Country> Countrys { get; set; }

        public virtual DbSet<Game> Games { get; set; }

        public virtual DbSet<Player> Players { get; set; }

        public virtual DbSet<PlayerStatistics> PlayersStatistics { get; set; }

        public virtual DbSet<Position> Positions { get; set; }

        public virtual DbSet<ResultPrediction> ResultPredictions { get; set; }

        public virtual DbSet<Round> Rounds { get; set; }

        public virtual DbSet<Team> Teams { get; set; }

        public virtual DbSet<Town> Towns { get; set; }

        public virtual DbSet<User> Users { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Country>()
                .HasMany(country => country.Continent)
                .WithMany(continent => continent.Countries)
                .Map(configuration =>
                {
                    configuration.MapLeftKey("CountryId");
                    configuration.MapRightKey("ContinentId");
                    configuration.ToTable("CountryContinents");
                });

            base.OnModelCreating(modelBuilder);
        }
    }
}