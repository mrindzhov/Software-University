namespace TeamBuilder.App.Core.Commands
{
    using System;
    using System.Globalization;
    using Utilities;
    using Models;
    using TeamBuilder.App.Interfaces;
    using TeamBuilder.Data.Repositories;

    public class CreateEventCommand : IExecutable
    {
        //•	CreateEvent<name> <description> <startDate> <endDate>
        public string Execute(string[] args)
        {
            Validator.CheckLength(6, args);
            AuthenticationManager.Authorize();

            string name = args[0];
            string description = args[1];

            DateTime startDate;

            bool IsStartDate = DateTime.TryParseExact(args[2] + " " + args[3],
                Constants.DateTimeFormat,
                CultureInfo.InvariantCulture,
                DateTimeStyles.None, out startDate);

            DateTime endDate;

            bool IsEndDate = DateTime.TryParseExact(args[4] + " " + args[5],
                Constants.DateTimeFormat,
                CultureInfo.InvariantCulture,
                DateTimeStyles.None, out endDate);

            if (!IsEndDate || !IsStartDate)
            {
                throw new ArgumentException(Constants.ErrorMessages.InvalidDateFormat);
            }
            if (startDate > endDate)
            {
                throw new ArgumentException("Start date should be before end date.");
            }

            this.CreateEvent(name, description, startDate, endDate);


            return $"Event {name} successfully created!";

        }

        private void CreateEvent(string name, string description, DateTime startDate, DateTime endDate)
        {
            using (var uf = new UnitOfWork())
            {
                uf.Events.Add(new Event
                {
                    Name = name,
                    Description = description,
                    StartDate = startDate,
                    EndDate = endDate,
                    CreatorId = AuthenticationManager.GetCurrentUser().Id
                });
                uf.Commit();
            }

            //using (TeamBuilderContext ctx = new TeamBuilderContext())
            //{
            //    ctx.Events.Add(new Event
            //    {
            //        Name = name,
            //        Description = description,
            //        StartDate = startDate,
            //        EndDate = endDate,
            //        CreatorId = AuthenticationManager.GetCurrentUser().Id
            //    });
            //    ctx.SaveChanges();
            //}
        }
    }
}
