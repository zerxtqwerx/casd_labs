using System;
using System.Collections.Generic;
using ConsoleApp1;

public class MyHashMap<K, V>
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
            Next = null;
        }
    }

    private Entry[] table;
    private int size;
    private float loadFactor;
    private int threshold;

    public MyHashMap() : this(16, 0.75f) { }

    public MyHashMap(int initialCapacity) : this(initialCapacity, 0.75f) { }

    public MyHashMap(int initialCapacity, float loadFactor)
    {
        if (initialCapacity < 1) throw new ArgumentOutOfRangeException("initialCapacity");
        if (loadFactor <= 0) throw new ArgumentOutOfRangeException("loadFactor");

        this.loadFactor = loadFactor;
        table = new Entry[initialCapacity];
        threshold = (int)(initialCapacity * loadFactor);
        size = 0;
    }

    public void Clear()
    {
        Array.Clear(table, 0, table.Length);
        size = 0;
    }


    public bool ContainsKey(K key)
    {
        return GetEntry(key) != null;
    }

    public bool ContainsValue(V value)
    {
        foreach (var entry in table)
        {
            var current = entry;
            while (current != null)
            {
                if (current.Value.Equals(value)) return true;
                current = current.Next;
            }
        }
        return false;
    }

    public HashSet<KeyValuePair<K, V>> EntrySet()
    {
        var set = new HashSet<KeyValuePair<K, V>>();
        foreach (var entry in table)
        {
            var current = entry;
            while (current != null)
            {
                set.Add(new KeyValuePair<K, V>(current.Key, current.Value));
                current = current.Next;
            }
        }
        return set;
    }

    public V Get(K key)
    {
        var entry = GetEntry(key);
        return entry == null ? default(V) : entry.Value;
    }

    public bool IsEmpty()
    {
        return size == 0;
    }

    public HashSet<K> KeySet()
    {
        var set = new HashSet<K>();
        foreach (var entry in table)
        {
            var current = entry;
            while (current != null)
            {
                set.Add(current.Key);
                current = current.Next;
            }
        }
        return set;
    }

    public void Put(K key, V value)
    {
        if (size >= threshold)
        {
            Resize();
        }

        int index = GetBucketIndex(key);
        Entry current = table[index];

        while (current != null)
        {
            if (current.Key.Equals(key))
            {
                current.Value = value;
                return;
            }
            current = current.Next;
        }

        Entry newEntry = new Entry(key, value);
        newEntry.Next = table[index];
        table[index] = newEntry;
        size++;
    }

    public V Remove(K key)
    {
        int index = GetBucketIndex(key);
        Entry current = table[index];
        Entry previous = null;

        while (current != null)
        {
            if (current.Key.Equals(key))
            {
                if (previous == null)
                {
                    table[index] = current.Next;
                }
                else
                {
                    previous.Next = current.Next;
                }
                size--;
                return current.Value;
            }
            previous = current;
            current = current.Next;
        }
        return default(V);
    }

    public int Size()
    {
        return size;
    }

    private int GetBucketIndex(K key)
    {
        int hashCode = key.GetHashCode();
        return (hashCode & 0x7FFFFFFF) % table.Length;
    }

    private Entry GetEntry(K key)
    {
        int index = GetBucketIndex(key);
        Entry current = table[index];

        while (current != null)
        {
            if (current.Key.Equals(key))
            {
                return current;
            }
            current = current.Next;
        }
        return null;
    }

    private void Resize()
    {
        int newCapacity = table.Length * 2;
        Entry[] newTable = new Entry[newCapacity];

        foreach (var entry in table)
        {
            var current = entry;
            while (current != null)
            {
                int newIndex = (current.Key.GetHashCode() & 0x7FFFFFFF) % newCapacity;
                Entry next = current.Next;

                current.Next = newTable[newIndex];
                newTable[newIndex] = current;

                current = next;
            }
        }

        table = newTable;
        threshold = (int)(newCapacity * loadFactor);
    }

}
