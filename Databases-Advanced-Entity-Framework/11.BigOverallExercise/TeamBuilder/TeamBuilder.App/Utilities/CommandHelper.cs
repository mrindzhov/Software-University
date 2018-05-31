namespace TeamBuilder.App.Utilities
{
    using System.Data.Entity;
    using System.Linq;
    using Core;
    using Models;
    using TeamBuilder.App.Repositories;

    public static class CommandHelper
    {
        public static bool IsTeamExisting(string teamName)
        {
            using (var uf = new UnitOfWork())
            {
                return uf.Teams.Any(t => t.Name == teamName);
            }
        }
        public static bool IsUserExisting(string username)
        {
            using (var uf = new UnitOfWork())
            {
                return uf.Users.Any(u => u.Username == username);
            }

        }
        public static bool IsInviteExisting(string teamName, User user)
        {
            using (var uf = new UnitOfWork())
            {
                return uf.Invitations.Any(i => i.Team.Name == teamName && i.InvitedUserId == user.Id && i.IsActive);
            }
        }


        public static bool IsMemberOfTeam(string teamName, string username)
        {
            using (var uf = new UnitOfWork())
            {
                return uf.Teams.Any(t => t.Name == teamName && t.Members.Any(m => m.Username == username));
            }
        }

        public static bool IsUserCreatorOfEvent(string eventName, int id)
        {
            using (var uf = new UnitOfWork())
            {
                User user = uf.Users.GetById(u => u.Id == id);
                Event ev = uf.Events.GetByName(e => e.Name == eventName);

                return ev.CreatorId == user.Id;

            }
        }

        public static bool IsCreatorOrPartOfTeam(string teamName)
        {
            using (var uf = new UnitOfWork())
            {
                User user = AuthenticationManager.GetCurrentUser();
                return uf.Teams.Include("Members")
                    .Any(t => t.Name == teamName && (t.CreatorId == user.Id || t.Members.Any(m => m.Id == user.Id)));
            }

        }
        public static bool IsEventExisting(string eventName)
        {
            using (var uf = new UnitOfWork())
            {
                return uf.Events.Any(e => e.Name == eventName);
            }
        }

        public static bool IsCreatorOfTeam(string teamName, string username)
        {
            using (var uf = new UnitOfWork())
            {
                User user = uf.Users.GetByName(u => u.Username == username);
                Team team = uf.Teams.GetByName(t => t.Name == teamName);

                return team.CreatorId == user.Id;
            }
        }
        public static bool IsInvitePending(string teamName, string username)
        {
            using (var uf = new UnitOfWork())
            {
                return uf.Invitations.Include("Team").Include("InvitedUser")
                    .Any(i => i.Team.Name == teamName && i.IsActive && i.InvitedUser.Username == username);
            }
        }
        
    }
}