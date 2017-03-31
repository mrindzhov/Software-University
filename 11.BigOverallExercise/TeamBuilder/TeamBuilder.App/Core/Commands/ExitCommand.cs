namespace TeamBuilder.App.Core.Commands
{
    using System;
    using Utilities;

    public class ExitCommand
    {
        public string Execute(string[] args)
        {
            Check.Length(0, args);
            Environment.Exit(0);
            return "Bye";
        }
    }
}
