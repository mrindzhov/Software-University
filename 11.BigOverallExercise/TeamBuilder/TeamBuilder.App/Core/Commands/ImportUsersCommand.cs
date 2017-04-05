namespace TeamBuilder.App.Core.Commands
{
    using System;
    using System.Collections.Generic;
    using TeamBuilder.App.Interfaces;
    using TeamBuilder.App.Utilities;
    using TeamBuilder.Models;
    using TeamBulder.Services;

    public class ImportUsersCommand : IExecutable
    {
        private readonly UserService userService;
        public ImportUsersCommand() : this(new UserService())
        {
        }
        public ImportUsersCommand(UserService userService)
        {
            this.userService = userService;
        }
        //•	ImportUsers<filePathToXmlFile>
        //Import users from given xml file.
        public string Execute(string[] args)
        {
            Validator.ValidateLength(1, args);

            string filePath = args[0];
            Validator.ValidatePath(filePath);

            ICollection<User> users;

            try
            {
                users = DataLoader.GetUsersFromXML(filePath);
            }
            catch (Exception)
            {
                throw new FormatException(Constants.ErrorMessages.InvalidXmlFormat);
            }
            this.userService.AddUsers(users);

            return $"You have successfully imported {users.Count} users!";
        }
    }
}