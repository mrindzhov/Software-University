namespace TeamBuilder.App.Core.Commands
{
    using System;
    using System.Linq;
    using Data;
    using Models;
    using Utilities;

    public class DisbandCommand
    {
        public string Execute(string[] inputArgs)
        {
            Check.Length(1, inputArgs);
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
            using (TeamBuilderContext ctx = new TeamBuilderContext())
            {
                Team team = ctx.Teams.FirstOrDefault(t => t.Name == teamName);
                ctx.Teams.Remove(team);
                ctx.SaveChanges();
            }
        }
    }
}
