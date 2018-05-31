namespace Models
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    public class Competition
    {
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        public virtual CompetitionType Type { get; set; }

        public virtual ICollection<Game> Games { get; set; }

    }
}