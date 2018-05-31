namespace Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    public class Game
    {
        public Game()
        {
            this.PlayerStatisticses = new HashSet<PlayerStatistics>();
            this.BetGames = new HashSet<BetGame>();
        }

        public int Id { get; set; }

        public virtual Team HomeTeam { get; set; }

        public virtual Team AwayTeam { get; set; }

        [Range(0, int.MaxValue)]
        public int HomeGoals { get; set; }

        [Range(0, int.MaxValue)]
        public int AwayGoals { get; set; }

        public DateTime DateTimeOfGame { get; set; }

        [Range(0, double.MaxValue)]
        public double HomeTeamWinBetRate { get; set; }


        [Range(0, double.MaxValue)]
        public double AwayTeamWinBetRate { get; set; }


        [Range(0, double.MaxValue)]
        public double DrawBetRate { get; set; }

        public virtual Round Round { get; set; }

        public virtual Competition Competition { get; set; }

        public virtual ICollection<BetGame> BetGames { get; set; }

        public virtual ICollection<PlayerStatistics> PlayerStatisticses { get; set; }
    }
}
