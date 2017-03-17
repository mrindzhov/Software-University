namespace PhotoShare.Client.Core.Commands
{
    using System;

    using Models;
    using Client;
    using Services;

    public class RegisterUserCommand
    {
        private readonly UserService userservice;

        public RegisterUserCommand(UserService userservice)
        {
            this.userservice = userservice;
        }

        // RegisterUser <username> <password> <repeat-password> <email>
        public string Execute(string[] data)
        {
            string username = data[0];
            string password = data[1];
            string repeatPassword = data[2];
            string email = data[3];

            if (password != repeatPassword)
            {
                throw new ArgumentException("Passwords do not match!");
            }

           
            this.userservice.AddUser(username,password,email);
           
            return "User " + username + " was registered successfully!";
        }
    }
}
