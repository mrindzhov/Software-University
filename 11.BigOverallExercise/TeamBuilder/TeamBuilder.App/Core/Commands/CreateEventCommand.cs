namespace TeamBuilder.App.Core.Commands
{
    using System;
    using System.Globalization;
    using Utilities;
    using TeamBuilder.App.Interfaces;
    using TeamBulder.Services;

    public class CreateEventCommand : IExecutable
    {
        private readonly EventService eventService;
        public CreateEventCommand() : this(new EventService())
        {
        }
        public CreateEventCommand(EventService eventService)
        {
            this.eventService = eventService;
        }

        //•	CreateEvent<name> <description> <startDate> <endDate>
        public string Execute(string[] args)
        {
            Validator.ValidateLength(6, args);
            AuthenticationManager.Authorize();

            string name = args[0];
            string description = args[1];
            DateTime startDate;
            DateTime endDate;

            bool IsStartDate = DateTime.TryParseExact(args[2] + " " + args[3],
                Constants.DateTimeFormat,
                CultureInfo.InvariantCulture,
                DateTimeStyles.None, out startDate);

            bool IsEndDate = DateTime.TryParseExact(args[4] + " " + args[5],
                Constants.DateTimeFormat,
                CultureInfo.InvariantCulture,
                DateTimeStyles.None, out endDate);

            Validator.ValidateCreateEventCommand(startDate, endDate, IsStartDate, IsEndDate);
            this.eventService.CreateEvent(name, description, startDate, endDate, AuthenticationManager.GetCurrentUser().Id);

            return $"Event {name} successfully created!";

        }
    }
}
