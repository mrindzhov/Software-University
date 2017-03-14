namespace Models
{
    using System;
    using System.Collections.Generic;

    public class Bet
    {
        public Bet()
        {
            this.BetGames = new HashSet<BetGame>();
        }
        public int Id { get; set; }

        public decimal BetMoney { get; set; }

        public DateTime DateOfBet { get; set; }

        public virtual User User { get; set; }

        public virtual ICollection<BetGame> BetGames { get; set; }

    }
}
