namespace TeamBuilder.App.Utilities
{
    using Data;
    using System.Linq;
    using Core;
    using Models;

    public static class CommandHelper
    {
        public static bool IsTeamExisting(string teamName)
        {
            using (TeamBuilderContext context = new TeamBuilderContext())
            {
                return context.Teams.Any(t => t.Name == teamName);
            }
        }
        public static bool IsUserExisting(string username)
        {
            using (TeamBuilderContext context = new TeamBuilderContext())
            {
                return context.Users.Any(u => u.Username == username);
            }
        }
        public static bool IsInviteExisting(string teamName, User user)
        {
            using (TeamBuilderContext context = new TeamBuilderContext())
            {
                return context.Invitations.Any(i => i.Team.Name == teamName && i.InvitedUserId == user.Id && i.IsActive);
            }
        }


        public static bool IsMemberOfTeam(string teamName, string username)
        {
            using (TeamBuilderContext context = new TeamBuilderContext())
            {
                return context.Teams.Any(t => t.Name == teamName && t.Members.Any(m => m.Username == username));
            }
        }

        public static bool IsUserCreatorOfEvent(string eventName, int id)
        {
            using (TeamBuilderContext context = new TeamBuilderContext())
            {
                User user = context.Users.FirstOrDefault(u => u.Id == id);
                Event ev = context.Events.FirstOrDefault(e => e.Name == eventName);

                return ev.CreatorId == user.Id;
            }
        }

        public static bool IsCreatorOrPartOfTeam(string teamName)
        {
            using (TeamBuilderContext ctx = new TeamBuilderContext())
            {
                User user = AuthenticationManager.GetCurrentUser();
                return ctx.Teams.Include("Members")
                    .Any(t => t.Name == teamName && (t.CreatorId == user.Id || t.Members.Any(m => m.Id == user.Id)));
            }
        }
        public static bool IsEventExisting(string eventName)
        {
            using (TeamBuilderContext context = new TeamBuilderContext())
            {
                return context.Events.Any(e => e.Name == eventName);
            }
        }

        public static bool IsInvitePending(string teamName, string username)
        {
            using (TeamBuilderContext ctx = new TeamBuilderContext())
            {
                return ctx.Invitations.Include("Team").Include("InvitedUser")
                    .Any(i => i.Team.Name == teamName && i.IsActive && i.InvitedUser.Username == username);
            }
        }
        public static bool IsCreatorOfTeam(string teamName, string username)
        {
            using (TeamBuilderContext context = new TeamBuilderContext())
            {
                User user = context.Users.FirstOrDefault(u => u.Username == username);
                Team team = context.Teams.FirstOrDefault(t => t.Name == teamName);

                return team.CreatorId == user.Id;
            }
        }

    }
}
