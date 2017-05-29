namespace AlgoComplexityAndLinearDS.Exercises.DistanceInLabyrinth
{
    class Point
    {
        public int Row { get; set; }
        public int Col { get; set; }

        public int Count { get; set; }

        public Point(int row, int col, int count = 0)
        {
            this.Row = row;
            this.Col = col;
            this.Count = count;
        }
    }
}
