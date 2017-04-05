﻿namespace TeamBuilder.App.Core.Commands
{
    using System;
    using System.Linq;
    using System.Text;
    using Models;
    using TeamBuilder.App.Interfaces;
    using TeamBuilder.App.Repositories;
    using Utilities;

    public class ShowEventCommand : IExecutable
    {
        public string Execute(string[] args)
        {
            Validator.ValidateLength(1, args);

            string eventName = args[0];

            Validator.ValidateShowEventCommand(eventName);

            return this.LoadEvent(eventName);
        }
        

        private string LoadEvent(string eventName)
        {
            StringBuilder sb = new StringBuilder();
            using (var uf = new UnitOfWork())
            {
                Event ev = uf.Events.Include("ParticipatingTeams").OrderByDescending(e => e.StartDate)
                    .FirstOrDefault(e => e.Name == eventName);
                sb.AppendLine($"{ev.Name} {ev.StartDate} {ev.EndDate} {ev.Description}");
                sb.AppendLine($"Teams: {ev.ParticipatingTeams.Count()}");
                foreach (var team in ev.ParticipatingTeams)
                {
                    sb.AppendLine($"--{team.Name}, Members: {team.Members.Count}");
                    foreach (var member in team.Members)
                    {
                        sb.AppendLine($"----{member.Username} {member.Age}");
                    }
                }
            }
            return sb.ToString().Trim();
        }
    }
}
