using System;
using System.Collections.Generic;
using ConsoleApp1;

public class MyPriorityQueue<T>
{
    private T[] queue;
    private int size;
    private IComparer<T> comparator;

    //1
    public MyPriorityQueue() : this(11, null) { }

    //2
    public MyPriorityQueue(T[] a)
    {
        queue = new T[a.Length];
        Array.Copy(a, queue, a.Length);
        size = a.Length;
        comparator = Comparer<T>.Default;
        BuildHeap();
    }

    //3
    public MyPriorityQueue(int initialCapacity) : this(initialCapacity, null) { }

    //4
    public MyPriorityQueue(int initialCapacity, IComparer<T> comparator)
    {
        this.queue = new T[initialCapacity];
        this.size = 0;
        this.comparator = comparator ?? Comparer<T>.Default;
    }

    //5
    public MyPriorityQueue(MyPriorityQueue<T> c)
    {
        queue = new T[c.size];
        Array.Copy(c.queue, queue, c.size);
        size = c.size;
        comparator = c.comparator;
        BuildHeap();
    }

    private void BuildHeap()
    {
        for (int i = size / 2 - 1; i >= 0; i--)
        {
            Heapify(i);
        }
    }

    private void Heapify(int index)
    {
        int left = LeftChild(index);
        int right = RightChild(index);
        int extreme = index;

        if (left < size && Compare(queue[left], queue[extreme]) < 0)
            extreme = left;
        if (right < size && Compare(queue[right], queue[extreme]) < 0)
            extreme = right;

        if (extreme != index)
        {
            Swap(index, extreme);
            Heapify(extreme);
        }
    }

    private int LeftChild(int index) => 2 * index + 1;
    private int RightChild(int index) => 2 * index + 2;

    private void Swap(int i, int j)
    {
        T temp = queue[i];
        queue[i] = queue[j];
        queue[j] = temp;
    }

    private int Compare(T x, T y) => comparator.Compare(x, y);

    //6
    public void Add(T e)
    {
        if (size >= queue.Length)
            Resize();

        queue[size] = e;
        size++;
        HeapifyUp(size - 1);
    }

    private void HeapifyUp(int index)
    {
        while (index > 0)
        {
            int parent = (index - 1) / 2;
            if (Compare(queue[parent], queue[index]) <= 0) break;
            Swap(parent, index);
            index = parent;
        }
    }

    private void Resize()
    {
        int newCapacity = queue.Length < 64 ? queue.Length + 2 : (int)(queue.Length * 1.5);
        Array.Resize(ref queue, newCapacity);
    }

    //7
    public void AddAll(T[] a)
    {
        foreach (var item in a)
        {
            Add(item);
        }
    }

    //8
    public void Clear()
    {
        queue = new T[queue.Length];
        size = 0;
    }

    //9
    public bool Contains(object o)
    {
        if (o is T item)
        {
            for (int i = 0; i < size; i++)
            {
                if (queue[i].Equals(item))
                    return true;
            }
        }
        return false;
    }

    //10
    public bool ContainsAll(T[] a)
    {
        foreach (var item in a)
        {
            if (!Contains(item)) return false;
        }
        return true;
    }

    //11
    public bool IsEmpty() => size == 0;

    //12
    public bool Remove(object o)
    {
        if (o is T item)
        {
            for (int i = 0; i < size; i++)
            {
                if (queue[i].Equals(item))
                {
                    RemoveAt(i);
                    return true;
                }
            }
        }
        return false;
    }

    private void RemoveAt(int index)
    {
        if (index < 0 || index >= size)
            throw new ArgumentOutOfRangeException(nameof(index));

        queue[index] = queue[size - 1];
        size--;
        Heapify(index);
    }

    public void RemoveAll(T[] a)
    {
        foreach (var item in a)
        {
            Remove(item);
        }
    }

    //14
    public void RetainAll(T[] a)
    {
        HashSet<T> toRetain = new HashSet<T>(a);
        for (int i = 0; i < size; i++)
        {
            if (!toRetain.Contains(queue[i]))
            {
                RemoveAt(i);
                i--;
            }
        }
    }

    //15//

    public int Size() => size;

    //16
    public T[] ToArray()
    {
        T[] result = new T[size];
        Array.Copy(queue, result, size);
        return result;
    }

    //17
    public T[] ToArray(T[] a)
    {
        if (a == null || a.Length < size)
            a = new T[size];
        Array.Copy(queue, a, size);
        return a;
    }

    //18
    public T Element()
    {
        if (IsEmpty())
            throw new InvalidOperationException("Priority queue is empty.");
        return queue[0];
    }

    //19
    public bool Offer(T obj)
    {
        try
        {
            Add(obj);
            return true;
        }
        catch
        {
            return false;
        }
    }

    //20
    public T Peek()
    {
        if (IsEmpty())
            return default(T);
        return queue[0];
    }

    //21
    public T Poll()
    {
        if (IsEmpty())
            return default(T);
        T result = queue[0];
        RemoveAt(0);
        return result;
    }
    public MyIterator1<T> Iterator()
    {
        return new MyItr1<T>(this);
    }

    public class MyItr1<T> : MyIterator1<T>
    {
        private MyPriorityQueue<T> list;
        private int cursor = -1;

        public MyItr1(MyPriorityQueue<T> list)
        {
            this.list = list;
        }

        public bool HasNext()
        {
            return cursor + 1 < list.Size();
        }

        public T Next()
        {
            if (!HasNext())
                throw new InvalidOperationException("Нет следующего элемента.");

            cursor++;
            return list.Peek();
        }

        public void Remove()
        {
            list.Poll();
            cursor--;
        }
    }
}

