using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{

    public class MyVector<T> : IEnumerable<T>
    {
        private T[] elementData;        //1
        private int elementCount;       //2
        private int capacityIncrement;  //3

        //1
        public MyVector(int initialCapacity, int capacityIncrement)
        {
            elementCount = initialCapacity;
            this.capacityIncrement = capacityIncrement;
        }

        //2
        public MyVector(int intitialCapacity)
        {
            if (intitialCapacity < 0)
                throw new ArgumentOutOfRangeException(nameof(intitialCapacity), "Ёмкость не может быть отрицательной.");
            elementData = new T[intitialCapacity];
            elementCount = 0;
            capacityIncrement = 0;
        }
        //3
        public MyVector()
        {
            elementData = new T[10]; // Начальный размер массива
            elementCount = 0;
            capacityIncrement = 0;
        }

        //4
        public MyVector(T[] a)
        {
            elementData = new T[a.Length];
            for(int i = 0; i < a.Length; i++)
            {
                elementData[i] = a[i];
            }
            capacityIncrement = 0;
        }

        //5
        public void Add(T e)
        {
            if (elementCount == elementData.Length)
            {
                if(capacityIncrement != 0)
                    Resize(elementData.Length + capacityIncrement);
                else
                    Resize(elementData.Length * 2);
            }
            elementData[elementCount++] = e;
        }

        //6
        public void AddAll(T[] a)
        {
            foreach (T e in a)
            {
                Add(e);
            }
        }

        //7
        public void Clear()
        {
            Array.Clear(elementData, 0, elementCount);
            elementCount = 0;
        }

        //8
        public bool Contains(object o)
        {
            for (int i = 0; i < elementCount; i++)
            {
                if (elementData[i]?.Equals(o) == true)
                {
                    return true;
                }
            }
            return false;
        }

        //9
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

        //Вспомогательный метод для изменения размера внутреннего массива
        private void Resize(int newCapacity)
        {
            T[] newArray = new T[newCapacity];
            Array.Copy(elementData, newArray, elementCount);
            elementData = newArray;
        }
        //10
        public bool IsEmpty()
        {
            return elementCount == 0;
        }

        //11
        public bool Remove(T o)
        {
            for (int i = 0; i < elementCount; i++)
            {
                if (Equals(elementData[i], o))
                {
                    Remove(i);
                    return true;
                }
            }
            return false;
        }

        //12
        public void RemoveAll(T[] a)
        {
            foreach (T item in a)
            {
                Remove(item);
            }
        }

        //13
        public void RetainAll(T[] a)
        {
            for (int i = elementCount - 1; i >= 0; i--)
            {
                if (Array.IndexOf(a, elementData[i]) == -1)
                {
                    Remove(i);
                }
            }
        }
        //14
        public int Size()
        {
            return elementCount;
        }

        //15
        public T[] ToArray()
        {
            T[] result = new T[elementCount];
            Array.Copy(elementData, result, elementCount);
            return result;
        }
        //16
        public T[] ToArray(T[] a)
        {
            if (a == null || a.Length < elementCount)
            {
                a = new T[elementCount];
            }
            Array.Copy(elementData, a, elementCount);
            return a;
        }

        //17
        public void Add(int index, T e)
        {
            if (index < 0 || index > elementCount)
            {
                throw new IndexOutOfRangeException("Индекс вне диапазона");
            }
            EnsureCapacity(elementCount + 1);
            for (int i = elementCount; i > index; i--)
            {
                elementData[i] = elementData[i - 1];
            }
            elementData[index] = e;
            elementCount++;
        }

        //18
        public void AddAll(int index, T[] a)
        {
            if (index < 0 || index > elementCount)
            {
                throw new IndexOutOfRangeException("Индекс вне диапазона");
            }
            EnsureCapacity(elementCount + a.Length);
            for (int i = elementCount - 1; i >= index; i--)
            {
                elementData[i + a.Length] = elementData[i];
            }
            for (int j = 0; j < a.Length; j++)
            {
                elementData[index + j] = a[j];
            }
            elementCount += a.Length;
        }

        //19
        public T Get(int index)
        {
            if (index < 0 || index >= elementCount)
            {
                throw new IndexOutOfRangeException("Индекс вне диапазона");
            }
            return elementData[index];
        }

        //20
        public int IndexOf(T o)
        {
            for (int i = 0; i < elementCount; i++)
            {
                if (Equals(elementData[i], o))
                {
                    return i;
                }
            }
            return -1;
        }

        //21
        public int LastIndexOf(T o)
        {
            for (int i = elementCount - 1; i >= 0; i--)
            {
                if (Equals(elementData[i], o))
                {
                    return i;
                }
            }
            return -1;
        }
        //22
        public T Remove(int index)
        {
            if (index < 0 || index >= elementCount)
            {
                throw new IndexOutOfRangeException("Индекс вне диапазона");
            }
            T removedElement = elementData[index];
            for (int i = index; i < elementCount - 1; i++)
            {
                elementData[i] = elementData[i + 1];
            }
            elementData[elementCount - 1] = default(T);
            elementCount--;
            return removedElement;
        }

        //23
        public T Set(int index, T e)
        {
            if (index < 0 || index >= elementCount)
            {
                throw new IndexOutOfRangeException("Индекс вне диапазона");
            }
            T oldElement = elementData[index];
            elementData[index] = e;
            return oldElement;
        }

        //Доп метод для обеспечения достаточной ёмкости массива
        private void EnsureCapacity(int min)
        {
            if (elementData.Length < min)
            {
                int newCapacity;
                if (capacityIncrement !=  0)
                    newCapacity = elementData.Length + capacityIncrement;
                else
                    newCapacity = elementData.Length * 2;
                if (newCapacity < min) newCapacity = min;
                T[] newArray = new T[newCapacity];
                Array.Copy(elementData, newArray, elementCount);
                elementData = newArray;
            }
        }

        //24
        public MyVector<T> SubList(int fromIndex, int toIndex)
        {
            if (fromIndex < 0 || toIndex > elementCount || fromIndex >= toIndex)
                throw new ArgumentOutOfRangeException("Неверные индексы для подсписка");

            MyVector<T> sublist = new MyVector<T>();
            for (int i = fromIndex; i < toIndex; i++)
            {
                sublist.Add(elementData[i]);
            }
            return sublist;
        }

        //25
        public T firstElement()
        {
            try
            {
                return elementData[0];
            }
            catch (Exception e)
            {
                throw new ArgumentOutOfRangeException("Элемент вне индекса");
            }
        }

        //26
        public T lastElement()
        {
            try
            {
                return elementData[elementCount - 1];
            }
            catch (Exception e)
            {
                throw new ArgumentOutOfRangeException("Элемент вне индекса");
            }
        }
        //27
        public void RemoveElementAt(int pos)
        {
            try
            {
                this.Remove(pos);
            }
            catch (Exception e)
            {
                throw new ArgumentOutOfRangeException("Элемент вне индекса");
            }
        }
        //28
        public void RemoveRandge(int begin, int end)
        {
            try
            {
                for (int i = begin; i < end; i++)
                {
                    this.Remove(i);
                }
            }
            catch (Exception e)
            {
                throw new ArgumentOutOfRangeException("Элемент вне диапазона");
            }
        }
        
        public IEnumerator<T> GetEnumerator()
        {
            for (int i = 0; i < elementCount; i++)
            {
                yield return elementData[i];
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
}


