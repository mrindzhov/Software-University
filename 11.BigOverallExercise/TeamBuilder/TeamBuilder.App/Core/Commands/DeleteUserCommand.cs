namespace TeamBuilder.App.Core.Commands
{
    using Utilities;
    using Models;
    using TeamBuilder.App.Interfaces;
    using TeamBulder.Services;

    public class DeleteUserCommand : IExecutable
    {
        private readonly UserService userService;
        public DeleteUserCommand() : this(new UserService())
        {
        }
        public DeleteUserCommand(UserService userService)
        {
            this.userService = userService;
        }

        public string Execute(string[] args)
        {
            Validator.ValidateLength(0, args);
            AuthenticationManager.Authorize();

            User user = AuthenticationManager.GetCurrentUser();

            this.userService.DeleteUser(user);

            AuthenticationManager.Logout();

            return $"User {user.Username} was deleted successfully!";
        }
    }
}
