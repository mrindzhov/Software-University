using System.Collections.Generic;
using System.Linq;
using Wintellect.PowerCollections;

public class Scoreboard : IScoreboard
{
    //SortedDictionary<string, Game> games;
    //Dictionary<string, User> users;
    private Dictionary<string, string> Users;
    private SortedDictionary<string, string> Games;
    private Dictionary<string, OrderedBag<ScoreboardEntry>> GameResults;
    private int entriesCount;
    public Scoreboard(int maxEntriesToKeep = 10)
    {
        this.entriesCount = maxEntriesToKeep;
        this.Users = new Dictionary<string, string>();
        this.Games = new SortedDictionary<string, string>();
        this.GameResults = new Dictionary<string, OrderedBag<ScoreboardEntry>>();
    }

    public bool RegisterUser(string username, string password)
    {
        if (this.Users.ContainsKey(username))
        {
            return false;
        }
        this.Users.Add(username, password);
        return true;
    }

    public bool RegisterGame(string game, string password)
    {
        if (this.Games.ContainsKey(game))
        {
            return false;
        }
        this.Games.Add(game, password);
        this.GameResults.Add(game, new OrderedBag<ScoreboardEntry>());
        return true;
    }

    public bool AddScore(string username, string userPassword, string gameName, string gamePassword, int score)
    {
        if (!this.Games.ContainsKey(gameName) || this.Games[gameName] != gamePassword ||
            !this.Users.ContainsKey(username) || this.Users[username] != userPassword)
        {
            return false;
        }
        ScoreboardEntry sbe = new ScoreboardEntry(score, username);
        GameResults[gameName].Add(sbe);
        return true;
    }

    public IEnumerable<ScoreboardEntry> ShowScoreboard(string game)
    {
        if (!this.Games.ContainsKey(game))
        {
            return null;
        }
        return this.GameResults[game].Take(entriesCount);
    }

    public bool DeleteGame(string gameName, string gamePassword)
    {
        if (!this.Games.ContainsKey(gameName) || this.Games[gameName] != gamePassword)
        {
            return false;
        }
        this.Games.Remove(gameName);
        this.GameResults.Remove(gameName);
        return true;
    }

    public IEnumerable<string> ListGamesByPrefix(string gameNamePrefix)
    {
        return this.Games
            .Where(g => g.Key.StartsWith(gameNamePrefix))
            .Take(entriesCount).Select(g => g.Key);
    }
}