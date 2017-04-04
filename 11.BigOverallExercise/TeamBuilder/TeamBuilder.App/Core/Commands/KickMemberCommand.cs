namespace TeamBuilder.App.Core.Commands
{
    using System;
    using System.Linq;
    using Data;
    using Models;
    using TeamBuilder.App.Interfaces;
    using TeamBuilder.Data.Repositories;
    using Utilities;

    public class KickMemberCommand : IExecutable
    {
        //•	KickMember<teamName> <username>
        //Removes specified user member from given team.Only the creator of the team can kick other members.
        public string Execute(string[] inputArgs)
        {
            Validator.CheckLength(2, inputArgs);
            AuthenticationManager.Authorize();

            string teamName = inputArgs[0];
            if (!CommandHelper.IsTeamExisting(teamName))
            {
                throw new ArgumentException(string.Format(Constants.ErrorMessages.TeamNotFound, teamName));
            }

            string username = inputArgs[1];
            if (!CommandHelper.IsUserExisting(username))
            {
                throw new ArgumentException(string.Format(Constants.ErrorMessages.UserNotFound, username));
            }

            if (!CommandHelper.IsMemberOfTeam(teamName, username))
            {
                throw new ArgumentException(string.Format(Constants.ErrorMessages.NotPartOfTeam, username, teamName));
            }
            if (CommandHelper.IsCreatorOfTeam(teamName, username))
            {
                throw new InvalidOperationException(Constants.ErrorMessages.NotAllowed);
            }
            if (AuthenticationManager.GetCurrentUser().Username == username)
            {
                throw new InvalidOperationException(string.Format(Constants.ErrorMessages.CommandNotAllowed, "Disband Team"));
            }
            this.KickMember(teamName, username);
            
            return $"User {username} was kicked from {teamName}!";
        }

        private void KickMember(string teamName, string username)
        {
            using (var uf = new UnitOfWork())
            {
                Team team = uf.Teams.GetByName(t => t.Name == teamName);
                User user = uf.Users.GetByName(u => u.Username == username);

                team.Members.Remove(user);
                uf.Commit();
            }
            //using (TeamBuilderContext context = new TeamBuilderContext())
            //{
            //    Team team = context.Teams.FirstOrDefault(t => t.Name == teamName);
            //    User user = context.Users.FirstOrDefault(u => u.Username == username);

            //    team.Members.Remove(user);
            //    context.SaveChanges();
            //}
        }
    }
}
