namespace TeamBuilder.App.Core.Commands
{
    using System;
    using System.Collections.Generic;
    using TeamBuilder.App.Interfaces;
    using TeamBuilder.App.Utilities;
    using TeamBuilder.Models;
    using TeamBulder.Services;

    public class ImportTeamsCommand : IExecutable
    {
        private readonly TeamService teamService;
        public ImportTeamsCommand() : this(new TeamService())
        {
        }
        public ImportTeamsCommand(TeamService teamService)
        {
            this.teamService = teamService;
        }
        public string Execute(string[] args)
        {
            Validator.ValidateLength(1, args);

            string filePath = args[0];
            Validator.ValidatePath(filePath);
            ICollection<Team> teams;

            try
            {
                teams = DataLoader.GetTeamsFromXML(filePath);
            }
            catch (Exception)
            {
                throw new FormatException(Constants.ErrorMessages.InvalidXmlFormat);
            }
            this.teamService.AddTeams(teams);
         
            return $"You have successfully imported {teams.Count} teams!";
        }
    }
}
