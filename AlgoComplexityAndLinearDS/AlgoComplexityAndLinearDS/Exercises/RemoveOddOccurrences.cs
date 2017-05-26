using System;
using System.Collections.Generic;
using System.Linq;

namespace AlgoComplexityAndLinearDS.Exercises
{
    public class RemoveOddOccurrences
    {
        public static void Run()
        {
            List<int> nums = Console.ReadLine().Split().Select(int.Parse).ToList();
            Dictionary<int, int> occurrences = new Dictionary<int, int>();
            nums = Remove(nums, occurrences);
            Console.WriteLine(string.Join(" ", nums));
        }

        private static List<int> Remove(List<int> nums, Dictionary<int, int> occurrences)
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
            nums = nums.Where(n => occurrences[n] % 2 == 0).ToList();
            return nums;
        }
    }
}
