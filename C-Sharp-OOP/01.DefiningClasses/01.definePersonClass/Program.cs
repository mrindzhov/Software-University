using System;
using System.Reflection;

namespace definePersonClass
{
    public class Person
    {
        public string name;
        public int age;
        public Person(string name, int age)
        {
            this.name = name;
            this.age = age;
        }
    }
    class Program
    {
        public static void Main(string[] args)
        {
            Type personType = typeof(Person);

            FieldInfo[] fields = personType.GetFields(BindingFlags.Public | BindingFlags.Instance);

            Console.WriteLine(fields.Length);
        }
    }
}
