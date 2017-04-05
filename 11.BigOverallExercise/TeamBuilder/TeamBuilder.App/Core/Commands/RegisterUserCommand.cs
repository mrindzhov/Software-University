namespace TeamBuilder.App.Core.Commands
{
    using System;
    using Utilities;
    using Models;
    using TeamBuilder.App.Interfaces;
    using TeamBulder.Services;

    public class RegisterUserCommand : IExecutable
    {
        private readonly UserService userService;
        public RegisterUserCommand() : this(new UserService())
        {

        }
        public RegisterUserCommand(UserService userService)
        {
            this.userService = userService;
        }
        // •	RegisterUser <username> <password> <repeat-password> <firstName> <lastName> <age> <gender>
        public string Execute(string[] args)
        {
            Validator.ValidateLength(7, args);
            string username = args[0];
            string password = args[1];
            string repeatPassword = args[2];
            string firstName = args[3];
            string lastName = args[4];
            int age;
            Gender gender;
            bool IsAgeNumber = int.TryParse(args[5], out age);
            bool isGenderValid = Enum.TryParse(Modifier.FirstLetterToUpper(args[6]), out gender);

            Validator.ValidateRegisterUserCommand(
                username, password, repeatPassword, age, IsAgeNumber, isGenderValid);

            User u = new User
            {
                Username = username,
                Password = password,
                FirstName = firstName,
                LastName = lastName,
                Age = age,
                Gender = gender
            };
            this.userService.RegisterUser(u);
            // AuthenticationManager.LoginUser(u);

            return $"User {username} successfully registered!";
        }
    }
}