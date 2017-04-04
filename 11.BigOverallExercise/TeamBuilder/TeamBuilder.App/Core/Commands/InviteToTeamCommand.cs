namespace TeamBuilder.App.Core.Commands
{
    using System;
    using Utilities;
    using Models;
    using TeamBuilder.App.Interfaces;
    using TeamBuilder.App.Repositories;

    public class InviteToTeamCommand : IExecutable
    {
        //•	InviteToTeam <teamName> <username>
        //        Sends an invite to the specified user to join given team.
        //If the user is actually the creator of the team – add him/her directly!
        public string Execute(string[] args)
        {
            Validator.CheckLength(2, args);
            AuthenticationManager.Authorize();
            string teamName = args[0];
            string username = args[1];

            if (!CommandHelper.IsTeamExisting(teamName) || !CommandHelper.IsUserExisting(username))
            {
                throw new ArgumentException(Constants.ErrorMessages.TeamOrUserNotExist);
            }
            if (CommandHelper.IsInvitePending(teamName, username))
            {
                throw new InvalidOperationException(Constants.ErrorMessages.InviteIsAlreadySent);
            }

            if (!CommandHelper.IsCreatorOrPartOfTeam(teamName))
            {
                throw new InvalidOperationException(Constants.ErrorMessages.NotAllowed);
            }
            this.SendInvitation(teamName, username);
            return $"Team {teamName} invited {username}!";
        }

        private void SendInvitation(string teamName, string username)
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
    }
}
