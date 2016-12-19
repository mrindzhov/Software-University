using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace _09.google
{
    public class Person
    {
        public string name;
        public Company company;
        public Car car;
        public List<Parent> parent;
        public List<Child> children;
        public List<Pokemon> pokemon;

        public Person(string name)
        {
            this.name = name;
            this.parent = new List<Parent>();
            this.children = new List<Child>();
            this.pokemon = new List<Pokemon>();
        }

        public override string ToString()
        {
            StringBuilder result = new StringBuilder();

            result.AppendLine(string.Format($"{this.name}"));
            result.AppendLine(string.Format($"Company:"));
            if (this.company != null)
            {
                result.AppendLine(string.Format($"{this.company.name} {this.company.department} {this.company.salary:F2}"));
            }
            result.AppendLine(string.Format($"Car:"));
            if (this.car != null)
            {
                result.AppendLine(string.Format($"{this.car.model} {this.car.speed}"));
            }
            result.AppendLine(string.Format($"Pokemon:"));
            if (this.pokemon != null)
            {
                foreach (var pokemon in this.pokemon)
                {
                    result.AppendLine(string.Format($"{pokemon.name} {pokemon.type}"));
                }
            }
            result.AppendLine(string.Format($"Parents:"));
            if (this.parent != null)
            {
                foreach (var parent in this.parent)
                {
                    result.AppendLine(string.Format($"{parent.name} {parent.dateOfBirth}"));
                }
            }
            result.AppendLine(string.Format($"Children:"));
            if (this.children != null)
            {
                foreach (var children in this.children)
                {
                    result.AppendLine(string.Format($"{children.name} {children.dateOfBirth}"));
                }
            }

            return result.ToString();
        }
    }
    public class Company
    {
        public string name;
        public string department;
        public decimal salary;
        public Company(string name, string department, decimal salary)
        {
            this.name = name;
            this.department = department;
            this.salary = salary;
        }
    
    }
    public class Pokemon
    {
        public string name;
        public string type;
        public Pokemon(string name, string type)
        {
            this.name = name;
            this.type = type;
        }
    }
    public class Parent
    {
        public string name;
        public string dateOfBirth;
        public Parent(string name, string dateOfBirth)
        {
            this.name = name;
            this.dateOfBirth = dateOfBirth;
        }
    }
    public class Child
    {
        public string name;
        public string dateOfBirth;
        public Child(string name, string dateOfBirth)
        {
            this.name = name;
            this.dateOfBirth = dateOfBirth;
        }
    }
    public class Car
    {
        public string model;
        public int speed;
        public Car(string model, int speed)
        {
            this.model = model;
            this.speed = speed;
        }
    }
    public class Program
    {
        static void Main()
        {
            {
                string data = Console.ReadLine().Trim();
                var people = new List<Person>();

                while (data != "End")
                {
                    string[] details = data.Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);

                    string detailsType = details[1];
                    string personName = details[0];
                    bool personExist = false;


                    foreach (var person in people)
                    {
                        if (person.name == personName)
                        {
                            personExist = true;
                            break;
                        }
                    }

                    if (!personExist)
                    {
                        var currentPerson = new Person(personName);

                        switch (detailsType)
                        {
                            case "company":
                                string currentCompanyName = details[2];
                                string currentCompanyDept = details[3];
                                decimal currentCompanySalary = decimal.Parse(details[4]);
                                var currentCompany = new Company(currentCompanyName, currentCompanyDept, currentCompanySalary);
                                currentPerson.company = currentCompany;
                                break;
                            case "car":
                                string currentCarName = details[2];
                                int currentCarSpeed = int.Parse(details[3]);
                                var currentCar = new Car(currentCarName, currentCarSpeed);
                                currentPerson.car = currentCar;
                                break;
                            case "pokemon":
                                string currentPokemonName = details[2];
                                string currentPokemonType = details[3];
                                var currentPokemon = new Pokemon(currentPokemonName, currentPokemonType);
                                currentPerson.pokemon.Add(currentPokemon);
                                break;
                            case "parents":
                                string currentParentName = details[2];
                                string currentParentBirthDate = details[3];
                                var currentParent = new Parent(currentParentName, currentParentBirthDate);
                                currentPerson.parent.Add(currentParent);
                                break;
                            case "children":
                                string currentChildName = details[2];
                                string currentChildBirthDate = details[3];
                                var currentChild = new Child(currentChildName, currentChildBirthDate);
                                currentPerson.children.Add(currentChild);
                                break;
                        }
                        people.Add(currentPerson);
                    }
                    else
                    {
                        foreach (var person in people)
                        {
                            if (person.name == personName)
                            {
                                switch (detailsType)
                                {
                                    case "company":
                                        string currentCompanyName = details[2];
                                        string currentCompanyDept = details[3];
                                        decimal currentCompanySalary = decimal.Parse(details[4]);
                                        var currentCompany = new Company(currentCompanyName, currentCompanyDept, currentCompanySalary);
                                        person.company = currentCompany;
                                        break;
                                    case "car":
                                        string currentCarName = details[2];
                                        int currentCarSpeed = int.Parse(details[3]);
                                        var currentCar = new Car(currentCarName, currentCarSpeed);
                                        person.car = currentCar;
                                        break;
                                    case "pokemon":
                                        string currentPokemonName = details[2];
                                        string currentPokemonType = details[3];
                                        var currentPokemon = new Pokemon(currentPokemonName, currentPokemonType);
                                        person.pokemon.Add(currentPokemon);
                                        break;
                                    case "parents":
                                        string currentParentName = details[2];
                                        string currentParentBirthDate = details[3];
                                        var currentParent = new Parent(currentParentName, currentParentBirthDate);
                                        person.parent.Add(currentParent);
                                        break;
                                    case "children":
                                        string currentChildName = details[2];
                                        string currentChildBirthDate = details[3];
                                        var currentChild = new Child(currentChildName, currentChildBirthDate);
                                        person.children.Add(currentChild);
                                        break;
                                }
                            }
                        }
                    }
                    data = Console.ReadLine().Trim();
                }
                string searchedName = Console.ReadLine().Trim();

                people.Where(p => p.name == searchedName).ToList().ForEach(p => Console.WriteLine(p.ToString()));
            }
        }
    }
}
