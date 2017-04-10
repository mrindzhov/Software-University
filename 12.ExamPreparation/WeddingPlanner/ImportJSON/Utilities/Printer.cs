namespace ImportJSON.Utilities
{
    using System;

    public static class Printer
    {
        public static void PrintError()
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine($"Error. Invalid Data provided!");
            Console.ResetColor();
        }

        public static void PrintSuccess(string output)
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine($"Succesfully imported {output}");
            Console.ResetColor();
        }

        public static void PrintSuccessWedding(string bride, string bridegroom)
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine($"Succesfully imported wedding of {bride} and {bridegroom}");
            Console.ResetColor();
        }
    }
}
