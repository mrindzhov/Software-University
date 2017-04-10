namespace PlanetHunters.Models
{
    using System.ComponentModel.DataAnnotations;
    public class Star
    {
        public int Id { get; set; }
        [Required, StringLength(255)]
        public string Name { get; set; }
        //•	Temperature – effective temperature in Kelvin, integer (required). Cannot be lower than 2400K.
        [Required, Range(2400, double.MaxValue, ErrorMessage = "Temperature should be higher than 2400K!")]
        public int TemperatureInKelvin { get; set; }

        [Required]
        public int HostStarSystemId { get; set; }
        public virtual StarSystem HostStarSystem { get; set; }

        public int? DiscoveryId { get; set; }

        public virtual Discovery Discovery { get; set; }

    }
}