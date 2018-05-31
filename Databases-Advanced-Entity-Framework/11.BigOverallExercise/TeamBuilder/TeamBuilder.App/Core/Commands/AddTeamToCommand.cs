namespace TeamBuilder.App.Core.Commands
{
    using TeamBuilder.App.Interfaces;
    using TeamBulder.Services;
    using Utilities;

    public class AddTeamToCommand : IExecutable
    {
        private readonly TeamService teamService;
        public AddTeamToCommand() : this(new TeamService())
        {
        }
        public AddTeamToCommand(TeamService teamService)
        {
            this.teamService = teamService;
        }
        public string Execute(string[] inputArgs)
        {
            Validator.ValidateLength(2, inputArgs);
            AuthenticationManager.Authorize();
            string eventName = inputArgs[0];
            string teamName = inputArgs[1];
            Validator.ValidateAddTeamToEventCommand(eventName, teamName, AuthenticationManager.GetCurrentUser().Id);
            this.teamService.AddTeamToEvent(teamName, eventName);
            return $"Team {teamName} added to {eventName}!";
        }
    }
}