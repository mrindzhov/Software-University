using System;
using System.Collections.Generic;
using System.Linq;

namespace Engine.Methods
{
    class ReverseNumbersWithStack
    {
        public static void Run()
        {
            int[] numbers = Console.ReadLine().Split().Select(int.Parse).ToArray();
            Stack<int> stack = new Stack<int>();

            foreach (var num in numbers)
            {
                stack.Push(num);
            }
            if (stack.Count > 0)
            {
                while (stack.Count > 0)
                {
                    Console.Write(stack.Pop() + " ");
                }
                Console.WriteLine();
            }
            else
            {
                Console.WriteLine("(empty)");
            }
        }

    }
}
