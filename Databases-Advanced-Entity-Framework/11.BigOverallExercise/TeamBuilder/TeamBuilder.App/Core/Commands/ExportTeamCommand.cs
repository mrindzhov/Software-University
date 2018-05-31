namespace TeamBuilder.App.Core.Commands
{
    using TeamBuilder.App.Interfaces;
    using TeamBuilder.App.Utilities;
    using TeamBuilder.Models;
    using TeamBulder.Services;

    public class ExportTeamCommand : IExecutable
    {
        private readonly TeamService teamService;
        public ExportTeamCommand() : this(new TeamService())
        {
        }
        public ExportTeamCommand(TeamService teamService)
        {
            this.teamService = teamService;
        }
        public string Execute(string[] args)
        {
            Validator.ValidateLength(1, args);
            string teamName = args[0];

            Validator.ValidateExportTeamCommand(teamName);
            Team team = this.teamService.GetTeamWithMembersByName(teamName);
            string path = DataLoader.ExportTeam(team);
            return $"Team {teamName} exported to {path}!";
        }
    }
}
