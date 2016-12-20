using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

class Number
{
    public string number;
    public Number(string number)
    {
        this.number = number;
    }
    public string LastDiggitName()
    {
        int lastDiggit = int.Parse(this.number.Last().ToString());
        var output = "";
        switch (lastDiggit)
        {
            case 0:
                output= "zero";
                break;
            case 1:
                output= "one"; break;

            case 2:
                output= "two"; break;

            case 3:
                output= "three"; break;

            case 4:
                output= "four"; break;

            case 5:
                output= "five"; break;

            case 6:
                output= "six"; break;

            case 7:
                output= "seven"; break;

            case 8:
                output= "eight"; break;

            case 9:
                output= "nine"; break;

        }
        return output;
    }
}
class Program
{
    static void Main(string[] args)
    {
        string n = Console.ReadLine();
        var number = new Number(n);
        Console.WriteLine(number.LastDiggitName());
    }
}
