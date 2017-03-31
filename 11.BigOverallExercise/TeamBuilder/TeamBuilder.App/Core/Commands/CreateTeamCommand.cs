namespace TeamBuilder.App.Core.Commands
{
    using System;
    using Data;
    using Utilities;

    public class CreateTeamCommand
    {
        //•	CreateTeam<name> <acronym> <description>
        public string Execute(string[] args)
        {
            if (args.Length != 2 && args.Length != 3)
            {
                throw new ArgumentOutOfRangeException(nameof(args));
            }
            AuthenticationManager.Authorize();

            string teamName = args[0];

            if (CommandHelper.IsTeamExisting(teamName))
            {
                throw new ArgumentException(string.Format(Constants.ErrorMessages.TeamExists, teamName));
            }

            string acronym = args[1];
            if (acronym.Length != 3)
            {
                throw new ArgumentException(string.Format(Constants.ErrorMessages.InvalidAcronym, acronym));
            }

            string description = args.Length == 3 ? args[2] : null;

            this.AddTeam(teamName, acronym, description);
            return $"Team {teamName} successfully created!";

        }

        private void AddTeam(string teamName, string acronym, string description)
        {
            using (TeamBuilderContext ctx = new TeamBuilderContext())
            {
                ctx.Teams.Add(new Models.Team
                {
                    Name = teamName,
                    Acronym = acronym,
                    Description = description,
                    CreatorId = AuthenticationManager.GetCurrentUser().Id
                });
                ctx.SaveChanges();
            }
        }

    }
}