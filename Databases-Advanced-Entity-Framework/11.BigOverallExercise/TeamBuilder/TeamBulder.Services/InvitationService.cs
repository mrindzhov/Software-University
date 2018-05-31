namespace TeamBulder.Services
{
    using TeamBuilder.App.Repositories;
    using TeamBuilder.Models;

    public class InvitationService
    {
        public void AcceptInvitation(string teamName, User currentUser)
        {
            using (var uf = new UnitOfWork())
            {
                User user = currentUser;
                Team team = uf.Teams.GetByName(t => t.Name == teamName);
                user.Teams.Add(team);
                uf.Invitations
                    .FirstOrDefault(i => i.TeamId == team.Id && i.InvitedUserId == user.Id && i.IsActive)
                    .IsActive = false;
                uf.Commit();
            }
        }

        public void DeclineInvitation(string teamName, User currentUser)
        {
            using (var uf = new UnitOfWork())
            {
                User user = currentUser;
                Team team = uf.Teams.GetByName(t => t.Name == teamName);

                uf.Invitations
                    .FirstOrDefault(i => i.TeamId == team.Id && i.InvitedUserId == user.Id && i.IsActive)
                    .IsActive = false;
                uf.Commit();
            }
        }
    }
}