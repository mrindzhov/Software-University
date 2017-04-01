namespace TeamBuilder.App.Core.Commands
{
    using Models;
    using TeamBuilder.App.Interfaces;
    using TeamBuilder.App.Utilities;

    public class LogoutCommand : IExecutable
    {
        public string Execute(string[] args)
        {
            Validator.CheckLength(0, args);
            AuthenticationManager.Authorize();

            User currentUser = AuthenticationManager.GetCurrentUser();

            AuthenticationManager.Logout();

            return $"User {currentUser.Username} successfully logged out!";
        }
    }
}
