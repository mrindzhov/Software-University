namespace Client
{
    using Data;
    using System;

    class StartUp
    {
        static void Main(string[] args)
        {
            try
            {
                FootballBettingContext ctx = new FootballBettingContext();
                ctx.Database.Initialize(true);
            }
            catch (Exception e )
            {
                Console.WriteLine(e.Message);
            }
        }
    }
}
