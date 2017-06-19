﻿using System;
using System.Collections.Generic;

public class Tree<T>
{
    public T Value { get; set; }

    public Tree<T> Parent { get; set; }

    public List<Tree<T>> Children { get; set; }

    public Tree(T value, params Tree<T>[] children)
    {
        this.Value = value;
        this.Children = new List<Tree<T>>();
        foreach (var child in children)
        {
            this.Children.Add(child);
            child.Parent = this;
        }
    }

    public void PrintTree(int indent = 0)
    {
        Console.WriteLine(new string(' ', indent) + this.Value);
        foreach (var child in this.Children)
        {
            if (child != null)
            {
                child.PrintTree(indent + 2);
            }
        }
    }
    public override string ToString()
    {
        return this.Value.ToString();
    }
}