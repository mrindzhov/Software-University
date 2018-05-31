using System;
using System.Collections.Generic;
using System.Linq;

public class PersonCollectionSlow : IPersonCollection
{
    private Dictionary<string, Person> personByEmail = new Dictionary<string, Person>();
    private Dictionary<string, SortedSet<Person>> personByEmailDomain =
        new Dictionary<string, SortedSet<Person>>();
    private Dictionary<string, SortedSet<Person>> personByNameAndTown =
        new Dictionary<string, SortedSet<Person>>();
    private SortedDictionary<int, SortedSet<Person>> personByAge =
        new SortedDictionary<int, SortedSet<Person>>();
    private Dictionary<string, SortedDictionary<int, SortedSet<Person>>> personByTownAndAge =
        new Dictionary<string, SortedDictionary<int, SortedSet<Person>>>();

    public bool AddPerson(string email, string name, int age, string town)
    {
        if (this.FindPerson(email) != null)
        {
            return false;
        }
        var person = new Person
        {
            Email = email,
            Name = name,
            Age = age,
            Town = town
        };

        this.personByEmail.Add(email, person);

        string emailDomain = this.ExtractDomain(email);
        this.personByEmailDomain.AppendValueToKey(emailDomain, person);

        string nameAndTown = this.ConcatNameAndTown(name, town);
        this.personByNameAndTown.AppendValueToKey(nameAndTown, person);

        this.personByTownAndAge.EnsureKeyExists(town);
        this.personByTownAndAge[town].AppendValueToKey(age, person);

        this.personByAge.AppendValueToKey(age, person);

        return true;
    }

    private string ConcatNameAndTown(string name, string town)
    {
        string separator = "|!|";
        return name + separator + town;
    }

    private string ExtractDomain(string email)
    {
        return email.Split('@')[1];
    }

    public int Count
    {
        get
        {
            return this.personByEmail.Count;
        }
    }

    public Person FindPerson(string email)
    {
        Person person;
        this.personByEmail.TryGetValue(email, out person);
        return person;
    }

    public bool DeletePerson(string email)
    {
        Person person = this.FindPerson(email);
        if (person == null)
        {
            return false;
        }
        this.personByEmail.Remove(email);

        this.personByEmailDomain[this.ExtractDomain(email)].Remove(person);

        this.personByNameAndTown[this.ConcatNameAndTown(person.Name, person.Town)].Remove(person);

        this.personByAge[person.Age].Remove(person);

        this.personByTownAndAge[person.Town][person.Age].Remove(person);

        return true;
    }

    public IEnumerable<Person> FindPersons(string emailDomain)
    {
        return this.personByEmailDomain.GetValuesForKey(emailDomain);
    }

    public IEnumerable<Person> FindPersons(string name, string town)
    {
        return this.personByNameAndTown.GetValuesForKey(this.ConcatNameAndTown(name, town));
    }

    public IEnumerable<Person> FindPersons(int startAge, int endAge)
    {
        throw new NotImplementedException();

    }

    public IEnumerable<Person> FindPersons(int startAge, int endAge, string town)
    {
        // TODO: implement this
        throw new NotImplementedException();
    }
}
