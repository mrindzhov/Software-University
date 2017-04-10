namespace WeddingsPlanner.Data
{
    using System.Data.Entity;
    using WeddingsPlanner.Models;

    public class WeddingsPlannerContext : DbContext
    {
        public WeddingsPlannerContext()
            : base("name=WeddingsPlannerContext")
        {
        }


        public virtual DbSet<Venue> Venues { get; set; }
        public virtual DbSet<Agency> Agencies { get; set; }
        public virtual DbSet<Person> People { get; set; }
        public virtual DbSet<Wedding> Weddings { get; set; }
        public virtual DbSet<Invitation> Invitations { get; set; }
        public virtual DbSet<Present> Presents { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Present>()
                .HasKey(p => p.InvitationId);

            modelBuilder.Entity<Invitation>()
                .HasRequired(i => i.Present)
                .WithRequiredPrincipal(p => p.Invitation);

            base.OnModelCreating(modelBuilder);
        }
    }
}