using System;
using System.Collections.Generic;
using System.Linq;

namespace AlgoComplexityAndLinearDS.Exercises
{
    public class SumAndAverage
    {

        public static void Run()
        {
            List<int> numbers = Console.ReadLine().Split().Select(int.Parse).ToList();
            long sum = SumNumbers(numbers);
            int count = numbers.Count();
            double average = (double)(sum) / count;
            Console.WriteLine($"Sum={sum}; Average={average:f2}");
        }

        private static long SumNumbers(List<int> numbers)
        {
            long sum = 0;

            foreach (var num in numbers)
            {
                sum += num;
            }
            return sum;
        }
    }
}
