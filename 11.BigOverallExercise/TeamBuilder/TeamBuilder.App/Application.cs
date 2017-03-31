namespace TeamBuilder.App
{
    using Core;
    class Application
    {
        static void Main(string[] args)
        {
            new Data.TeamBuilderContext().Database.Initialize(true);
            Engine engine = new Engine(new CommandDispatcher());
            engine.Run();
            //TODO : there is duplicate code in both accept and decline classes that should be removed
        }
    }
}
