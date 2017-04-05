namespace TeamBuilder.App.Utilities
{
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;
    using System.Xml.Linq;
    using Newtonsoft.Json;
    using TeamBuilder.Models;

    internal static class DataLoader
    {
        public static ICollection<User> GetUsersFromXML(string filePath)
        {
            ICollection<User> users = new HashSet<User>();
            //current path=>  "../../Import/users.xml"
            XDocument xmlData = XDocument.Load(filePath);

            xmlData.Root.Elements().ToList().ForEach(u =>
            {
                string username = u.Element("username")?.Value;
                string password = u.Element("password")?.Value;
                string firstName = u.Element("first-name")?.Value;
                string lastName = u.Element("last-name")?.Value;
                int age = Convert.ToInt32(u.Element("age").Value);
                Gender gender;
                bool IsGender = Enum.TryParse(Modifier.FirstLetterToUpper(u.Element("gender").Value), out gender);
                users.Add(new User
                {
                    Username = username,
                    Password = password,
                    FirstName = firstName,
                    LastName = lastName,
                    Age = age,
                    Gender = gender
                });
            });

            return users;
        }

        internal static string ExportTeam(Team team)
        {
            string path = "../../Export";
            string json = JsonConvert.SerializeObject(new
            {
                Name = team.Name,
                Acronym = team.Acronym,
                Members = team.Members.Select(m => m.Username)
            }, Formatting.Indented);
            File.WriteAllText(path + "/team.json", json);
            return path;
        }

        public static ICollection<Team> GetTeamsFromXML(string filePath)
        {
            ICollection<Team> teams = new HashSet<Team>();

            //current path=>  "../../Import/users.xml"
            XDocument xmlData = XDocument.Load(filePath);

            xmlData.Root.Elements().ToList().ForEach(u =>
            {
                string name = u.Element("name").Value;
                string acronym = u.Element("acronym").Value;
                string description = u.Element("description").Value;
                int creatorId = int.Parse(u.Element("creator-id").Value);
                teams.Add(new Team
                {
                    Name = name,
                    Acronym = acronym,
                    Description = description,
                    CreatorId = creatorId
                });
            });

            return teams;
        }
    }
}
