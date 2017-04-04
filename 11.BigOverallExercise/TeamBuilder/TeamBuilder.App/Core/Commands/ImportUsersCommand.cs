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

    public class ImportUsersCommand : IExecutable
    {
        //•	ImportUsers<filePathToXmlFile>
        //Import users from given xml file.
        public string Execute(string[] args)
        {
            Validator.CheckLength(1, args);

            string filePath = args[0];
            if (!File.Exists(filePath))
            {
                throw new FileNotFoundException(string.Format(Constants.ErrorMessages.FileNotFound, filePath));
            }
            ICollection<User> users;

            try
            {
                users = this.GetUsersFromXml(filePath);
            }
            catch (Exception)
            {
                throw new FormatException(Constants.ErrorMessages.InvalidXmlFormat);
            }
            this.AddUsers(users);

            return $"You have successfully imported {users.Count} users!";
        }

        private void AddUsers(ICollection<User> users)
        {
            using (var uf = new UnitOfWork())
            {
                uf.Users.AddRange(users);
                uf.Commit();
            }
        }

        private ICollection<User> GetUsersFromXml(string filePath)
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
                bool IsGender = Enum.TryParse(Validator.FirstLetterToUpper(u.Element("gender").Value), out gender);
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
    }
}