namespace Models
{
    public enum Prediction
    {
        HomeTeamWin, DrawGame, AwayTeamWin
    }

    public class ResultPrediction
    {
        public int Id { get; set; }

        public virtual Prediction Prediction { get; set; }
    }
}
