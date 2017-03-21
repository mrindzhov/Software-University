namespace PhotoShare.Client.Core.Commands
{
    using System;

    public class ExitCommand
    {
        public void Execute()
        {
            if (AuthenticationManager.IsAuthenticated())
            {
                AuthenticationManager.Logout();
            }
            Console.WriteLine("Good bye!");
            Environment.Exit(0);
        }
    }
}
