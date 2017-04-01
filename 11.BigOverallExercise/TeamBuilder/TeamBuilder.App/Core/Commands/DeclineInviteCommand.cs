namespace TeamBuilder.App.Core.Commands
{
    using System.Linq;
    using Data;
    using Models;
    using TeamBuilder.App.Interfaces;
    using Utilities;

    public class DeclineInviteCommand : IExecutable
    {
        public string Execute(string[] args)
        {
            Validator.CheckLength(1, args);
            AuthenticationManager.Authorize();
            string teamName = args[0];
            Validator.ValidateInvitation(teamName, AuthenticationManager.GetCurrentUser());
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
