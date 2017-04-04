namespace TeamBuilder.App
{
    using Core;
    using TeamBuilder.Data.Repositories;

    class Application
    {
        static void Main(string[] args)
        {
            var uf = new UnitOfWork();
            //new Data.TeamBuilderContext().Database.Initialize(true);
            Engine engine = new Engine(new CommandDispatcher());
            engine.Run();

        }
    }
}
