namespace TeamBuilder.App.Core
{
    using System;

    public class Engine
    {
        private CommandDispatcher commandDispatcher;

        public Engine(CommandDispatcher commandDispatcher)
        {
            this.commandDispatcher = commandDispatcher;
        }
        public void Run()
        {
            while (true)
            {
                try
                {
                    string input = Console.ReadLine();
                    string output = this.commandDispatcher.Dispatch(input);
                    Print(output, ConsoleColor.Green);
                }
                catch (Exception e)
                {
                    Print(e.GetBaseException().Message, ConsoleColor.Red);
                }
            }
        }

        private void Print(string output, ConsoleColor color)
        {
            Console.ForegroundColor = color;
            Console.WriteLine(output);
            Console.ResetColor();
        }

    }
}
