namespace TeamBuilder.App.Core.Commands
{
    using TeamBuilder.App.Interfaces;
    using TeamBulder.Services;
    using Utilities;

    public class ShowEventCommand : IExecutable
    {
        private readonly EventService eventService;
        public ShowEventCommand() : this(new EventService())
        {
        }
        public ShowEventCommand(EventService eventService)
        {
            this.eventService = eventService;
        }
        public string Execute(string[] args)
        {
            Validator.ValidateLength(1, args);

            string eventName = args[0];

            Validator.ValidateShowEventCommand(eventName);

            return this.eventService.LoadEvent(eventName);
        }
    }
}
