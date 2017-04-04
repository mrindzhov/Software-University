namespace TeamBuilder.App.Core.Commands
{
    using System;
    using System.Linq;
    using Models;
    using TeamBuilder.App.Interfaces;
    using TeamBuilder.App.Repositories;
    using Utilities;

    public class AddTeamToCommand : IExecutable
    {
        public string Execute(string[] inputArgs)
        {
            Validator.CheckLength(2, inputArgs);
            AuthenticationManager.Authorize();
            string eventName = inputArgs[0];
            string teamName = inputArgs[1];
            Validator.ValidateAddTeamToEvent(eventName, teamName, AuthenticationManager.GetCurrentUser().Id);
            this.AddTeamToEvent(teamName, eventName);

            return $"Team {teamName} added to {eventName}!";
        }
       
        private void AddTeamToEvent(string teamName, string eventName)
        {
            using (var uf = new UnitOfWork())
            {
                Team team = uf.Teams.GetByName(t => t.Name == teamName);
                Event ev = uf.Events.Include("Creator").Where(e => e.Name == eventName).OrderByDescending(e => e.StartDate).First();

                if (ev.ParticipatingTeams.Any(t => t.Name == teamName) || team.ParticipatedEvents.Any(e => e.Id == ev.Id))
                {
                    throw new InvalidOperationException(Constants.ErrorMessages.CannotAddSameTeamTwice);
                }

                ev.ParticipatingTeams.Add(team);
                team.ParticipatedEvents.Add(ev);
                uf.Commit();
            }
        }
    }
}