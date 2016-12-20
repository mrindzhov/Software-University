using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

public class ImmutableList
{
    public int[] collection;

    public ImmutableList(int[] collection)
    {
        this.collection = collection;
    }

    public ImmutableList GetNewImmutableList()
    {
        int[] newCollection = new int[this.collection.Length];

        for (int i = 0; i < collection.Length; i++)
        {
            newCollection[i] = this.collection[i];
        }

        return new ImmutableList(newCollection);
    }
}
public class Program
{
    static void Main(string[] args)
    {
        Type immutableList = typeof(ImmutableList);
        FieldInfo[] fields = immutableList.GetFields();
        if (fields.Length < 1)
        {
            throw new Exception();
        }
        else
        {
            Console.WriteLine(fields.Length);
        }

        MethodInfo[] methods = immutableList.GetMethods();
        bool containsMethod = methods.Any(m => m.ReturnType.Name.Equals("ImmutableList"));
        if (!containsMethod)
        {
            throw new Exception();
        }
        else
        {
            Console.WriteLine(methods[0].ReturnType.Name);
        }

    }
}