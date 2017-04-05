namespace TeamBulder.Services
{
    using System;
    using System.Linq;
    using System.Text;
    using TeamBuilder.App.Repositories;
    using TeamBuilder.Models;

    public class EventService : IService
    {
        public void CreateEvent(string name, string description, DateTime startDate, DateTime endDate, int creatorId)
        {
            using (var uf = new UnitOfWork())
            {
                uf.Events.Add(new Event
                {
                    Name = name,
                    Description = description,
                    StartDate = startDate,
                    EndDate = endDate,
                    CreatorId = creatorId
                });
                uf.Commit();
            }
        }

        public string LoadEvent(string eventName)
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
