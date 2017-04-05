namespace TeamBuilder.App.Core.Commands
{
    using Models;
    using TeamBuilder.App.Interfaces;
    using TeamBuilder.App.Repositories;
    using Utilities;

    public class DeclineInviteCommand : IExecutable
    {
        public string Execute(string[] args)
        {
            Validator.ValidateLength(1, args);
            AuthenticationManager.Authorize();
            string teamName = args[0];
            Validator.ValidateInvitation(teamName, AuthenticationManager.GetCurrentUser());
            this.DeclineInvitation(teamName);

            return $"Invite from {teamName} declined!";
        }

        private void DeclineInvitation(string teamName)
        {
            using (var uf = new UnitOfWork())
            {
                int currentUserId = AuthenticationManager.GetCurrentUser().Id;
                User user = uf.Users.GetById(u => u.Id == currentUserId);
                Team team = uf.Teams.GetByName(t => t.Name == teamName);

                uf.Invitations
                    .FirstOrDefault(i => i.TeamId == team.Id && i.InvitedUserId == user.Id && i.IsActive)
                    .IsActive = false;
                uf.Commit();
            }
        }
    }
}
