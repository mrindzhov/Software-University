using System;
using System.Collections;
using System.Collections.Generic;

public class LinkedList<T> : IEnumerable<T>
{
    private Node head;
    private Node tail;

    public int Count { get; private set; }

    public void AddFirst(T item)
    {
        Node oldHead = this.head;
        this.head = new Node(item) { Next = oldHead };
        if (this.Count == 0)
        {
            this.tail = this.head;
        }
        this.Count++;
    }

    public void AddLast(T item)
    {
        Node oldTail = this.tail;
        Node newTail = new Node(item);
        if (oldTail == null)
        {
            this.head = this.tail = newTail;
        }
        else
        {
            oldTail.Next = newTail;
            this.tail = newTail;
        }
        this.Count++;
    }

    public T RemoveFirst()
    {
        if (this.Count == 0)
        {
            throw new InvalidOperationException();
        }
        Node oldHead = this.head;
        this.head = oldHead.Next;
        if (this.Count == 0)
        {
            this.tail = null;
        }
        this.Count--;
        return oldHead.Value;
    }

    public T RemoveLast()
    {
        if (this.Count == 0)
        {
            throw new InvalidOperationException();
        }

        Node oldTail = this.tail;

        if (this.Count == 1)
        {
            this.head = this.tail = null;
        }
        else
        {
            Node newTail = this.GetSecondToLast();
            oldTail.Next = newTail;
            this.tail = newTail;
        }
        this.Count--;
        return oldTail.Value;
    }
    private Node GetSecondToLast()
    {
        Node node = this.head;
        while (node.Next != tail)
        {
            node = node.Next;
        }
        return node;
    }
    public IEnumerator<T> GetEnumerator()
    {
        Node curr = this.head;
        while (curr.Next != null)
        {
            yield return curr.Value;
            curr = curr.Next;
        }
    }

    IEnumerator IEnumerable.GetEnumerator()
    {
        return this.GetEnumerator();
    }

    private class Node
    {
        public Node(T value)
        {
            this.Value = value;
        }

        public Node Next { get; set; }
        public T Value { get; }

    }
}
