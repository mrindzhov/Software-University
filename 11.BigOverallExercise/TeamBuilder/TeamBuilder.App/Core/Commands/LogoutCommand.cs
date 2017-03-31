namespace TeamBuilder.App.Core.Commands
{
    using Models;
    using TeamBuilder.App.Utilities;

    public class LogoutCommand
    {
        public string Execute(string[] args)
        {
            Check.Length(0, args);
            AuthenticationManager.Authorize();

            User currentUser = AuthenticationManager.GetCurrentUser();

            AuthenticationManager.Logout();

            return $"User {currentUser.Username} successfully logged out!";
        }
    }
}
