namespace PhotoShare.Client.Core.Commands
{
    using System;
    using System.Linq;
    using Services;

    public class DeleteUser
    {
        private readonly UserService userService;

        public DeleteUser(UserService userService)
        {
            this.userService = userService;
        }

        // DeleteUser <username>
        public string Execute(string[] data)
        {
            string username = data[0];
            if (!this.userService.IsUsernameExisting(username))
            {
                throw new InvalidOperationException($"User with {username} was not found!");
            }

            if (this.userService.IsDeleted(username))
            {
                throw new InvalidOperationException($"User with {username} is already deleted!");
            }
            this.userService.deleteUser(username);

            return $"User {username} was deleted successfully!";
        }
    }
}
