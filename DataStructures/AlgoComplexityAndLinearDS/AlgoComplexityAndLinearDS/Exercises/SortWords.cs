using System;
using System.Collections.Generic;
using System.Linq;

namespace AlgoComplexityAndLinearDS.Exercises
{
    public class SortWords
    {
        public static void Run()
        {
            List<string> words = Console.ReadLine().Split().ToList();
            Console.WriteLine(string.Join(" ",Sort(words)));
        }

        private static List<string> Sort(List<string> words)
        {
            words.Sort();
            return words;
        }
    }
}