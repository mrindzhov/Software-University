using System;
using System.Collections.Generic;
using System.Linq;

namespace AlgoComplexityAndLinearDS.Exercises.DistanceInLabyrinth
{

    public class DistanceInLabyrinth
    {
        public static void Run()
        {

            int n = int.Parse(Console.ReadLine());
            string[][] matrix = new string[n][];

            Point entryPoint;
            Queue<Point> queue = new Queue<Point>();
            for (int i = 0; i < n; i++)
            {
                matrix[i] = Console.ReadLine().ToCharArray().Select(x => x.ToString()).ToArray();
                for (int j = 0; j < matrix[i].Length; j++)
                {
                    if (matrix[i][j] == "*")
                    {
                        entryPoint = new Point(i, j);
                        queue.Enqueue(entryPoint);
                    }
                }
            }

            while (queue.Count > 0)
            {
                var point = queue.Dequeue();
                Traverse(queue, point, matrix);
            }

            Print(matrix);
        }

        private static void Print(string[][] matrix)
        {
            for (int row = 0; row < matrix.Length; row++)
            {
                for (int col = 0; col < matrix[row].Length; col++)
                {
                    if (matrix[row][col] == "0")
                    {
                        matrix[row][col] = "u";
                    }
                }
                Console.WriteLine(string.Join("", matrix[row]));
            }
        }

        private static void Traverse(Queue<Point> queue, Point point, string[][] matrix)
        {
            if (point.Col > 0 && matrix[point.Row][point.Col - 1] == "0")
            {
                matrix[point.Row][point.Col - 1] = (point.Count+1).ToString();
                queue.Enqueue(new Point(point.Row, point.Col - 1, point.Count+1));
            }
            if (point.Row > 0 && matrix[point.Row - 1][point.Col] == "0")
            {
                matrix[point.Row - 1][point.Col] = (point.Count+1).ToString();
                queue.Enqueue(new Point(point.Row - 1, point.Col, point.Count+1));
            }
            if (point.Col < matrix.Length - 1 && matrix[point.Row][point.Col + 1] == "0")
            {
                matrix[point.Row][point.Col + 1] = (point.Count+1).ToString();
                queue.Enqueue(new Point(point.Row, point.Col + 1, point.Count+1));
            }
            if (point.Row < matrix.Length - 1 && matrix[point.Row + 1][point.Col] == "0")
            {
                matrix[point.Row + 1][point.Col] = (point.Count+1).ToString();
                queue.Enqueue(new Point(point.Row + 1, point.Col, point.Count+1));
            }
        }
    }
}
