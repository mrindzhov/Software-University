﻿namespace TeamBuilder.App.Configurations
{

    using System.Data.Entity.ModelConfiguration;
    using Models;

    class InvitationConfiguration : EntityTypeConfiguration<Invitation>
    {
        public InvitationConfiguration()
        {
            this.HasRequired(i => i.Team).WithMany(t => t.Invitations);

            this.HasRequired(i => i.InvitedUser).WithMany(u => u.ReceivedInvitations);

        }
    }
}