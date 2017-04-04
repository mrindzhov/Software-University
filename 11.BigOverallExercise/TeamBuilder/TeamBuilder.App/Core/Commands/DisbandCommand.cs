namespace TeamBuilder.App.Core.Commands
{
    using System;
    using Models;
    using TeamBuilder.App.Interfaces;
    using TeamBuilder.App.Repositories;
    using Utilities;

    public class DisbandCommand : IExecutable
    {
        public string Execute(string[] inputArgs)
        {
            Validator.CheckLength(1, inputArgs);
            AuthenticationManager.Authorize();

            string teamName = inputArgs[0];

            if (!CommandHelper.IsTeamExisting(teamName))
            {
                throw new ArgumentException(string.Format(Constants.ErrorMessages.TeamNotFound, teamName));
            }
            if (!CommandHelper.IsCreatorOfTeam(teamName, AuthenticationManager.GetCurrentUser().Username))
            {
                throw new InvalidOperationException(Constants.ErrorMessages.NotAllowed);
            }
            this.DisbandTem(teamName);

            return $"Team {teamName} was disbaned!";
        }

        private void DisbandTem(string teamName)
        {
            using (var uf = new UnitOfWork())
            {
                Team team = uf.Teams.FirstOrDefault(t => t.Name == teamName);
                uf.Teams.Delete(team);
                uf.Commit();
            }
        }
    }
}
