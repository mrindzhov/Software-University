using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AlgoComplexityAndLinearDS.Exercises
{
    public class CountOfOccurrences
    {
        public static void Run()
        {
            List<int> nums = Console.ReadLine().Split().Select(int.Parse).ToList();
            SortedDictionary<int, int> occurrences = new SortedDictionary<int, int>();
            FillOccurrences(nums, occurrences);
            StringBuilder sb = new StringBuilder();
            foreach (var item in occurrences)
            {
                sb.AppendLine($"{item.Key} -> {item.Value} times");
            }
            Console.WriteLine(sb.ToString().Trim());
        }

        private static void FillOccurrences(List<int> nums, SortedDictionary<int, int> occurrences)
        {
            foreach (var num in nums)
            {
                if (occurrences.ContainsKey(num))
                {
                    occurrences[num]++;
                }
                else
                {
                    occurrences.Add(num, 1);
                }
            }
        }
    }
}