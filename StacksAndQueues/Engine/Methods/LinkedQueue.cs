using System;

public class LinkedQueue<T>
{
    private QueueNode<T> Head { get; set; }
    private QueueNode<T> Tail { get; set; }

    public int Count { get; private set; }

    public void Enqueue(T element)
    {
        if (this.Count == 0)
        {
            this.Head = this.Tail = new QueueNode<T>(element);
        }
        else
        {
            QueueNode<T> oldTail = this.Tail;
            this.Tail = new QueueNode<T>(element, oldTail);
            oldTail.NextNode = this.Tail;
        }
        this.Count++;
    }

    public T Dequeue()
    {
        if (this.Count == 0)
        {
            throw new InvalidOperationException("Queue is empty");
        }
        QueueNode<T> oldHead = this.Head;
        this.Head = oldHead.PrevNode;
        this.Head.NextNode = null;
        this.Count--;
        return oldHead.Value;
    }
    public T[] ToArray()
    {
        T[] result = new T[this.Count];
        int counter = 0;
        while (this.Head != null)
        {
            result[counter++] = this.Head.Value;
            this.Head = this.Head.NextNode;
        }
        return result;
    }

    private class QueueNode<T>
    {
        public T Value { get; private set; }
        public QueueNode<T> NextNode { get; set; }
        public QueueNode<T> PrevNode { get; set; }
        public QueueNode(T value, QueueNode<T> prev = null)
        {
            this.Value = value;
            this.PrevNode = prev;
        }
    }
}
