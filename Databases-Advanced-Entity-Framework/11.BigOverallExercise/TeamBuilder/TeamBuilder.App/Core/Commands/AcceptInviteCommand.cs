namespace TeamBuilder.App.Core.Commands
{
    using TeamBuilder.App.Interfaces;
    using TeamBulder.Services;
    using Utilities;

    public class AcceptInviteCommand : IExecutable
    {
        private readonly InvitationService invitationService;
        public AcceptInviteCommand() : this(new InvitationService())
        {
        }
        public AcceptInviteCommand(InvitationService invitationService)
        {
            this.invitationService = invitationService;
        }
        //•	AcceptInvite <teamName> 
        //Checks current user’s active invites and accepts the one from the team specified.
        public string Execute(string[] args)
        {
            Validator.ValidateLength(1, args);
            AuthenticationManager.Authorize();
            string teamName = args[0];

            Validator.ValidateInvitation(teamName, AuthenticationManager.GetCurrentUser());

            this.invitationService.AcceptInvitation(teamName, AuthenticationManager.GetCurrentUser());

            return $"User {AuthenticationManager.GetCurrentUser().Username} joined team {teamName}!";

        }
    }
}