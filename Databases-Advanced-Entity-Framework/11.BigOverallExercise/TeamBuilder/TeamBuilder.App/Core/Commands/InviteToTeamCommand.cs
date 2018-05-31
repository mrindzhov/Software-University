namespace TeamBuilder.App.Core.Commands
{
    using Utilities;
    using TeamBuilder.App.Interfaces;
    using TeamBulder.Services;

    public class InviteToTeamCommand : IExecutable
    {
        private readonly UserService userService;
        public InviteToTeamCommand() : this(new UserService())
        {
        }
        public InviteToTeamCommand(UserService userService)
        {
            this.userService = userService;
        }

        //•	InviteToTeam <teamName> <username>
        //        Sends an invite to the specified user to join given team.
        //If the user is actually the creator of the team – add him/her directly!
        public string Execute(string[] args)
        {
            Validator.ValidateLength(2, args);
            AuthenticationManager.Authorize();
            string teamName = args[0];
            string username = args[1];

            Validator.ValidateAddTeamToCommand(teamName, username);
            this.userService.SendInvitation(teamName, username);
            return $"Team {teamName} invited {username}!";
        }
    }
}
