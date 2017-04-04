namespace TeamBuilder.App.Core.Commands
{
    using System;
    using Utilities;
    using System.Linq;
    using Models;
    using TeamBuilder.App.Interfaces;
    using TeamBuilder.Data.Repositories;

    public class RegisterUserCommand : IExecutable
    {
        // •	RegisterUser <username> <password> <repeat-password> <firstName> <lastName> <age> <gender>
        public string Execute(string[] args)
        {
            Validator.CheckLength(7, args);
            //if (AuthenticationManager.IsAuthenticated())
            //{
            //    throw new InvalidOperationException(Constants.ErrorMessages.LogoutFirst);
            //}
            string username = args[0];

            if (username.Length > Constants.MaxUsernameLength || username.Length < Constants.MinUsernameLength)
            {
                throw new ArgumentException(string.Format(Constants.ErrorMessages.UsernameNotValid, username));
            }
            string password = args[1];

            if (!password.Any(char.IsDigit) || !password.Any(char.IsUpper))
            {
                throw new ArgumentException(string.Format(Constants.ErrorMessages.PasswordNotValid, password));
            }

            string repeatPassword = args[2];

            if (password != repeatPassword)
            {
                throw new ArgumentException(string.Format(Constants.ErrorMessages.PasswordDoesNotMatch));
            }

            string firstName = args[3];

            string lastName = args[4];
            int age;
            bool isNumber = int.TryParse(args[5], out age);

            if (!isNumber || age <= 0)
            {
                throw new ArgumentException(Constants.ErrorMessages.AgeNotValid);
            }

            Gender gender;
            bool isGenderValid = Enum.TryParse(args[6], out gender);
            if (!isGenderValid)
            {
                throw new ArgumentException(Constants.ErrorMessages.GenderNotValid);
            }
            if (CommandHelper.IsUserExisting(username))
            {
                throw new InvalidOperationException(string.Format(Constants.ErrorMessages.UsernameIsTaken, username));
            }
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

            //using (Data.TeamBuilderContext ctx = new Data.TeamBuilderContext())
            //{
            //    ctx.Users.Add(user);
            //    ctx.SaveChanges();
            //}
        }

    }
}