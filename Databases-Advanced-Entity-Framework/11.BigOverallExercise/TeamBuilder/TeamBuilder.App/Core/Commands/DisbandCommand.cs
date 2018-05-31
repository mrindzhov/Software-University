namespace TeamBuilder.App.Core.Commands
{
    using TeamBuilder.App.Interfaces;
    using TeamBulder.Services;
    using Utilities;

    public class DisbandCommand : IExecutable
    {
        private readonly TeamService teamService;
        public DisbandCommand() : this(new TeamService())
        {
        }
        public DisbandCommand(TeamService teamService)
        {
            this.teamService = teamService;
        }
        public string Execute(string[] inputArgs)
        {
            Validator.ValidateLength(1, inputArgs);
            AuthenticationManager.Authorize();

            string teamName = inputArgs[0];

            Validator.ValidateDisbandCommand(teamName);
            this.teamService.DisbandTeam(teamName);

            return $"Team {teamName} was disbaned!";
        }
    }
}
