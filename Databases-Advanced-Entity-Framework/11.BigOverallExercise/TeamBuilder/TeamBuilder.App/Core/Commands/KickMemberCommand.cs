namespace TeamBuilder.App.Core.Commands
{
    using TeamBuilder.App.Interfaces;
    using TeamBulder.Services;
    using Utilities;

    public class KickMemberCommand : IExecutable
    {
        private readonly UserService userService;
        public KickMemberCommand() : this(new UserService())
        {
        }
        public KickMemberCommand(UserService userService)
        {
            this.userService = userService;
        }
        //•	KickMember<teamName> <username>
        //Removes specified user member from given team.Only the creator of the team can kick other members.
        public string Execute(string[] inputArgs)
        {
            Validator.ValidateLength(2, inputArgs);
            AuthenticationManager.Authorize();
            string teamName = inputArgs[0];
            string username = inputArgs[1];
            Validator.ValidateKickMemberCommand(teamName, username);
            this.userService.KickMemberFromTeam(teamName, username);
   
            return $"User {username} was kicked from {teamName}!";
        }
    }
}