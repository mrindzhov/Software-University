namespace TeamBuilder.App.Core.Commands
{
    using TeamBuilder.App.Interfaces;
    using TeamBulder.Services;
    using Utilities;

    public class CreateTeamCommand : IExecutable
    {
        private readonly TeamService teamService;
        public CreateTeamCommand() : this(new TeamService())
        {
        }
        public CreateTeamCommand(TeamService teamService)
        {
            this.teamService = teamService;
        }
        //•	CreateTeam<name> <acronym> <description>
        public string Execute(string[] args)
        {
            AuthenticationManager.Authorize();
            string teamName = args[0];
            string acronym = args[1];
            string description = args.Length == 3 ? args[2] : null;

            Validator.ValidateCreateTeamCommand(args, teamName, acronym);

            this.teamService.AddTeam(teamName, acronym, description, AuthenticationManager.GetCurrentUser().Id);
            return $"Team {teamName} successfully created!";
        }
    }
}