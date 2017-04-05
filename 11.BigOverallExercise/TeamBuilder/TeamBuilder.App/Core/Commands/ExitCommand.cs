namespace TeamBuilder.App.Core.Commands
{
    using System;
    using TeamBuilder.App.Interfaces;
    using Utilities;

    public class ExitCommand : IExecutable
    {
        public string Execute(string[] args)
        {
            Validator.ValidateLength(0, args);
            Console.WriteLine("Bye!");
            Environment.Exit(0);
            return string.Empty;
        }
    }
}
