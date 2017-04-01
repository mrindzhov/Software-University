namespace TeamBuilder.App.Core.Commands
{
    using System.Linq;
    using Data;
    using Models;
    using TeamBuilder.App.Interfaces;
    using Utilities;

    public class AcceptInviteCommand : IExecutable
    {
        //•	AcceptInvite <teamName> 
        //Checks current user’s active invites and accepts the one from the team specified.
        public string Execute(string[] args)
        {
            Validator.CheckLength(1, args);
            AuthenticationManager.Authorize();
            string teamName = args[0];
            Validator.ValidateInvitation(teamName, AuthenticationManager.GetCurrentUser());

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