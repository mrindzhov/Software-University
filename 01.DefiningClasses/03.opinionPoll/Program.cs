using System;
using System.Collections.Generic;
using System.Linq;

namespace _03.opinionPoll
{
    public class Person
    {
        public string name;
        public int age;
        public Person()
        {
            name = "No name";
            age = 1;
        }
        public Person(int age)
        {
            name = "No name";
            this.age = age;
        }
        public Person(string name, int age)
        {
            this.name = name;
            this.age = age;
        }
    }
    class Program
    {
        public static void Main()
        {
            int persons = int.Parse(Console.ReadLine());
            var people = new List<Person>();
            for (int i = 0; i < persons; i++)
            {
                var personInfo = Console.ReadLine().Split(' ');
                var person = new Person(personInfo[0], int.Parse(personInfo[1]));
                people.Add(person);
            }
            people.Where(p => p.age > 30).OrderBy(p => p.name).ToList().ForEach(p => Console.WriteLine(p.name + " - " + p.age));
        }
    }
}
