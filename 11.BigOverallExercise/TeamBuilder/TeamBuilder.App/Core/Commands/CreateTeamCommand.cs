namespace TeamBuilder.App.Core.Commands
{
    using TeamBuilder.App.Interfaces;
    using TeamBuilder.App.Repositories;
    using Utilities;

    public class CreateTeamCommand : IExecutable
    {
        //•	CreateTeam<name> <acronym> <description>
        public string Execute(string[] args)
        {
            AuthenticationManager.Authorize();
            string teamName = args[0];
            string acronym = args[1];
            string description = args.Length == 3 ? args[2] : null;

            Validator.ValidateCreateTeamCommand(args, teamName, acronym);


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
        }

    }
}