namespace TeamBuilder.App.Core.Commands
{
    using Models;
    using TeamBuilder.App.Interfaces;
    using TeamBuilder.App.Repositories;
    using Utilities;

    public class DisbandCommand : IExecutable
    {
        public string Execute(string[] inputArgs)
        {
            Validator.ValidateLength(1, inputArgs);
            AuthenticationManager.Authorize();

            string teamName = inputArgs[0];

            Validator.ValidateDisbandCommand(teamName);
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
