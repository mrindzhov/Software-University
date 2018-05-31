using System;
using System.Linq;

public class ArrayStack<T>
{
    private T[] elements;
    public int Count { get; private set; }

    private const int InitialCapacity = 16;

    public ArrayStack(int capacity = InitialCapacity)
    {
        this.elements = new T[capacity];
    }

    public void Push(T element)
    {
        this.elements[this.Count++] = element;
        if (this.Count == this.elements.Length)
        {
            this.Grow();
        }
    }

    public T Pop()
    {
        if (IsEmpty())
        {
            throw new InvalidOperationException("Stack is empty");
        }
        return this.elements[--this.Count];
    }


    public T[] ToArray()
    {

        return this.elements.Take(this.Count).Reverse().ToArray();
    }
    private void Grow()
    {
        T[] copy = new T[this.elements.Length * 2];
        Array.Copy(this.elements, copy, this.Count);
        this.elements = copy;
    }
    private bool IsEmpty()
    {
        return this.Count == 0;
    }
}