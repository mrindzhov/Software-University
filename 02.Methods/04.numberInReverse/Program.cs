using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public class DecimalNumber
{
    public string number;

    public DecimalNumber(string number)
    {
        this.number = number;
    }
    public string ReverseNumber()
    {
        return new string(Enumerable.Range(1, this.number.Length).Select(i => this.number[this.number.Length - i]).ToArray());
    }

}
public class Program
{
    static void Main(string[] args)
    {
        string n = Console.ReadLine();
        var number = new DecimalNumber(n);
        Console.WriteLine(number.ReverseNumber());
    }
}