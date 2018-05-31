using System.Collections.Generic;
using System.Collections;
using System.Linq;
using System;

namespace LimitedMemory
{
    public class LimitedMemoryCollection<K, V> : ILimitedMemoryCollection<K, V>
    {
        private LinkedList<Pair<K, V>> orderPrior;
        private Dictionary<K, LinkedListNode<Pair<K, V>>> elements;

        public int Capacity { get; }

        public int Count { get { return this.elements.Count; } }

        public LimitedMemoryCollection(int capacity)
        {
            this.orderPrior = new LinkedList<Pair<K, V>>();
            this.Capacity = capacity;
            this.elements = new Dictionary<K, LinkedListNode<Pair<K, V>>>();
        }

        public IEnumerator<Pair<K, V>> GetEnumerator()
        {
            return this.orderPrior.GetEnumerator();

        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return this.GetEnumerator();
        }

        public void Set(K key, V value)
        {
            if (this.elements.ContainsKey(key))
            {
                var pair = this.elements[key];
                UpdatePriority(pair);
                pair.Value.Value = value;
            }
            else
            {
                if (this.elements.Count >= this.Capacity)
                {
                    RemoveOldest();
                }
                AddElement(key, value);
            }
        }

        private void UpdatePriority(LinkedListNode<Pair<K, V>> pair)
        {
            this.orderPrior.Remove(pair);
            this.orderPrior.AddFirst(pair);
        }

        private void RemoveOldest()
        {
            var node = this.orderPrior.Last;
            this.orderPrior.RemoveLast();
            this.elements.Remove(node.Value.Key);
        }

        private void AddElement(K key, V value)
        {
            LinkedListNode<Pair<K, V>> pair = new LinkedListNode<Pair<K, V>>(new Pair<K, V>(key, value));
            this.elements.Add(key, pair);
            this.orderPrior.AddFirst(pair);
        }

        public V Get(K key)
        {
            if (!this.elements.ContainsKey(key))
            {
                throw new KeyNotFoundException();
            }
            UpdatePriority(this.elements[key]);
            return this.elements[key].Value.Value;
        }
    }
}
