namespace TeamBuilder.App.Core.Commands
{
    using System;
    using TeamBuilder.App.Interfaces;
    using TeamBuilder.Models;
    using TeamBulder.Services;
    using Utilities;
    public class LoginCommand : IExecutable
    {
        private readonly UserService userService;
        public LoginCommand() : this(new UserService())
        {
        }
        public LoginCommand(UserService userService)
        {
            this.userService = userService;
        }
        public string Execute(string[] args)
        {
            Validator.ValidateLength(2, args);
            string username = args[0];
            string password = args[1];
            Validator.ValidateLogin();
            User user = this.userService.GetUserByCredentials(username, password);
            if (user == null)
            {
                throw new ArgumentException(Constants.ErrorMessages.UserOrPasswordIsInvalid);
            }
            AuthenticationManager.LoginUser(user);

            return $"User {user.Username} successfully logged in!";

        }
    }
}
