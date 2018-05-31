using System;
using System.Collections.Generic;

namespace Engine.Methods
{
    class CalculateSequenceWithQueue
    {
        //•	S1 = N
        //•	S2 = S1 + 1
        //•	S3 = 2*S1 + 1
        //•	S4 = S1 + 2
        //•	S5 = S2 + 1
        //•	S6 = 2*S2 + 1
        //•	S7 = S2 + 2
        //•	…

        //Input Output
        //2	   |2, 3, 5, 4, 4, 7, 5, 6, 11, 7, 5, 9, 6, …
        //-1   |-1, 0, -1, 1, 1, 1, 2, …
        //1000 |1000, 1001, 2001, 1002, 1002, 2003, 1003, …

        public static void Run()
        {
            int number = int.Parse(Console.ReadLine());
            Console.WriteLine(string.Join(", ", GenerateQueue(number)));
        }

        private static int[] GenerateQueue(int number)
        {
            Queue<int> queue = new Queue<int>();
            queue.Enqueue(number);
            int[] result = new int[50];
            for (int i = 0; i < 50; i++)
            {
                int num = queue.Dequeue();
                result[i] = num;

                queue.Enqueue(num + 1);
                queue.Enqueue(num * 2 + 1);
                queue.Enqueue(num + 2);
            }

            return result;
        }
    }
}
