namespace TeamBuilder.App.Core.Commands
{
    using Utilities;
    using Models;
    using TeamBuilder.App.Interfaces;
    using TeamBuilder.App.Repositories;

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
            using (var uf = new UnitOfWork())
            {
                uf.Users.GetById(u => u.Id == user.Id).IsDeleted = true;
                uf.Commit();
            }
        }
    }
}
