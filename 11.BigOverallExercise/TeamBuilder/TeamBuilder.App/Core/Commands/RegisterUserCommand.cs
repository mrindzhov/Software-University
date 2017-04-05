namespace TeamBuilder.App.Core.Commands
{
    using System;
    using Utilities;
    using System.Linq;
    using Models;
    using TeamBuilder.App.Interfaces;
    using TeamBuilder.App.Repositories;

    public class RegisterUserCommand : IExecutable
    {
        // •	RegisterUser <username> <password> <repeat-password> <firstName> <lastName> <age> <gender>
        public string Execute(string[] args)
        {
            Validator.ValidateLength(7, args);
            //if (AuthenticationManager.IsAuthenticated())
            //{
            //    throw new InvalidOperationException(Constants.ErrorMessages.LogoutFirst);
            //}
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

            this.RegisterUser(u);
            // AuthenticationManager.LoginUser(u);

            return $"User {username} successfully registered!";
        }
        
        private void RegisterUser(User user)
        {
            using (var uf = new UnitOfWork())
            {
                uf.Users.Add(user);
                uf.Commit();
            }
        }

    }
}