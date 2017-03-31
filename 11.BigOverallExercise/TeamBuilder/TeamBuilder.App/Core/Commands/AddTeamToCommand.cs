namespace TeamBuilder.App.Core.Commands
{
    using System;
    using System.Linq;
    using Data;
    using Models;
    using Utilities;

    public class AddTeamToCommand
    {
        public string Execute(string[] inputArgs)
        {
            Check.Length(2, inputArgs);
            AuthenticationManager.Authorize();
            string eventName = inputArgs[0];
            if (!CommandHelper.IsEventExisting(eventName))
            {
                throw new ArgumentException(string.Format(Constants.ErrorMessages.EventNotFound, eventName));
            }

            string teamName = inputArgs[1];

            if (!CommandHelper.IsTeamExisting(teamName))
            {
                throw new ArgumentException(string.Format(Constants.ErrorMessages.TeamNotFound, teamName));
            }
            if (!CommandHelper.IsUserCreatorOfEvent(eventName, AuthenticationManager.GetCurrentUser().Id))
            {
                throw new InvalidOperationException(string.Format(Constants.ErrorMessages.NotAllowed));
            }

            this.AddTeamToEvent(teamName, eventName);

            return $"Team {teamName} added to {eventName}!";
        }

        private void AddTeamToEvent(string teamName, string eventName)
        {
            using (TeamBuilderContext context = new TeamBuilderContext())
            {
                Team team = context.Teams.FirstOrDefault(t => t.Name == teamName);
                Event ev = context.Events.Where(e => e.Name == eventName).OrderByDescending(e => e.StartDate).First();

                if (ev.ParticipatingTeams.Any(t => t.Name == teamName) || team.ParticipatedEvents.Any(e => e.Id == ev.Id))
                {
                    throw new InvalidOperationException(Constants.ErrorMessages.CannotAddSameTeamTwice);
                }

                ev.ParticipatingTeams.Add(team);
                team.ParticipatedEvents.Add(ev);
                context.SaveChanges();
            }
        }
    }
}