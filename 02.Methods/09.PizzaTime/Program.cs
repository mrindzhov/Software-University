using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text.RegularExpressions;


public class Pizza
{
    private string name;
    private int group;
    public Pizza(string name, int group)
    {
        this.group = group;
        this.name = name;
    }
    public string Name => this.name;
    public int Group => this.group;
    public string GetDescription()
    {
        return $"Name: {this.name} - Group: {this.group}";
    }
    //public SortedDictionary<int, List<string>> SortPizzas(params Pizza[] pizzas)
    //{
    //    var sortedPizzas = new SortedDictionary<int, List<string>>();
        
    //    foreach (var pizza in pizzas)
    //    {
    //        Regex re = new Regex(@"([a-zA-Z]+)(\d+)");
    //        Match result = re.Match(pizza.ToString());

    //        string alphaPart = result.Groups[1].Value;
    //        string numberPart = result.Groups[2].Value;

    //        //var letterPosition = pizza.IndexOf(pizza.First(char.IsLetter));
    //        //int group = int.Parse(pizza.Substring(0, letterPosition + 1));
    //        //string pizzaName = pizza.Substring(letterPosition + 1);
            
    //        if (!sortedPizzas.ContainsKey(group))
    //        {
    //            sortedPizzas.Add(group, new List<string>(new string[] { alphaPart }));
    //        }
    //        else
    //        {
    //            sortedPizzas[group].Add(alphaPart);
    //        }
    //    }
    //    return sortedPizzas;
    //}
}
public class StartUp
{
    public static void Main()
    {
        string[] input = Console.ReadLine().Split(' ');
        var pizzas = new Pizza[input.Length];

        for (int i = 0; i < input.Length; i++)
        {
            int letterPosition = input[i].IndexOf(input[i].First(char.IsLetter));
            int pizzaGroup = int.Parse(input[i].Substring(0, letterPosition));
            string pizzaName = input[i].Substring(letterPosition);

            var currentPizza = new Pizza(pizzaName, pizzaGroup);
            pizzas[i] = currentPizza;
        }
        var result = SortPizzas(pizzas);
        foreach (var item in result)
        {
            Console.WriteLine("{0} - {1}", item.Key, string.Join(", ", item.Value));
        }
    }
    public static SortedDictionary<int, List<string>> SortPizzas(params Pizza[] pizzas)
    {
        var sortedPizzas = new SortedDictionary<int, List<string>>();

        foreach (Pizza pizza in pizzas)
        {
            int group = pizza.Group;
            string pizzaName = pizza.Name;

            if (!sortedPizzas.ContainsKey(group))
            {
                sortedPizzas.Add(group, new List<string>(new string[] { pizzaName }));
            }
            else
            {
                sortedPizzas[group].Add(pizzaName);
            }
        }
        return sortedPizzas;
    }
}