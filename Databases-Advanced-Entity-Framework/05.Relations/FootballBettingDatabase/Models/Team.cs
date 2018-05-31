namespace Models
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    public class Team
    {
        public Team()
        {
            this.Players = new HashSet<Player>();
        }
        [Key]
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        public byte[] Logo { get; set; }

        [Required]
        [MaxLength(3)]
        public string ThreeLetterInitials { get; set; }

        [Required]
        public virtual Color PrimaryKitColor { get; set; }

        [Required]
        public virtual Color SecondaryKitColor { get; set; }

        public virtual Town Town { get; set; }

        public decimal Budget { get; set; }

        public virtual ICollection<Player> Players { get; set; }

    }
}