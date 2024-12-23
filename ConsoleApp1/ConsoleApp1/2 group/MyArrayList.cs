using System;
using System.Collections;
using System.Collections.Generic;

namespace ConsoleApp1
{
    public class MyArrayList<T> : IMyCollection2<T>, MyList<T>
    {
        private T[] elementData; //1
        private int size;        //2

        //1
        public MyArrayList()
        {
            elementData = new T[10];
            size = 0;
        }

        //2
        public MyArrayList(T[] a)
        {
            elementData = new T[a.Length];
            Array.Copy(a, elementData, a.Length);
            size = a.Length;
        }

        //3
        public MyArrayList(int capacity)
        {
            if (capacity < 0)
                throw new ArgumentOutOfRangeException(nameof(capacity), "Ёмкость не может быть отрицательной.");
            elementData = new T[capacity];
            size = 0;
        }

        //4
        public void Add(T e)
        {
            if (size == elementData.Length)
            {
                Resize(elementData.Length * 3 / 2 + 1);
            }
            elementData[size++] = e;
        }

        //5
        public void AddAll(T[] a)
        {
            foreach (T e in a)
            {
                Add(e);
            }
        }

        //6
        public void Clear()
        {
            Array.Clear(elementData, 0, size);
            size = 0;
        }

        //7
        public bool Contains(object o)
        {
            for (int i = 0; i < size; i++)
            {
                if (elementData[i]?.Equals(o) == true)
                {
                    return true;
                }
            }
            return false;
        }

        //8
        public bool ContainsAll(T[] a)
        {
            foreach (T e in a)
            {
                if (!Contains(e))
                {
                    return false;
                }
            }
            return true;
        }

        private void Resize(int newCapacity)
        {
            T[] newArray = new T[newCapacity];
            Array.Copy(elementData, newArray, size);
            elementData = newArray;
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
                if (Equals(elementData[i], o))
                {
                    Remove(i);
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
                if (Array.IndexOf(a, elementData[i]) == -1)
                {
                    Remove(i);
                }
            }
        }
        public int Size()
        { return size; }

        //14
        public T[] ToArray()
        {
            T[] result = new T[size];
            Array.Copy(elementData, result, size);
            return result;
        }
        //15
        public T[] ToArray(T[] a)
        {
            if (a == null || a.Length < size)
            {
                a = new T[size];
            }
            Array.Copy(elementData, a, size);
            return a;
        }

        //16
        public void Add(int index, T e)
        {
            if (index < 0 || index > size)
            {
                throw new IndexOutOfRangeException("Индекс вне диапазона");
            }
            EnsureCapacity(size + 1);
            for (int i = size; i > index; i--)
            {
                elementData[i] = elementData[i - 1];
            }
            elementData[index] = e;
            size++;
        }

        //17
        public void AddAll(int index, T[] a)
        {
            if (index < 0 || index > size)
            {
                throw new IndexOutOfRangeException("Индекс вне диапазона");
            }
            EnsureCapacity(size + a.Length);
            for (int i = size - 1; i >= index; i--)
            {
                elementData[i + a.Length] = elementData[i];
            }
            for (int j = 0; j < a.Length; j++)
            {
                elementData[index + j] = a[j];
            }
            size += a.Length;
        }

        //18
        public T Get(int index)
        {
            if (index < 0 || index >= size)
            {
                throw new IndexOutOfRangeException("Индекс вне диапазона");
            }
            return elementData[index];
        }

        //19
        public int IndexOf(object o)
        {
            for (int i = 0; i < size; i++)
            {
                if (Equals(elementData[i], o))
                {
                    return i;
                }
            }
            return -1;
        }

        //20
        public int LastIndexOf(object o)
        {
            for (int i = size - 1; i >= 0; i--)
            {
                if (Equals(elementData[i], o))
                {
                    return i;
                }
            }
            return -1;
        }
        //21
        public void Remove(int index)
        {
            if (index < 0 || index >= size)
            {
                throw new IndexOutOfRangeException("Индекс вне диапазона");
            }
            T removedElement = elementData[index];
            for (int i = index; i < size - 1; i++)
            {
                elementData[i] = elementData[i + 1];
            }
            elementData[size - 1] = default(T);
            size--;
        }
        //22
        public T Set(int index, T e)
        {
            if (index < 0 || index >= size)
            {
                throw new IndexOutOfRangeException("Индекс вне диапазона");
            }
            T oldElement = elementData[index];
            elementData[index] = e;
            return oldElement;
        }

        private void EnsureCapacity(int min)
        {
            if (elementData.Length < min)
            {
                int newCapacity = elementData.Length * 2;
                if (newCapacity < min) newCapacity = min;
                T[] newArray = new T[newCapacity];
                Array.Copy(elementData, newArray, size);
                elementData = newArray;
            }
        }

        //23
        public MyArrayList<T> SubList(int fromIndex, int toIndex)
        {
            if (fromIndex < 0 || toIndex > size || fromIndex >= toIndex)
                throw new ArgumentOutOfRangeException("Неверные индексы для подсписка");

            MyArrayList<T> sublist = new MyArrayList<T>();
            for (int i = fromIndex; i < toIndex; i++)
            {
                sublist.Add(elementData[i]);
            }
            return sublist;
        }

        
        //Iterator
        public MyIterator2<T> ListIterator()
        {
            return new MyItr2<T>(this);
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
    }

}
   
