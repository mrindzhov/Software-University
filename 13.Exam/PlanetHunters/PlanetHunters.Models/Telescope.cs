namespace PlanetHunters.Models
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    public class Telescope
    {
        public Telescope()
        {
            this.DiscoveriesMade = new HashSet<Discovery>();
        }
        public int Id { get; set; }
        [Required, StringLength(255)]
        public string Name { get; set; }
        [Required, StringLength(255)]
        public string Location { get; set; }
        [Required, Range(0.00001, double.MaxValue, ErrorMessage = "MirrorDiameter should be more than 0!")]
        public double MirrorDiameter { get; set; }

        public ICollection<Discovery> DiscoveriesMade { get; set; }
    }
}