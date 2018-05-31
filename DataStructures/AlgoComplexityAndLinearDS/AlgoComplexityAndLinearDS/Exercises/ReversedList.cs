using System;
using System.Collections;
using System.Collections.Generic;

namespace AlgoComplexityAndLinearDS.Exercises
{
    public class ReversedList<T> : IEnumerable<T>
    {
        public int Count { get; private set; }
        public int Capacity
        {
            get
            {
                return this.items.Length;
            }
            private set
            {
                this.Capacity = value;
            }
        }
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
                T[] reversedArr = GetReversedArray(items);
                return reversedArr[index];
            }
            set
            {
                ValidateRange(index);
                T[] reversedArr = GetReversedArray(items);
                reversedArr[index] = value;
            }
        }

        private T[] GetReversedArray(T[] items)
        {
            T[] newArr = new T[this.items.Length];
            Array.Copy(items, newArr, this.items.Length);
            Array.Reverse(newArr);
            return newArr;
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
            T[] reversedArr = GetReversedArray(items);
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
            for (int i = items.Length - 1; i >= 0; i--)
            {
                yield return items[i];
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return this.GetEnumerator();
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
            if (index >= this.Count && index < 0)
            {
                throw new ArgumentOutOfRangeException();
            }
        }

    }
}