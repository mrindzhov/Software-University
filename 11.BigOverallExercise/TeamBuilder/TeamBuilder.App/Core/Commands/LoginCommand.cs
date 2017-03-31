namespace TeamBuilder.App.Core.Commands
{
    using System;
    using System.Linq;
    using Data;
    using TeamBuilder.Models;
    using Utilities;
    public class LoginCommand
    {
        public string Execute(string[] args)
        {
            Check.CheckLength(2, args);
            string username = args[0];
            string password = args[1];
            if (AuthenticationManager.IsAuthenticated())
            {
                throw new InvalidOperationException(Constants.ErrorMessages.LogoutFirst);
            }
            User user = this.GetUserByCredentials(username, password);

            if (user == null)
            {
                throw new ArgumentException(Constants.ErrorMessages.UserOrPasswordIsInvalid);
            }
            AuthenticationManager.LoginUser(user);

            return $"User {user.Username} successfully logged in!";

        }

        private User GetUserByCredentials(string username, string password)
        {
            using (TeamBuilderContext ctx = new TeamBuilderContext())
            {
                return ctx.Users.FirstOrDefault(u => u.Username == username && u.Password == password && u.IsDeleted == false);
            }
        }
    }
}
