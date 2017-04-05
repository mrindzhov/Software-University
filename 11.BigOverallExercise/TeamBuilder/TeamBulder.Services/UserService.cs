namespace TeamBulder.Services
{
    using System.Collections.Generic;
    using TeamBuilder.App.Repositories;
    using TeamBuilder.Models;

    public class UserService : IService
    {
        public void RegisterUser(User user)
        {
            using (var uf = new UnitOfWork())
            {
                uf.Users.Add(user);
                uf.Commit();
            }
        }

        public User GetUserByCredentials(string username, string password)
        {
            using (var uf = new UnitOfWork())
            {
                return uf.Users
                    .FirstOrDefault(u => u.Username == username &&
                    u.Password == password && u.IsDeleted == false);
            }
        }

        public void KickMemberFromTeam(string teamName, string username)
        {
            using (var uf = new UnitOfWork())
            {
                Team team = uf.Teams.GetByName(t => t.Name == teamName);
                User user = uf.Users.GetByName(u => u.Username == username);

                team.Members.Remove(user);
                uf.Commit();
            }
        }

        public void DeleteUser(User user)
        {
            using (var uf = new UnitOfWork())
            {
                uf.Users.GetById(u => u.Id == user.Id).IsDeleted = true;
                uf.Commit();
            }
        }

        public void SendInvitation(string teamName, string username)
        {
            using (var uf = new UnitOfWork())
            {
                Team team = uf.Teams.GetByName(t => t.Name == teamName);
                User user = uf.Users.GetByName(u => u.Username == username);
                Invitation inv = new Invitation
                {
                    TeamId = team.Id,
                    InvitedUserId = user.Id
                };
                if (team.CreatorId == user.Id)
                {
                    inv.IsActive = false;
                    team.Members.Add(user);
                }
                uf.Invitations.Add(inv);
                uf.Commit();
            }
        }

        public void AddUsers(ICollection<User> users)
        {
            using (var uf = new UnitOfWork())
            {
                uf.Users.AddRange(users);
                uf.Commit();
            }
        }
    }
}