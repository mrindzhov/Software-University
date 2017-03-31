namespace TeamBuilder.Data.Configurations
{
    using System.Data.Entity.ModelConfiguration;
    using Models;
    using System.Data.Entity.Infrastructure.Annotations;
    using System.ComponentModel.DataAnnotations.Schema;

    class TeamConfiguration : EntityTypeConfiguration<Team>
    {
        public TeamConfiguration()
        {
            this.Property(t => t.Name)
                    .HasColumnAnnotation(IndexAnnotation.AnnotationName,
                         new IndexAnnotation(
                             new IndexAttribute("IX_Team_Name", 1) { IsUnique = true }))
                    .HasMaxLength(25).IsRequired();

            this.Property(u => u.Description).HasMaxLength(32);

            this.Property(t => t.Acronym).IsRequired().HasMaxLength(3).IsFixedLength();

            this.HasRequired(u => u.Creator).WithMany(u => u.CreatedTeams);

            this.HasMany(u => u.Invitations).WithRequired(t => t.Team);

            //this.HasMany(t => t.ParticipatedEvents).WithMany(ev => ev.ParticipatingTeams).Map(ut =>
            //{
            //    ut.MapLeftKey("EventId");
            //    ut.MapRightKey("TeamId");
            //    ut.ToTable("EventTeams");
            //});

        }
    }
}