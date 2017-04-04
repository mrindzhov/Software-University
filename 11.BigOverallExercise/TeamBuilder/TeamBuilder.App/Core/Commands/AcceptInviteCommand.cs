namespace TeamBuilder.App.Core.Commands
{
    using System.Linq;
    using App;
    using Models;
    using TeamBuilder.App.Interfaces;
    using TeamBuilder.App.Repositories;
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
            using (var uf = new UnitOfWork())
            {
                int currentUserId = AuthenticationManager.GetCurrentUser().Id;
                User user = uf.Users.GetById(u => u.Id == currentUserId);
                Team team = uf.Teams.GetByName(t => t.Name == teamName);
                user.Teams.Add(team);
                uf.Invitations
                    .FirstOrDefault(i => i.TeamId == team.Id && i.InvitedUserId == user.Id && i.IsActive)
                    .IsActive = false;
                uf.Commit();
            }
            
        }
    }
}