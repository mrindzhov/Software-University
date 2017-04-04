namespace TeamBuilder.App.Core.Commands
{
    using System;
    using System.Linq;
    using System.Text;
    using Models;
    using TeamBuilder.App.Interfaces;
    using TeamBuilder.App.Repositories;
    using Utilities;

    public class ShowTeamCommand : IExecutable
    {
        public string Execute(string[] args)
        {
            Validator.CheckLength(1, args);

            string teamName = args[0];
            if (!CommandHelper.IsTeamExisting(teamName))
            {
                throw new ArgumentException(string.Format(Constants.ErrorMessages.TeamNotFound, teamName));
            }
            return this.LoadTeamAndMembers(teamName);
        }

        private string LoadTeamAndMembers(string teamName)
        {
            StringBuilder sb = new StringBuilder();
            using (var uf = new UnitOfWork())
            {
                Team team = uf.Teams.GetByName(t => t.Name == teamName);
                sb.AppendLine($"{team.Name} {team.Acronym}");

                sb.AppendLine($"Members: {team.Members.Count()}");
                foreach (var member in team.Members)
                {
                    sb.AppendLine($"--{member.Username}");
                }
            }
            return sb.ToString().Trim();
        }
    }
}
