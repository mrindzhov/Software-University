
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public class Person
{
    private string name;
    private int age;
    private string occupation;
    public Person(string name,int age,string occupation)
    {
        this.name = name;
        this.age = age;
        this.occupation = occupation;
    }
    public string Name => this.name;
    public int Age => this.age;
    public string Occupation => this.occupation;
}
public class Program
{
    static void Main()
    {
        var people = new List<Person>();
        while (true)
        {
            string input = Console.ReadLine();
            if (input == "END")
            {
                break;
            }
            string[] splittedInput = input.Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
            var person = new Person(splittedInput[0], int.Parse(splittedInput[1]), splittedInput[2]);
            //string personName = splittedInput[0];
            //int personAge = int.Parse(splittedInput[1]);
            //string personOccupation = splittedInput[2];
            people.Add(person);
        }
        people.OrderBy(p => p.Age).ToList().ForEach(p => { Console.WriteLine($"{p.Name} - age: {p.Age}, occupation: {p.Occupation}"); });
    }
}