namespace TeamBuilder.App.Core.Commands
{
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;
    using System.Xml.Linq;
    using TeamBuilder.App.Interfaces;
    using TeamBuilder.App.Utilities;
    using TeamBuilder.Data;
    using TeamBuilder.Data.Repositories;
    using TeamBuilder.Models;

    public class ImportTeamsCommand : IExecutable
    {
        public string Execute(string[] args)
        {
            Validator.CheckLength(1, args);

            string filePath = args[0];
            if (!File.Exists(filePath))
            {
                throw new FileNotFoundException(string.Format(Constants.ErrorMessages.FileNotFound, filePath));
            }
            ICollection<Team> teams;

            try
            {
                teams = this.GetTeamsFromXml(filePath);
            }
            catch (Exception)
            {
                throw new FormatException(Constants.ErrorMessages.InvalidXmlFormat);
            }
            this.AddTeams(teams);

            return $"You have successfully imported {teams.Count} teams!";
        }

        private void AddTeams(ICollection<Team> teams)
        {
            using (var uf = new UnitOfWork())
            {
                uf.Teams.AddRange(teams);
                uf.Commit();
            }
            //using (TeamBuilderContext ctx = new TeamBuilderContext())
            //{
            //    ctx.Teams.AddRange(teams);
            //    ctx.SaveChanges();
            //}
        }

        private ICollection<Team> GetTeamsFromXml(string filePath)
        {
            ICollection<Team> teams = new HashSet<Team>();

            //current path=>  "../../Import/users.xml"
            XDocument xmlData = XDocument.Load(filePath);

            xmlData.Root.Elements().ToList().ForEach(u =>
            {
                //                name > Fay - DuBuque </ name >
                //< acronym > OBJ </ acronym >
                //< description > Etiam pretium iaculis justo.</ description >

                //   < creator - id > 72 </ creator - id >
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
