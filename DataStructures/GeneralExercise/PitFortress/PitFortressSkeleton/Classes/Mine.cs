namespace Classes
{
    using System;
    using Interfaces;

    public class Mine : IMine
    {
        public Mine(int id, Player player, int coord, int delay, int damage)
        {
            this.Id = id;
            this.Player = player;
            this.XCoordinate = coord;
            this.Delay = delay;
            this.Damage = damage;
        }

        public int CompareTo(Mine other)
        {
            int cmp = this.Delay.CompareTo(other.Delay);
            if (cmp == 0)
            {
                cmp = this.Id.CompareTo(other.Id);
            }
            return cmp;
        }

        public int Id { get; private set; }

        public int Delay { get; set; }

        public int Damage { get; private set; }

        public int XCoordinate { get; private set; }

        public Player Player { get; private set; }

        public override string ToString()
        {
            return $"Id: {Id} Player: {Player} Radius: {Player.Radius}";
        }

    }
}