namespace TeamBuilder.App.Core.Commands
{
    using System;
    using System.Linq;
    using Data;
    using Models;
    using TeamBuilder.App.Interfaces;
    using TeamBuilder.Data.Repositories;
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
            //using (TeamBuilderContext ctx = new TeamBuilderContext())
            //{
            //    Team team = ctx.Teams.FirstOrDefault(t => t.Name == teamName);
            //    ctx.Teams.Remove(team);
            //    ctx.SaveChanges();
            //}
        }
    }
}
