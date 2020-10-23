using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdvancedDataStructureProblems
{
    public class Entry<K, V>
    {
        public int hash;
        K key;
        V value;

        public Entry(K key, V value)
        {
            this.key = key;
            this.value = value;
        }

        public int CaptureHashCode(K key)
        {
            hash = key.GetHashCode();
            return hash;
        }

        public bool equals(Entry<K, V> other)
        {
            if (hash != other.hash) return false;
            return key.Equals(other.key);
        }
    }
    public class HashTableSeparateChaining<K, V>
    {
        private const int DEFAULT_CAPACITY = 3;
        private const double DEFAULT_LOAD_FACTOR = 0.75;
        private double maxLoadFactor;
        private int capacity, threshold, size = 0;
        private LinkedList<Entry<K, V>>[] table;

        public HashTableSeparateChaining()
        {

        }

        public HashTableSeparateChaining(int capacity)
        {
            this.capacity = capacity;
        }

        public HashTableSeparateChaining(int capacity, double maxLoadFactor)
        {
            if (capacity < 0) throw new ArgumentOutOfRangeException("Illigal Capacity");
            if (maxLoadFactor <= 0 || double.IsNaN(maxLoadFactor) || double.IsInfinity(maxLoadFactor))
                throw new ArgumentException("Illigal maxLoadFactor");
            this.maxLoadFactor = maxLoadFactor;
            this.capacity = capacity;
            threshold = (int)(this.capacity * maxLoadFactor);
            table = new LinkedList<Entry<K, V>>[this.capacity];
        }
        private int normalizeIndex(int keyHash)
        {
            return (keyHash & 0x7FFFFFFF) % capacity;
        }
        //Insert, put and add all place a value in the has-table
        public V put(K key, V value)
        {
            return insert(key, value);
        }
        public V add(K key, V value)
        {
            return insert(key, value);
        }
        public V insert(K key, V value)
        {
            if (key == null) throw new ArgumentException("Null Key");
            Entry<K, V> newEntry = new Entry<K, V>(key, value);
            int bucketIndex = normalizeIndex(newEntry.CaptureHashCode(key));

        }
    }
}
