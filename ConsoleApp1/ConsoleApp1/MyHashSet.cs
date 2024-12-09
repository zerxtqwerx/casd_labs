using System;
using System.Collections.Generic;

public class MyHashSet<T>
{
    private Dictionary<T, object> map;
    private static readonly object DummyValue = new object();
    private int initialCapacity;
    private float loadFactor;

    //1
    public MyHashSet() : this(16, 0.75f) { }

    //2
    public MyHashSet(T[] array) : this(16, 0.75f)
    {
        AddAll(array);
    }

    //3
    public MyHashSet(int initialCapacity) : this(initialCapacity, 0.75f) { }

    //4
    public MyHashSet(int initialCapacity, float loadFactor)
    {
        if (initialCapacity < 0) throw new ArgumentOutOfRangeException(nameof(initialCapacity));
        if (loadFactor <= 0 || float.IsNaN(loadFactor)) throw new ArgumentOutOfRangeException(nameof(loadFactor));

        this.initialCapacity = initialCapacity;
        this.loadFactor = loadFactor;
        map = new Dictionary<T, object>(initialCapacity);
    }
    //5
    public void Add(T e)
    {
        if (e == null) throw new ArgumentNullException(nameof(e));
        if (!map.ContainsKey(e))
        {
            map[e] = DummyValue;
        }
    }
    //6
    public void AddAll(T[] array)
    {
        if (array == null) throw new ArgumentNullException(nameof(array));
        foreach (var item in array)
        {
            Add(item);
        }
    }
    //7
    public void Clear()
    {
        map.Clear();
    }
    //8
    public bool Contains(object o)
    {
        if (o == null) throw new ArgumentNullException(nameof(o));
        return map.ContainsKey((T)o);
    }
    //9
    public bool ContainsAll(T[] array)
    {
        if (array == null) throw new ArgumentNullException(nameof(array));
        foreach (var item in array)
        {
            if (!Contains(item)) return false;
        }
        return true;
    }
    //10
    public bool IsEmpty()
    {
        return map.Count == 0;
    }
    //11
    public bool Remove(object o)
    {
        if (o == null) throw new ArgumentNullException(nameof(o));
        return map.Remove((T)o);
    }
    //12
    public void RemoveAll(T[] array)
    {
        if (array == null) throw new ArgumentNullException(nameof(array));
        foreach (var item in array)
        {
            Remove(item);
        }
    }
    //13
    public void RetainAll(T[] array)
    {
        if (array == null) throw new ArgumentNullException(nameof(array));
        var toRetain = new HashSet<T>(array);
        foreach (var key in new List<T>(map.Keys))
        {
            if (!toRetain.Contains(key))
            {
                map.Remove(key);
            }
        }
    }
    //14
    public int Size()
    {
        return map.Count;
    }
    //15
    public T[] ToArray()
    {
        T[] array = new T[Size()];
        map.Keys.CopyTo(array, 0);
        return array;
    }
    //16
    public T[] ToArray(T[] a)
    {
        if (a == null) return ToArray();
        if (a.Length < Size())
        {
            a = new T[Size()];
        }
        map.Keys.CopyTo(a, 0);
        return a;
    }
    //17
    public T First()
    {
        if (IsEmpty()) throw new InvalidOperationException("Set is empty");
        using (var enumerator = map.Keys.GetEnumerator())
        {
            enumerator.MoveNext();
            return enumerator.Current;
        }
    }
    //18
    public T Last()
    {
        if (IsEmpty()) throw new InvalidOperationException("Set is empty");
        using (var enumerator = map.Keys.GetEnumerator())
        {
            T lastElement = default(T);
            while (enumerator.MoveNext())
            {
                lastElement = enumerator.Current;
            }
            return lastElement;
        }
    }
    //19
    public MyHashSet<T> SubSet(T fromElement, T toElement)
    {
        var subset = new MyHashSet<T>();
        foreach (var item in map.Keys)
        {
            if (Comparer<T>.Default.Compare(item, fromElement) >= 0 && Comparer<T>.Default.Compare(item, toElement) < 0)
            {
                subset.Add(item);
            }
        }
        return subset;
    }
    //20
    public MyHashSet<T> HeadSet(T toElement)
    {
        var headSet = new MyHashSet<T>();
        foreach (var item in map.Keys)
        {
            if (Comparer<T>.Default.Compare(item, toElement) < 0)
            {
                headSet.Add(item);
            }
        }
        return headSet;
    }
    //21
    public MyHashSet<T> TailSet(T fromElement)
    {
        var tailSet = new MyHashSet<T>();
        foreach (var item in map.Keys)
        {
            if (Comparer<T>.Default.Compare(item, fromElement) >= 0)
            {
                tailSet.Add(item);
            }
        }
        return tailSet;
    }
}