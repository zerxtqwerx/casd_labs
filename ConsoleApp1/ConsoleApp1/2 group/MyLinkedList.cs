using ConsoleApp1;
using System;
using System.Xml;

public class MyLinkedList<T> : IMyCollection2<T>, MyList<T>
{
    private Node<T> first;
    private Node<T> last;
    private int size;

    private class Node<T>
    {
        public T Value;
        public Node<T> Next;
        public Node<T> Previous;

        public Node(T value)
        {
            Value = value;
            Next = null;
            Previous = null;
        }
    }

    //1
    public MyLinkedList()
    {
        first = null;
        last = null;
        size = 0;
    }
    //2
    public MyLinkedList(T[] a)
    {
        for (int i = 0; i < a.Length; i++)
        {
            Add(a[i]);
        }
    }
    //3
    public void Add(T e)
    {
        Node<T> newNode = new Node<T>(e);

        if (size == 0)
        {
            first = newNode;
            last = newNode;
        }
        else
        {
            last.Next = newNode;
            newNode.Previous = last;
            last = newNode;
        }
        size++;
    }
    //4
    public void AddAll(T[] a)
    {
        foreach (T item in a)
        {
            Add(item);
        }
    }
    //5
    public void Clear()
    {
        Node<T> node = first;
        while (node != null)
        {
            Node<T> temp = node;
            node = node.Next;
            temp.Value = (T)(default);
            temp.Next = null;
            temp.Previous = null;
        }
        first = null;
        last = null;
        size = 0;
    }
    //6
    public bool Contains(object o)
    {
        Node<T> node = first;
        while (node != null)
        {
            if (Equals(node.Value, o)) return true;
            node = node.Next;
        }
        return false;
    }
    //7
    public bool ContainsAll(T[] a)
    {
        foreach (T item in a)
        {
            if (!Contains(item))
                return false;
        }
        return true;
    }
    //8
    public bool IsEmpty()
    {
        return size == 0;
    }
    //9
    public void Remove(object o)
    {
        Node<T> node = first;
        bool flag = false;
        while (node != null)
        {
            if (Equals(node.Value, o))
            {

                Node<T> newNode = node.Next;
                //newNode.Next = node.Next.Next;
                //newNode.Previous = node.Previous;

                node.Previous.Next = node.Next;
                node.Next.Previous = node.Previous;

                node.Value = (T)(default);
                node.Next = null;
                node.Previous = null;
                node = newNode;
                flag = true;

                if (IndexOf(o) == 0)
                {
                    first = newNode;
                }
                if (LastIndexOf(o) == size - 1)
                {
                    last = node;
                }
            }
        }
    }
    //10
    public void RemoveAll(T[] a)
    {
        foreach (T item in a)
        {
            Remove(item);
        }
    }
    //11
    public void RetainAll(T[] a)
    {
        Node<T> node = first;
        while (node != null)
        {
            if (!Contains(node.Value))
            {
                Remove(node.Value);
            }
        }
    }
    //12
    public int Size()
    {
        return size;
    }
    //13
    public T[] ToArray()
    {
        Node<T> node = first;
        T[] newArray = new T[size];
        for (int i = 0; i < size; i++)
        {
            newArray[i] = node.Value;
            node = node.Next;
        }
        return newArray;
    }
    //14
    public T[] ToArray(T[] a)
    {
        Node<T> node = first;
        if (a == null || a.Length < size)
        {
            return ToArray();
        }
        for (int i = 0; i < size; i++)
        {
            a[i] = node.Value;
            node = node.Next;
        }
        if (a.Length > size)
        {
            a[size] = default;
        }
        return a;
    }
    //15
    public void Add(int index, T e)
    {
        Node<T> node = first;
        for (int i = 0; i < size; i++)
        {
            if (i == index)
            {
                Node<T> newNode = new Node<T>(e);
                newNode.Next = node;
                newNode.Previous = node.Previous;
                last = newNode;
                size++;
            }
            node = node.Next;
        }
    }

    //16 
    public void AddAll(int index, T[] a)
    {
        for (int i = 0; i < a.Length; i++)
        {
            Add(index + i, a[i]);
        }
    }

    //17
    public T Get(int index)
    {
        Node<T> node = first;
        for (int i = 0; i < size; i++)
        {
            if (i == index) { return node.Value; }
            node = node.Next;
        }
        return default(T);
    }

    //18
    public int IndexOf(object o)
    {
        Node<T> node = first;
        for (int index = 0; index < size; index++)
        {
            if (Equals(o, node.Value))
                return index;
            node = node.Next;
        }
        return -1;
    }

    //19
    public int LastIndexOf(object o)
    {
        Node<T> node = last;
        for (int index = size - 1; index != 0; index--)
        {
            if (Equals(o, node.Value))
                return index;
            node = node.Previous;
        }
        return -1;
    }

