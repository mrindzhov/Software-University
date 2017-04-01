namespace TeamBuilder.App.Core.Commands
{
    using System.Linq;
    using Utilities;
    using Data;
    using Models;
    using TeamBuilder.App.Interfaces;

    public class DeleteUserCommand : IExecutable
    {
        public string Execute(string[] args)
        {
            Validator.CheckLength(0, args);
            AuthenticationManager.Authorize();

            User user = AuthenticationManager.GetCurrentUser();

            DeleteUser(user);

            AuthenticationManager.Logout();

            return $"User {user.Username} was deleted successfully!";
        }

        private static void DeleteUser(User user)
        {
            using (TeamBuilderContext ctx = new TeamBuilderContext())
            {
                ctx.Users.SingleOrDefault(u => u.Id == user.Id).IsDeleted = true;
                ctx.SaveChanges();
            }
        }
    }
}
