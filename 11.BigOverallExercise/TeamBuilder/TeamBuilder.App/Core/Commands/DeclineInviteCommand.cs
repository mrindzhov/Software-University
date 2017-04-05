namespace TeamBuilder.App.Core.Commands
{
    using TeamBuilder.App.Interfaces;
    using TeamBulder.Services;
    using Utilities;

    public class DeclineInviteCommand : IExecutable
    {
        private readonly InvitationService invitationService;
        public DeclineInviteCommand() : this(new InvitationService())
        {
        }
        public DeclineInviteCommand(InvitationService invitationService)
        {
            this.invitationService = invitationService;
        }
        public string Execute(string[] args)
        {
            Validator.ValidateLength(1, args);
            AuthenticationManager.Authorize();
            string teamName = args[0];
            Validator.ValidateInvitation(teamName, AuthenticationManager.GetCurrentUser());

            this.invitationService.DeclineInvitation(teamName, AuthenticationManager.GetCurrentUser());
            return $"Invite from {teamName} declined!";
        }
    }
}
