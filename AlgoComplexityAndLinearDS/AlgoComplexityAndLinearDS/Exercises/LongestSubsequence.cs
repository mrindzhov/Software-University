using System;
using System.Collections.Generic;
using System.Linq;

namespace AlgoComplexityAndLinearDS.Exercises
{
    public class LongestSubsequence
    {
        public static void Run()
        {
            List<int> nums = Console.ReadLine().Split().Select(int.Parse).ToList();
            List<int> longestSubsequence = GetLongestSubsequence(nums);
            Console.WriteLine(string.Join(" ", longestSubsequence));
        }

        private static List<int> GetLongestSubsequence(List<int> nums)
        {

            int maxNumber = 0;
            int maxCount = 0;

            for (int i = 0; i < nums.Count; i++)
            {
                int currentCount = 1;
                for (int j = i + 1; j < nums.Count; j++)
                {
                    if (nums[j] == nums[i])
                    {
                        currentCount++;
                    }
                    else
                    {
                        break;
                    }
                }

                if (currentCount > maxCount)
                {
                    maxNumber = nums[i];
                    maxCount = currentCount;
                }
            }
            List<int> longest = new List<int>();

            for (int i = 0; i < maxCount; i++)
            {
                longest.Add(maxNumber);
            }

            return longest;

        }
    }
}
