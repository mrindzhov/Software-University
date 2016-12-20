using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public class Number
{
    public int number;
    public bool isPrime;

    public Number(int number)
    {
        this.number = number;
        this.isPrime = CheckIfPrime(number);
    }

    private bool CheckIfPrime(int num)
    {
        bool prime = true;

        for (int i = 2; i < Math.Sqrt(num) + 1; i++)
        {
            if (num % i == 0)
            {
                prime = false;
                break;
            }
        }

        return prime;
    }

    public Number GetNextPrime()
    {
        int nextPrimeNum = this.number + 1;
        while (!CheckIfPrime(nextPrimeNum))
        {
            nextPrimeNum++;
        }
        return new Number(nextPrimeNum);
    }
    public class Startup
    {
        public static void Main()
        {
            int inputNumber = int.Parse(Console.ReadLine());
            var num = new Number(inputNumber);
            Console.WriteLine(num.GetNextPrime().number + ", " + num.isPrime.ToString().ToLower());
        }
    }
}

