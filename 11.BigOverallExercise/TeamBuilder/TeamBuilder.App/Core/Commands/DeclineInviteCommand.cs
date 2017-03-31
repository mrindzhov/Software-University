namespace TeamBuilder.App.Core.Commands
{
    using System;
    using System.Linq;
    using Data;
    using Models;
    using Utilities;

    public class DeclineInviteCommand
    {
        public string Execute(string[] args)
        {
            Check.CheckLength(1, args);
            AuthenticationManager.Authorize();
            string teamName = args[0];

            if (!CommandHelper.IsTeamExisting(teamName))
            {
                throw new ArgumentException(string.Format(Constants.ErrorMessages.TeamNotFound, teamName));
            }

            if (!CommandHelper.IsInviteExisting(teamName, AuthenticationManager.GetCurrentUser()))
            {
                throw new ArgumentException(string.Format(Constants.ErrorMessages.InviteNotFound, teamName));
            }
            this.DeclineInvitation(teamName);

            return $"Invite from {teamName} declined!!";
        }

        private void DeclineInvitation(string teamName)
        {
            using (TeamBuilderContext ctx = new TeamBuilderContext())
            {
                int currentUserId = AuthenticationManager.GetCurrentUser().Id;
                User user = ctx.Users.FirstOrDefault(u => u.Id == currentUserId);
                Team team = ctx.Teams.FirstOrDefault(t => t.Name == teamName);
                ctx.Invitations
                    .FirstOrDefault(i => i.TeamId == team.Id && i.InvitedUserId == user.Id && i.IsActive)
                    .IsActive = false;
                ctx.SaveChanges();
            }
        }
    }
}
