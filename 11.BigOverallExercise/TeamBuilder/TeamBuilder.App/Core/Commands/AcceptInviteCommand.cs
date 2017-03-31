namespace TeamBuilder.App.Core.Commands
{
    using System;
    using System.Linq;
    using Data;
    using Models;
    using Utilities;

    public class AcceptInviteCommand
    {
        //•	AcceptInvite <teamName>
        //Checks current user’s active invites and accepts the one from the team specified.
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
            this.AcceptInvitation(teamName);

            return $"User {AuthenticationManager.GetCurrentUser().Username} joined team {teamName}!";

        }

        private void AcceptInvitation(string teamName)
        {
            using (TeamBuilderContext ctx = new TeamBuilderContext())
            {
                int currentUserId = AuthenticationManager.GetCurrentUser().Id;
                User user = ctx.Users.FirstOrDefault(u => u.Id == currentUserId);
                Team team = ctx.Teams.FirstOrDefault(t => t.Name == teamName);

                user.Teams.Add(team);
                ctx.Invitations
                    .FirstOrDefault(i => i.TeamId == team.Id && i.InvitedUserId == user.Id && i.IsActive)
                    .IsActive = false;
                ctx.SaveChanges();
            }
        }
    }
}