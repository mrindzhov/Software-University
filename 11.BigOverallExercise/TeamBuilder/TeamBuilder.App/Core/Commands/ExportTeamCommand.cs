namespace TeamBuilder.App.Core.Commands
{
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;
    using Newtonsoft.Json;
    using TeamBuilder.App.Utilities;
    using TeamBuilder.Data;
    using TeamBuilder.Models;

    public class ExportTeamCommand
    {
        public string Execute(string[] args)
        {
            Check.Length(1, args);

            string teamName = args[0];

            if (!CommandHelper.IsTeamExisting(teamName))
            {
                throw new ArgumentException(string.Format(Constants.ErrorMessages.TeamNotFound, teamName));
            }
            Team team = this.GetTeamWithMembersByName(teamName);

            string path=this.ExportTeam(team);

            return $"Team {teamName} exported to {path}!";

        }

        private string ExportTeam(Team team)
        {
            string path = "../../Export";
            string json = JsonConvert.SerializeObject(new
            {
                Name = team.Name,
                Acronym = team.Acronym,
                Members = team.Members.Select(m => m.Username)
            }, Formatting.Indented);
            File.WriteAllText(path + "/team.json", json);
            return path;
        }

        private Team GetTeamWithMembersByName(string teamName)
        {
            using (TeamBuilderContext ctx = new TeamBuilderContext())
            {
                return ctx.Teams.Include("Members").FirstOrDefault(t => t.Name == teamName);
            }
        }
    }
}