    //20 
    public void Remove(int index)
    {
        T t = Get(index);
        Remove(t);
    }

    //21
    public T Set(int index, T e)
    {
        Node<T> node = first;
        for (int i = 0; i < size; i++)
        {
            if (i == index)
            {
                node.Value = e;
                break;
            }
            node = node.Next;
        }
        return node.Value;
    }

    //22
    public MyLinkedList<T> SubList(int fromIndex, int toIndex)
    {
        MyLinkedList<T> newList = new MyLinkedList<T>();
        for (int i = fromIndex; i < toIndex; i++)
        {
            T t = Get(i);
            newList.Add(t);
        }
        return newList;
    }

    //23
    public T Element()
    {
        if (IsEmpty())
            throw new InvalidOperationException("Deque is empty.");
        return first.Value;
    }
    //24
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
    //25
    public T Peek()
    {
        return IsEmpty() ? (T)(default) : Element();
    }
    //26
    public T Poll()
    {
        if (IsEmpty())
            return default(T);
        T item = Element();
        Remove(item);
        return item;
    }

    //27
    public void AddFirst(T obj)
    {
        Add(0, obj);
    }
    //28
    public void AddLast(T obj)
    {
        Add(obj);
    }
    //29
    public T GetFirst()
    {
        return Element();
    }
    //30
    public T GetLast()
    {
        if (IsEmpty())
            throw new InvalidOperationException("Deque is empty.");
        return Get(size - 1);
    }
    //31
    public bool OfferFirst(T obj)
    {
        try
        {
            AddFirst(obj);
            return true;
        }
        catch { return false; }
    }
    //32
    public bool OfferLast(T obj)
    {
        return Offer(obj);
    }
    //33
    public T Pop()
    {
        return Poll();
    }
    //34
    public void Push(T obj)
    {
        AddFirst(obj);
    }

    //35
    public T PeekFirst()
    {
        return Peek();
    }
    //36
    public T PeekLast()
    {
        if (IsEmpty())
            return default(T);
        return GetLast();
    }
    //37
    public T PollFirst()
    {
        return Poll();
    }
    //38
    public T PollLast()
    {
        if (IsEmpty())
            return default(T);
        T item = Get(size - 1);
        Remove(size - 1);
        return item;
    }
    //39
    public T RemoveLast()
    {
        return PollLast();
    }
    //40
    public T RemoveFirst()
    {
        return Poll();
    }
    //41
    public bool RemoveLastOccurrence(T obj)
    {
        try
        {
            int index = LastIndexOf(obj);
            Remove(index);
            return true;
        }

        catch { return false; }
    }
    //42
    public bool RemoveFirstOccurrence(T obj)
    {
        try
        {
            int index = IndexOf(obj);
            Remove(index);
            return true;
        }

        catch { return false; }
    }

    private bool MoveNext(ref int index)
    {
        if (index < size - 1)
        {
            index++;
            return true;
        }
        return false;
    }

    private void Reset(ref int index) => index = -1;

    public MyIterator2<T> ListIterator()
    {   return new MyItr2<T>(this); //, (list) => list.Get, (list) => list.MoveNext, (list) => list.Reset);
    }

    public MyIterator2<T> ListIterator(int index)
    {
        MyIterator2<T> iterator = ListIterator();
        try
        {
            while (iterator.NextIndex() != index + 1)
                iterator.Next();
            return iterator;
        }
        catch (Exception e)
        {
            throw new Exception(Convert.ToString(e));
        }
    }
    public class MyItr2<T> : MyIterator2<T>
    {
        private MyLinkedList<T> list;
        private int cursor = -1;

        public MyItr2(MyLinkedList<T> list)
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
            return list.Get(cursor);
        }

        public bool HasPrevious()
        {
            return cursor > 0;
        }

        public T Previous()
        {
            if (!HasPrevious())
                throw new InvalidOperationException("Нет предыдущего элемента.");

            cursor--;
            return list.Get(cursor);
        }

        public int NextIndex()
        {
            return cursor + 1;
        }

        public int PreviousIndex()
        {
            return cursor - 1;
        }

        public void Remove()
        {
            if (cursor < 0 || cursor >= list.Size())
                throw new InvalidOperationException("Индекс вне массива.");


            for (int i = cursor; i < list.Size() - 1; i++)
            {
                list.Set(i, list.Get(i + 1));
            }
            cursor--;
        }

        public void Set(T element)
        {
            if (cursor < 0 || cursor >= list.Size())
                throw new InvalidOperationException("Индекс вне массива.");

            list.Set(cursor, element);
        }

        public void Add(T element)
        {

            list.Add(default);
            for (int i = list.Size() - 1; i > cursor; i--)
            {
                list.Set(i, list.Get(i - 1));
            }
            list.Set(cursor + 1, element);
            cursor++;
        }
    }
}
