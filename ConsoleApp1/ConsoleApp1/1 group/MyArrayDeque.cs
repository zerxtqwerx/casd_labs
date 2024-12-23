using ConsoleApp1;
using System;

public class MyArrayDeque<T> : IMyCollection1<T>, MyDeque<T>
{
    private T[] elements;
    private int head;
    private int tail;
    private int size;

    private const int DEFAULT_CAPACITY = 16;

    //1
    public MyArrayDeque()
    {
        elements = new T[DEFAULT_CAPACITY];
        head = 0;
        tail = 0;
        size = 0;
    }
    //2
    public MyArrayDeque(T[] a)
    {
        elements = new T[Math.Max(a.Length, DEFAULT_CAPACITY)];
        Array.Copy(a, 0, elements, head, a.Length);
        tail = a.Length;
        size = a.Length;
    }
    //3
    public MyArrayDeque(int numElements)
    {
        if (numElements <= 0)
            throw new ArgumentException("Capacity must be greater than zero.");

        elements = new T[numElements];
        head = 0;
        tail = 0;
        size = 0;
    }
    //4
    public void Add(T e)
    {
        EnsureCapacity(size + 1);
        elements[tail] = e;
        tail = (tail + 1) % elements.Length;
        size++;
    }
    //5
    public void AddAll(T[] a)
    {
        foreach (T item in a)
        {
            Add(item);
        }
    }
    //6
    public void Clear()
    {
        head = 0;
        tail = 0;
        size = 0;
    }
    //7
    public bool Contains(object o)
    {
        for (int i = 0; i < size; i++)
        {
            if (elements[(head + i) % elements.Length]?.Equals(o) == true)
            {
                return true;
            }
        }
        return false;
    }
    //8
    public bool ContainsAll(T[] a)
    {
        foreach (T item in a)
        {
            if (!Contains(item))
                return false;
        }
        return true;
    }
    //9
    public bool IsEmpty()
    {
        return size == 0;
    }
    //10
    public void Remove(object o)
    {
        for (int i = 0; i < size; i++)
        {
            int index = (head + i) % elements.Length;
            if (elements[index]?.Equals(o) == true)
            {
                RemoveAt(index);
               
            }
        }
    }
    //11
    public void RemoveAll(T[] a)
    {
        foreach (T item in a)
        {
            Remove(item);
        }
    }
    //12
    public void RetainAll(T[] a)
    {
        for (int i = size - 1; i >= 0; i--)
        {
            if (!Array.Exists(a, e => e.Equals(elements[(head + i) % elements.Length])))
            {
                RemoveAt((head + i) % elements.Length);
            }
        }
    }
    //13
    public int Size()
    {
        return size;
    }
    //14
    public T[] ToArray()
    {
        T[] newArray = new T[size];
        for (int i = 0; i < size; i++)
        {
            newArray[i] = elements[(head + i) % elements.Length];
        }
        return newArray;
    }
    //15
    public T[] ToArray(T[] a)
    {
        if (a == null || a.Length < size)
        {
            return ToArray();
        }
        for (int i = 0; i < size; i++)
        {
            a[i] = elements[(head + i) % elements.Length];
        }
        if (a.Length > size)
        {
            a[size] = default;
        }
        return a;
    }
    //16
    public T Element()
    {
        if (IsEmpty())
            throw new InvalidOperationException("Deque is empty.");
        return elements[head];
    }
    //17
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
    //18
    public T Peek()
    {
        return IsEmpty() ? default(T) : elements[head];
    }
    //19
    public T Poll()
    {
        if (IsEmpty())
            return default(T);
        T item = elements[head];
        head = (head + 1) % elements.Length;
        size--;
        return item;
    }
    //20
    public void AddFirst(T obj)
    {
        EnsureCapacity(size + 1);
        head = (head - 1 + elements.Length) % elements.Length;
        elements[head] = obj;
        size++;
    }
    //21
    public void AddLast(T obj)
    {
        Add(obj);
    }
    //22
    public T GetFirst()
    {
        return Element();
    }
    //23
    public T GetLast()
    {
        if (IsEmpty())
            throw new InvalidOperationException("Deque is empty.");
        return elements[(tail - 1 + elements.Length) % elements.Length];
    }
    //24
    public bool OfferFirst(T obj)
    {
        if (size >= elements.Length) return false;
        AddFirst(obj);
        return true;
    }
    //25
    public bool OfferLast(T obj)
    {
        return Offer(obj);
    }
    //26
    public T Pop()
    {
        return Poll();
    }
    //27 //
    public void Push(T obj)
    {
        EnsureCapacity(size + 1);
        head = (head - 1 + elements.Length) % elements.Length;
        elements[head] = obj;
        size++;
    }

    //28
    public T PeekFirst()
    {
        return Peek();
    }
    //29
    public T PeekLast()
    {
        if (IsEmpty())
            return default(T);
        return elements[(tail - 1 + elements.Length) % elements.Length];
    }
    //30
    public T PollFirst()
    {
        return Poll();
    }
    //31
    public T PollLast()
    {
        if (IsEmpty())
            return default(T);

        tail = (tail - 1 + elements.Length) % elements.Length;
        T item = elements[tail];
        elements[tail] = default(T);
        size--;
        return item;
    }
    //32
    public T RemoveLast()
    {
        return PollLast();
    }
    //33
    public T RemoveFirst()
    {
        return Poll();
    }
    //34
    public bool RemoveLastOccurrence(object obj)
    {
        for (int i = size - 1; i >= 0; i--)
        {
            int index = (head + i) % elements.Length;
            if (elements[index]?.Equals(obj) == true)
            {
                RemoveAt(index);
                return true;
            }
        }
        return false;
    }
    //35
    public bool RemoveFirstOccurrence(object obj)
    {
        for (int i = 0; i < size; i++)
        {
            int index = (head + i) % elements.Length;
            if (elements[index]?.Equals(obj) == true)
            {
                RemoveAt(index);
                return true;
            }
        }
        return false;
    }

    private void EnsureCapacity(int minCapacity)
    {
        if (minCapacity > elements.Length)
        {
            int newCapacity = elements.Length * 2;
            T[] newElements = new T[newCapacity];
            for (int i = 0; i < size; i++)
            {
                newElements[i] = elements[(head + i) % elements.Length];
            }
            elements = newElements;
            head = 0;
            tail = size;
        }
    }

    private void RemoveAt(int index)
    {
        int actualIndex = (head + index) % elements.Length;
        for (int i = index; i < size - 1; i++)
        {
            int nextIndex = (head + i + 1) % elements.Length;
            elements[actualIndex] = elements[nextIndex];
            actualIndex = nextIndex;
        }
        elements[(head + size - 1) % elements.Length] = default(T);
        size--;
        tail = (tail - 1 + elements.Length) % elements.Length;
    }
    public MyIterator1<T> Iterator()
    {
        return new MyItr1<T>(this);
    }
}