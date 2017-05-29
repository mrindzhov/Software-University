using System;

public class LinkedStack<T>
{
    private Node<T> firstNode;

    public int Count { get; private set; }

    public void Push(T element)
    {
        //Node<T> newElement = new Node<T>(element);

        //if (this.Count == 0)
        //{
        //    this.firstNode = newElement;
        //}
        //else
        //{
        //    Node<T> oldFirst = this.firstNode;
        //    this.firstNode = newElement;
        //    newElement.NextNode = oldFirst;
        //} 
        this.firstNode = new Node<T>(element, this.firstNode);
        this.Count++;
    }
    public T Pop()
    {
        if (this.Count == 0)
        {
            throw new InvalidOperationException("Stack is empty");
        }
        Node<T> oldFirst = this.firstNode;
        this.firstNode = oldFirst.NextNode;
        this.Count--;
        return oldFirst.Value;
    }
    public T[] ToArray()
    {
        T[] result = new T[this.Count];
        int counter = 0;
        while (firstNode != null)
        {
            result[counter++] = firstNode.Value;
            firstNode = firstNode.NextNode;
        }
        return result;
    }

    private class Node<T>
    {
        public T Value { get; }
        public Node<T> NextNode { get; set; }

        public Node(T value, Node<T> nextNode = null)
        {
            this.Value = value;
            this.NextNode = nextNode;
        }
    }
}