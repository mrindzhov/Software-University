namespace TeamBuilder.App.Core.Commands
{
    using System;
    using Data;
    using TeamBuilder.App.Interfaces;
    using TeamBuilder.Data.Repositories;
    using Utilities;

    public class CreateTeamCommand : IExecutable
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

            using (var uf = new UnitOfWork())
            {
                uf.Teams.Add(new Models.Team
                {
                    Name = teamName,
                    Acronym = acronym,
                    Description = description,
                    CreatorId = AuthenticationManager.GetCurrentUser().Id
                });
                uf.Commit();
            }
            //using (TeamBuilderContext ctx = new TeamBuilderContext())
            //{
            //    ctx.Teams.Add(new Models.Team
            //    {
            //        Name = teamName,
            //        Acronym = acronym,
            //        Description = description,
            //        CreatorId = AuthenticationManager.GetCurrentUser().Id
            //    });
            //    ctx.SaveChanges();
            //}
        }

    }
}