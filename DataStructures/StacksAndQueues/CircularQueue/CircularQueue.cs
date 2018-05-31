using System;

namespace CircularQueue
{
    public class CircularQueue<T>
    {
        private T[] elements;
        private int head = 0;
        private int tail = 0;
        private const int InitialCapacity = 4;

        public CircularQueue(int capacity = InitialCapacity)
        {
            this.elements = new T[capacity];
        }

        public int Count { get; private set; }

        public void Enqueue(T element)
        {
            if (this.Count >= this.elements.Length)
            {
                this.Resize();
            }
            this.elements[this.tail] = element;
            this.tail = (this.tail + 1) % this.elements.Length;
            this.Count++;

        }

        private void Resize()
        {
            T[] copy = new T[this.elements.Length * 2];
            this.CopyElements(copy);
            this.elements = copy;
            this.head = 0;
            this.tail = Count;
        }

        private void CopyElements(T[] copy)
        {
            int currHead = this.head;
            int currentIndex = 0;

            while (currentIndex < this.Count)
            {
                copy[currentIndex++] = this.elements[currHead];
                currHead = (currHead + 1) % this.elements.Length;
            }
        }

        public T Dequeue()
        {
            if (this.Count == 0)
            {
                throw new InvalidOperationException();
            }
            T result = this.elements[this.head];
            this.head = (this.head + 1) % this.elements.Length;
            this.Count--;
            return result;
        }

        public T[] ToArray()
        {
            T[] array = new T[this.Count];
            this.CopyArray(array);
            return array;
        }
        private void CopyArray(T[] destinationArray)
        {
            int currentIndex = 0;
            int currentHead = this.head;
            while (currentIndex < this.Count)
            {
                destinationArray[currentIndex++] = this.elements[currentHead];
                currentHead = (currentHead + 1) % this.elements.Length;
            }
        }
    }
}
