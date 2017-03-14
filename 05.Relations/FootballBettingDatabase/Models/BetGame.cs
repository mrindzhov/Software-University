namespace Models
{
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    public class BetGame
    {
        [Key]
        [ForeignKey("Game")]
        [Column(Order = 0)]
        public int GameId { get; set; }
        [Key]
        [ForeignKey("Bet")]
        [Column(Order = 1)]
        public int BetId { get; set; }
        
        public virtual Game Game { get; set; }
        
        public virtual Bet Bet { get; set; }

        public virtual ResultPrediction ResultPrediction { get; set; }

    }
}
