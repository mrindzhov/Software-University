namespace PlanetHunters.Data.Utilities
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
            Console.WriteLine($"Record {output} successfully imported!");
            Console.ResetColor();
        }

        public static void PrintSuccessDiscovery(string output)
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine($"Discovery {output} successfully imported!");
            Console.ResetColor();
        }
    }
}
