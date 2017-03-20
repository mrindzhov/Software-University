namespace PhotoShare.Client.Core.Commands
{
    using System;
    using Services;
    using System.Linq;

    public class LoginUserCommand
    {
        private UserService userService;

        public LoginUserCommand(UserService userService)
        {
            this.userService = userService;
        }

        public string Execute(string[] data)
        {
            string username = data[0];
            string password = data[1];
            //!password.Any(c => char.IsLower(c)) && password.Any(c => char.IsDigit(c)))
            if (!this.userService.HasUser(username, password))
            {
                throw new ArgumentException("Invalid username or password!");
            }
            AuthenticationManager.Login(this.userService.GetUserByUsername(username));

            return $"User {username} logged in!";
        }
    }
}
