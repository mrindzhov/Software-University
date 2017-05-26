using System;
using System.Collections;
using System.Collections.Generic;

namespace AlgoComplexityAndLinearDS.Exercises
{
    public class ReversedList<T> : IEnumerable<T>
    {
        public int Count { get; private set; }
        public int Capacity { get; private set; }
        private T[] items;

        public ReversedList()
        {
            this.Capacity = 2;
            this.items = new T[Capacity];
        }

        public T this[int index]
        {
            get
            {
                ValidateRange(index);
                T[] reversedArr = reversedGetReversedArray(items);
                return reversedArr[index];
            }
            set
            {
                ValidateRange(index);
                T[] reversedArr = reversedGetReversedArray(items);
                reversedArr[index] = value;
            }
        }

        private T[] reversedGetReversedArray(T[] items)
        {
            T[] reversed = new T[this.items.Length];
            Array.Copy(items, reversed, this.items.Length);
            Array.Reverse(reversed);
            return reversed;
        }

        public void Add(T item)
        {
            if (this.Count >= this.items.Length)
            {
                this.Resize();
            }
            this.items[this.Count++] = item;
        }


        public T RemoveAt(int index)
        {
            ValidateRange(index);
            T[] reversedArr = reversedGetReversedArray(items);
            T element = reversedArr[index];
            this.items[index] = default(T);
            this.Shift(index);
            this.Count--;
            return element;
        }

        private void Shift(int index)
        {
            for (int i = index; i < this.Count; i++)
            {
                this.items[index] = this.items[index + 1];
            }
        }

        public IEnumerator<T> GetEnumerator()
        {
            throw new NotImplementedException();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            throw new NotImplementedException();
        }
        private void Resize()
        {
            T[] copy = new T[this.items.Length * 2];
            for (int i = 0; i < this.items.Length; i++)
            {
                copy[i] = this.items[i];
            }
            this.items = copy;
        }

        private void ValidateRange(int index)
        {
            if (index >= this.Count)
            {
                throw new ArgumentOutOfRangeException();
            }
        }

    }
}