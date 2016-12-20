using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

public class Family
{
    public List<Person> members;
    public Family()
    {
        this.members=new List<Person>();
    }
    public void AddMember(Person member)
    {
        this.members.Add(member);
    }
    public Person GetOldestMember()
    {
        return this.members.OrderByDescending(p => p.age).First();
    }
    
}
public class Person
{
    public string name;
    public int age;
    public Person(string name,int age)
    {
        this.name = name;
        this.age = age;
    }

}
class Program
{
    static void Main()
    {
        MethodInfo oldestMemberMethod = typeof(Family).GetMethod("GetOldestMember");
        MethodInfo addMemberMethod = typeof(Family).GetMethod("AddMember");
        if (oldestMemberMethod == null || addMemberMethod == null)
        {
            throw new Exception();
        }
        int n = int.Parse(Console.ReadLine());
        var family = new Family();
        var people = new List<Person>();
        for (int i = 0; i < n; i++)
        {
            var row = Console.ReadLine().Split(' ');
            var person = new Person(row[0], int.Parse(row[1]));
            family.AddMember(person);
            people.Add(person);
        }
        var oldest = family.GetOldestMember();
        Console.WriteLine(oldest.name+" "+oldest.age);
    }
}
