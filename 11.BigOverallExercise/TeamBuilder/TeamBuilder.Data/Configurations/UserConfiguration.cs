namespace TeamBuilder.App.Configurations
{
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Infrastructure.Annotations;
    using System.Data.Entity.ModelConfiguration;
    using Models;

    public class UserConfiguration : EntityTypeConfiguration<User>
    {
        public UserConfiguration()
        {
            this.Property(u => u.Username)
                .HasColumnAnnotation(IndexAnnotation.AnnotationName,
                        new IndexAnnotation(
                            new IndexAttribute("IX_Users_Username", 1) { IsUnique = true })).HasMaxLength(25).IsRequired();
            this.Property(u => u.FirstName).HasMaxLength(25);
            this.Property(u => u.LastName).HasMaxLength(25);

            this.Property(u => u.Password).HasMaxLength(30).IsRequired();

            this.HasMany(u => u.CreatedTeams).WithRequired(u => u.Creator).WillCascadeOnDelete(false);

            this.HasMany(u => u.CreatedEvents).WithRequired(u => u.Creator).WillCascadeOnDelete(false);

            this.HasMany(u => u.Teams).WithMany(u => u.Members).Map(ca =>
            {
                ca.MapLeftKey("UserId");
                ca.MapRightKey("TeamId");
                ca.ToTable("UserTeams");

            });

            this.HasMany(u => u.ReceivedInvitations).WithRequired(i => i.InvitedUser).WillCascadeOnDelete(false);

        }
    }
}
