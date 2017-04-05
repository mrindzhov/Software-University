namespace TeamBuilder.App.Core.Commands
{
    using TeamBuilder.App.Interfaces;
    using TeamBulder.Services;
    using Utilities;

    public class ShowTeamCommand : IExecutable
    {
        private readonly TeamService teamService;
        public ShowTeamCommand() : this(new TeamService())
        {
        }
        public ShowTeamCommand(TeamService teamService)
        {
            this.teamService = teamService;
        }
        public string Execute(string[] args)
        {
            Validator.ValidateLength(1, args);

            string teamName = args[0];

            Validator.ValidateShowTeamCommand(teamName);
            return this.teamService.LoadTeamAndMembers(teamName);
        }
    }
}
