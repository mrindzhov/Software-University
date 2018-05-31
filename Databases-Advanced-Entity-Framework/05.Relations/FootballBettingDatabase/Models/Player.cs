namespace Models
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    public class Player
    {
        public Player()
        {
            this.PlayerStatisticses = new HashSet<PlayerStatistics>();
        }

        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        public int SquadNumber { get; set; }

        public virtual Team Team { get; set; }

        public virtual Position Position { get; set; }

        public bool IsCurrentlyInjured { get; set; }

        public virtual ICollection<PlayerStatistics> PlayerStatisticses { get; set; }
    }
}
