namespace TeamBuilder.Data.Configurations
{
    using System.Data.Entity.ModelConfiguration;
    using TeamBuilder.Models;

    class EventConfiguration : EntityTypeConfiguration<Event>
    {
        public EventConfiguration()
        {
            this.Property(u => u.Name).IsRequired().HasMaxLength(25);

            this.Property(u => u.Description).HasMaxLength(250);

            this.HasRequired(u => u.Creator).WithMany(e => e.CreatedEvents);

            this.HasMany(u => u.ParticipatingTeams)
                .WithMany(t => t.ParticipatedEvents).Map(ut =>
            {
                ut.ToTable("EventTeams");
                ut.MapLeftKey("EventId");
                ut.MapRightKey("TeamId");
            });
                
        }
    }
}
