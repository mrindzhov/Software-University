using System;
using System.Collections;
using System.Collections.Generic;

public class DoublyLinkedList<T> : IEnumerable<T>
{
    public ListNode<T> Head { get; private set; }
    public ListNode<T> Tail { get; private set; }

    public int Count { get; private set; }

    private bool IsEmpty()
    {
        return this.Count == 0;
    }

    public void AddFirst(T element)
    {
        ListNode<T> newHead = new ListNode<T>(element);
        if (IsEmpty())
        {
            this.Head = this.Tail = newHead;
        }
        else
        {
            ListNode<T> oldHead = this.Head;
            this.Head.Previous = newHead;
            newHead.Next = oldHead;
            this.Head = newHead;
        }
        this.Count++;
    }

    public void AddLast(T element)
    {
        ListNode<T> newTail = new ListNode<T>(element);
        if (IsEmpty())
        {
            this.Head = this.Tail = newTail;
        }
        else
        {
            ListNode<T> oldTail = this.Tail;
            oldTail.Next = newTail;
            newTail.Previous = oldTail;
            this.Tail = newTail;
        }
        this.Count++;
    }

    public T RemoveFirst()
    {
        if (IsEmpty())
        {
            throw new InvalidOperationException("List is empty");
        }
        ListNode<T> oldHead = this.Head;
        if (this.Count == 1)
        {
            this.Head = this.Tail = null;
        }
        else
        {
            this.Head = oldHead.Next;
            this.Head.Previous = null;
        }
        this.Count--;
        return oldHead.Value;
    }

    public T RemoveLast()
    {
        if (IsEmpty())
        {
            throw new InvalidOperationException("List is empty");
        }
        ListNode<T> oldTail = this.Tail;
        if (this.Count == 1)
        {
            this.Head = this.Tail = null;
        }
        else
        {
            this.Tail = oldTail.Previous;
            this.Tail.Next = null;
        }
        this.Count--;

        return oldTail.Value;
    }

    public void ForEach(Action<T> action)
    {
        ListNode<T> currentNode = this.Head;
        while (currentNode != null)
        {
            action(currentNode.Value);
            currentNode = currentNode.Next;
        }
    }

    public IEnumerator<T> GetEnumerator()
    {
        ListNode<T> currentNode = this.Head;
        while (currentNode != null)
        {
            yield return currentNode.Value;
            currentNode = currentNode.Next;
        }

    }

    IEnumerator IEnumerable.GetEnumerator()
    {
        return this.GetEnumerator();
    }

    public T[] ToArray()
    {
        T[] result = new T[this.Count];
        var currentNode = this.Head;
        for (int i = 0; i < result.Length; i++)
        {
            result[i] = currentNode.Value;
            currentNode = currentNode.Next;
        }
        return result;
    }
}


class Example
{
    static void Main()
    {
        var list = new DoublyLinkedList<int>();

        list.ForEach(Console.WriteLine);
        Console.WriteLine("--------------------");

        list.AddLast(5);
        list.AddFirst(3);
        list.AddFirst(2);
        list.AddLast(10);
        Console.WriteLine("Count = {0}", list.Count);

        list.ForEach(Console.WriteLine);
        Console.WriteLine("--------------------");

        list.RemoveFirst();
        list.RemoveLast();
        list.RemoveFirst();

        list.ForEach(Console.WriteLine);
        Console.WriteLine("--------------------");

        list.RemoveLast();

        list.ForEach(Console.WriteLine);
        Console.WriteLine("--------------------");
    }
}
