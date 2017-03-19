namespace PhotoShare.Client.Core.Commands
{
    using Services;
    using System;

    public class AddTownCommand
    {
        private readonly TownService townService;

        public AddTownCommand(TownService townService)
        {
            this.townService = townService;
        }

        // AddTown <townName> <countryName>
        public string Execute(string[] data)
        {
            string townName = data[0];
            string country = data[1];
            if (this.townService.IsTownExisting(townName))
            {
                throw new ArgumentException($"Town {townName} is already added!");
            }

            this.townService.AddTown(townName, country);


            return townName + " was added to database!";
        }
    }
}