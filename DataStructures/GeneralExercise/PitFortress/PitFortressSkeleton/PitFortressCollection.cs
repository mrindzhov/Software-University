using System;
using System.Collections.Generic;
using System.Linq;
using Classes;
using Interfaces;
using Wintellect.PowerCollections;

public class PitFortressCollection : IPitFortress
{
    private int mineId = 1;
    private int minionId = 1;
    //player
    Dictionary<string, Player> players;
    SortedSet<Player> playersScores;
    //minion
    OrderedDictionary<int, OrderedSet<Minion>> minions;
    //mine
    SortedSet<Mine> mines;

    public PitFortressCollection()
    {
        this.players = new Dictionary<string, Player>();
        this.playersScores = new SortedSet<Player>();
        this.minions = new OrderedDictionary<int, OrderedSet<Minion>>();
        this.mines = new SortedSet<Mine>();
    }

    public int PlayersCount { get { return players.Count; } }

    public int MinionsCount { get { return this.minions.Sum(x => x.Value.Count); } }

    public int MinesCount { get { return this.mines.Count; } }

    public void AddPlayer(string name, int mineRadius)
    {
        if (this.players.ContainsKey(name) || mineRadius < 0)
        {
            throw new ArgumentException();
        }
        Player player = new Player(name, mineRadius);
        this.players.Add(name, player);
        this.playersScores.Add(player);
    }

    public void AddMinion(int xCoordinate)
    {
        this.ValidateValue(xCoordinate, 1_000_000);
        Minion minion = new Minion(this.minionId++, xCoordinate);
        if (!this.minions.ContainsKey(xCoordinate))
        {
            this.minions.Add(xCoordinate, new OrderedSet<Minion>());
        }
        this.minions[xCoordinate].Add(minion);
    }

    public void SetMine(string playerName, int xCoordinate, int delay, int damage)
    {
        this.DoesPlayerExist(playerName);
        this.ValidateValue(xCoordinate, 1_000_000);
        this.ValidateValue(delay, 10_000);
        this.ValidateValue(damage, 100);
        var player = this.players[playerName];
        var mine = new Mine(this.mineId++, player, xCoordinate, delay, damage);
        this.mines.Add(mine);
    }

    private void ValidateValue(int val, int maxVal)
    {
        if (val < 0 || val > maxVal)
        {
            throw new ArgumentException();
        }
    }

    private void DoesPlayerExist(string playerName)
    {
        if (!this.players.ContainsKey(playerName))
        {
            throw new ArgumentException();
        }
    }

    public IEnumerable<Minion> ReportMinions()
    {
        foreach (var set in this.minions.Values)
        {
            foreach (var minion in set)
            {
                yield return minion;
            }
        }
    }

    public IEnumerable<Player> Top3PlayersByScore()
    {
        if (this.players.Count < 3)
        {
            throw new ArgumentException();
        }
        return this.playersScores.Reverse().Take(3);
    }

    public IEnumerable<Player> Min3PlayersByScore()
    {
        if (this.players.Count < 3)
        {
            throw new ArgumentException();
        }
        return this.playersScores.Take(3);
    }

    public IEnumerable<Mine> GetMines()
    {
        return this.mines;
    }

    public void PlayTurn()
    {
        List<Mine> toDetonate = GetMinesForDetonation();
        foreach (var mine in toDetonate)
        {
            UpdateMine(mine);
        }
        RemoveMines(toDetonate);
    }

    private void UpdateMine(Mine mine)
    {
        var player = mine.Player;
        List<Minion> minionsToUpdate = GetMinionsForUpdate(mine);
        foreach (var minion in minionsToUpdate)
        {
            UpdateMinion(mine, player, minion);
        }
    }

    private void UpdateMinion(Mine mine, Player player, Minion minion)
    {
        minion.Health -= mine.Damage;
        if (minion.Health <= 0)
        {
            this.playersScores.Remove(player);
            mine.Player.Score++;
            this.playersScores.Add(player);
            this.minions[minion.XCoordinate].Remove(minion);
        }
    }

    private List<Minion> GetMinionsForUpdate(Mine mine)
    {
        var start = mine.XCoordinate - mine.Player.Radius;
        var end = mine.XCoordinate + mine.Player.Radius;
        var minionsToUpdate = this.minions.Range(start, true, end, true)
           .SelectMany(x => x.Value).ToList();
        return minionsToUpdate;
    }

    private void RemoveMines(List<Mine> toDetonate)
    {
        foreach (var mine in toDetonate)
        {
            this.mines.Remove(mine);
        }
    }

    private List<Mine> GetMinesForDetonation()
    {
        var toDetonate = new List<Mine>();
        foreach (var mine in this.mines)
        {
            mine.Delay--;
            if (mine.Delay <= 0)
            {
                toDetonate.Add(mine);
            }
        }

        return toDetonate;
    }
}
