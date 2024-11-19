using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.ComponentModel;
using System.Xml.Linq;

namespace ConsoleApp1
{

    internal class MyHashMap<K, V>
    {
        private class Entry
        {
            public K Key { get; set; }
            public V Value { get; set; }
            public Entry Next { get; set; }

            public Entry(K key, V value)
            {
                Key = key;
                Value = value;
            }
        }

        private int GetHashCode(K key)
        {
            return Math.Abs(key.GetHashCode()) % size;
        }
        private int GetHashCode(V value)
        {
            return Math.Abs(value.GetHashCode()) % size;
        }

        Entry[] table;
        int size;
        float loadFactor;

        //1
        public MyHashMap()
        {
            table = new Entry[16];
            size = 16;
            loadFactor = 0.75f;

        }

        //2
        public MyHashMap(int initialCapacity)
        {
            table = new Entry[initialCapacity];
            size = table.Length;
            loadFactor = 0.75f;
        }

        //3
        public MyHashMap(int initialCapacity, float loadFactor)
        {
            table = new Entry[initialCapacity];
            size = table.Length;
            loadFactor = 0.75f;
        }

        //4
        public void Clear()
        {
            table = new Entry[16];
            size = table.Length;
            loadFactor = 0.75f;
        }

        //5
        public bool ContainsKey(object key)
        {
            int index = GetHashCode((K)key);
            Entry current = table[index];
            while(current != null)
            {
                if((object)current.Key == key)
                    return true;
                current = current.Next;
            }
            return false;
        }

        //6
        public bool ContainsValue(object value)
        {
            int index = GetHashCode((V)value);
            Entry current = table[index];
            while (current != null)
            {
                if ((object)current.Value == value)
                    return true;
                current = current.Next;
            }
            return false;
        }

        //7
        public HashSet<object> EntrySet()
        {
            HashSet<object> result = new HashSet<object>();
            foreach (Entry entry in table)
            {
                Entry current = entry;
                while (current != null)
                {
                    result.Add(current);
                }
            }
            return result;
        }

        //8
        public V Get(object key)
        {
            int index = GetHashCode((K)key);
            Entry current = (Entry)table[index];

            while (current != null)
            {
                if ((object)current.Key == key)
                {
                    return current.Value;
                }
                current = current.Next;
            }

            return default(V);
        }

        //9
        public bool IsEmpty()
        {
            return size == 0;
        }

        //10
        public HashSet<object> KeySet()
        {
            HashSet<object> result = new HashSet<object>();
            foreach (Entry entry in table)
            {
                Entry current = entry;
                while (current != null)
                {
                    result.Add(entry.Key);
                    current = current.Next;
                }
            }
            return result;
        }

        //11
        public void Put(K key, V value)
        {
            int index = GetHashCode(key);
            Entry current = (Entry)table[index];
            int bucket = index % size;
            Entry entry = table[bucket];

            if (entry == null)
            {
                table[bucket] = new Entry(key, value);
                size++;
                return;
            }

            while (entry != null)
            {
                if (entry.Key.Equals(key))
                {
                    entry.Value = value;
                    return;
                }
                if (entry.Next == null)
                {
                    break;
                }
                entry = entry.Next;
            }
            entry.Next = new Entry(key, value);
            size++;
        }

        //12
        public void Remove(object key)
        {
            int index = GetHashCode((K)key);

            if (table[index] == null)
                return;
            if (table[index].Key.Equals(key))
            {
                table[index] = table[index].Next;
                size--;
                return;
            }
            Entry current = table[index];
            Entry previous = null;
            while (current != null)
            {
                if (current.Key.Equals(key))
                {
                    previous.Next = current.Next;
                    size--;
                    return;
                }

                previous = current;
                current = current.Next;
            }
        }

        //13
        public int Size()
        {
            return size;
        }
    }
}
