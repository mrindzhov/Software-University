namespace LimitedMemory
{
    public class Pair<K, V>
    {
        public Pair(K key, V val)
        {
            this.Key = key;
            this.Value = val;
        }
        public K Key { get; set; }

        public V Value { get; set; }
    }
}
