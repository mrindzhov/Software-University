using System;

public class ScoreboardEntry : IComparable<ScoreboardEntry>
{
    public ScoreboardEntry(int score, string username)
    {
        this.Score = score;
        this.Username = username;
    }
    public int CompareTo(ScoreboardEntry other)
    {
        int cmp = other.Score.CompareTo(this.Score);
        if (cmp == 0)
        {
            cmp = this.Username.CompareTo(other.Username);
        }
        return cmp;
    }

    public int Score { get; set; }

    public string Username { get; set; }
}