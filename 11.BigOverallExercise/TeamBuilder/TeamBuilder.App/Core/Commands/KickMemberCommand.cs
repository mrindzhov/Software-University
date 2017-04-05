namespace TeamBuilder.App.Core.Commands
{
    using System;
    using Models;
    using TeamBuilder.App.Interfaces;
    using TeamBuilder.App.Repositories;
    using Utilities;

    public class KickMemberCommand : IExecutable
    {
        //•	KickMember<teamName> <username>
        //Removes specified user member from given team.Only the creator of the team can kick other members.
        public string Execute(string[] inputArgs)
        {
            Validator.ValidateLength(2, inputArgs);
            AuthenticationManager.Authorize();

            string teamName = inputArgs[0];

            string username = inputArgs[1];

            Validator.ValidateKickMemberCommand(teamName, username);

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
        }
    }
}
