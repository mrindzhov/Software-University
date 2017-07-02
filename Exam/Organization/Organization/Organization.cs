using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

public class Organization : IOrganization
{
    Dictionary<string, HashSet<Person>> employees;
    List<Person> employeesOrder;
    SortedDictionary<int, HashSet<Person>> nameSize;

    public Organization()
    {
        this.employees = new Dictionary<string, HashSet<Person>>();
        this.employeesOrder = new List<Person>();
        this.nameSize = new SortedDictionary<int, HashSet<Person>>();
    }
    public int Count { get { return this.employees.Count; } }

    public IEnumerator<Person> GetEnumerator()
    {
        foreach (var employee in employeesOrder)
        {
            yield return employee;
        }
    }

    IEnumerator IEnumerable.GetEnumerator()
    {
        return this.GetEnumerator();
    }

    public bool Contains(Person person)
    {
        if (this.employees.ContainsKey(person.Name) && this.employees[person.Name].Contains(person))
        {
            return true;
        }
        return false;
    }

    public bool ContainsByName(string name)
    {
        if (this.employees.ContainsKey(name))
        {
            return true;
        }
        return false;
    }

    public void Add(Person person)
    {
        if (this.Contains(person))
        {
            throw new InvalidOperationException("Cannot add duplicates");
        }

        this.employees.EnsureKeyExists(person.Name);
        this.employees.AppendValueToKey(person.Name, person);
        this.nameSize.EnsureKeyExists(person.Name.Length);
        this.nameSize.AppendValueToKey(person.Name.Length, person);
        this.employeesOrder.Add(person);
    }

    public Person GetAtIndex(int index)
    {
        if (index > this.Count || index < 0)
        {
            throw new IndexOutOfRangeException();
        }
        return this.employeesOrder[index];
    }

    public IEnumerable<Person> GetByName(string name)
    {
        if (!this.employees.ContainsKey(name))
        {
            return new HashSet<Person>();
        }
        return this.employees[name];
    }

    public IEnumerable<Person> FirstByInsertOrder(int count = 1)
    {
        int limit = count > this.Count ? this.Count : count;
        for (int i = 0; i < limit; i++)
        {
            yield return employeesOrder[i];
        }
    }

    public IEnumerable<Person> SearchWithNameSize(int minLength, int maxLength)
    {
        foreach (var pair in this.nameSize.Where(p => p.Key >= minLength && p.Key <= maxLength))
        {
            foreach (var person in pair.Value)
            {
                yield return person;
            }
        }
    }

    public IEnumerable<Person> GetWithNameSize(int length)
    {
        var result = new List<Person>();
        try
        {
            var collection = this.nameSize[length];

            foreach (var pair in collection)
            {
                result.Add(pair);
            }
        }
        catch (KeyNotFoundException)
        {
            throw new ArgumentException();
        }
        return result;

    }

    public IEnumerable<Person> PeopleByInsertOrder()
    {
        for (int i = 0; i < this.employeesOrder.Count; i++)
        {
            yield return this.employeesOrder[i];

        }
    }
}