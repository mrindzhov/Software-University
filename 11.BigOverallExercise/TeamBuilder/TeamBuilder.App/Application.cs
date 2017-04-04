namespace TeamBuilder.App
{
    using Core;
    using TeamBuilder.App.Repositories;

    class Application
    {
        static void Main(string[] args)
        {
            new UnitOfWork();
            //new Data.TeamBuilderContext().Database.Initialize(true);
            Engine engine = new Engine(new CommandDispatcher());
            engine.Run();

        }
    }
}
