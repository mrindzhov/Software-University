namespace PlanetHunters.Models
{
    using System.ComponentModel.DataAnnotations;
    public class Planet
    {
        public int Id { get; set; }
        [Required, StringLength(255)]
        public string Name { get; set; }
        [Required, Range(0.00001, double.MaxValue, ErrorMessage = "Mass should be more than 0!")]
        public double Mass { get; set; }

        [Required]
        public int HostStarSystemId { get; set; }
        public virtual StarSystem HostStarSystem { get; set; }
        public int? DiscoveryId { get; set; }

        public virtual Discovery Discovery { get; set; }
    }
}