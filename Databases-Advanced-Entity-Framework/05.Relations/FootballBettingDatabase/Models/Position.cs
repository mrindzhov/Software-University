﻿namespace Models
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    public class Position
    {
        public Position()
        {
            this.Players = new HashSet<Player>();
        }

        [Key]
        [MaxLength(2)]
        public string Id { get; set; }

        [Required]
        public string PositionDescription { get; set; }

        public virtual ICollection<Player> Players { get; set; }
    }
}
