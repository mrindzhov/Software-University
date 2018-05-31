namespace TeamBulder.Services
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using TeamBuilder.App.Repositories;
    using TeamBuilder.Models;

    public class TeamService : IService
    {
        public void AddTeamToEvent(string teamName, string eventName)
        {
            using (var uf = new UnitOfWork())
            {
                Team team = uf.Teams.GetByName(t => t.Name == teamName);
                Event ev = uf.Events.Include("Creator").Where(e => e.Name == eventName).OrderByDescending(e => e.StartDate).First();

                if (ev.ParticipatingTeams.Any(t => t.Name == teamName) || team.ParticipatedEvents.Any(e => e.Id == ev.Id))
                {
                    throw new InvalidOperationException("Cannot add same team twice!");
                }
                ev.ParticipatingTeams.Add(team);
                team.ParticipatedEvents.Add(ev);
                uf.Commit();
            }
        }

        public Team GetTeamWithMembersByName(string teamName)
        {
            using (var uf = new UnitOfWork())
            {
                return uf.Teams.Include("Members").FirstOrDefault(t => t.Name == teamName);
            }
        }

        public void DisbandTeam(string teamName)
        {
            using (var uf = new UnitOfWork())
            {
                Team team = uf.Teams.FirstOrDefault(t => t.Name == teamName);
                uf.Teams.Delete(team);
                uf.Commit();
            }
        }

        public void AddTeams(ICollection<Team> teams)
        {
            using (var uf = new UnitOfWork())
            {
                uf.Teams.AddRange(teams);
                uf.Commit();
            }
        }

        public string LoadTeamAndMembers(string teamName)
        {
            StringBuilder sb = new StringBuilder();
            using (var uf = new UnitOfWork())
            {
                Team team = uf.Teams.GetByName(t => t.Name == teamName);
                sb.AppendLine($"{team.Name} {team.Acronym}");

                sb.AppendLine($"Members: {team.Members.Count()}");
                foreach (var member in team.Members)
                {
                    sb.AppendLine($"--{member.Username}");
                }
            }
            return sb.ToString().Trim();
        }

        public void AddTeam(string teamName, string acronym, string description, int creatorId)
        {
            using (var uf = new UnitOfWork())
            {
                uf.Teams.Add(new Team
                {
                    Name = teamName,
                    Acronym = acronym,
                    Description = description,
                    CreatorId = creatorId
                });
                uf.Commit();
            }
        }
    }
}
