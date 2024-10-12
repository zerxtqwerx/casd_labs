using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{

    public class MyArrayList<T>
    {
        private T[] elementData; //1
        private int size;        //2

        //1. Конструктор для создания пустого динамического массива
        public MyArrayList()
        {
            elementData = new T[10]; // Начальный размер массива
            size = 0;
        }

        //2. Конструктор для создания динамического массива с элементами из массива a
        public MyArrayList(T[] a)
        {
            elementData = new T[a.Length];
            Array.Copy(a, elementData, a.Length);
            size = a.Length;
        }

        //3. Конструктор для создания пустого динамического массива заданной ёмкости
        public MyArrayList(int capacity)
        {
            if (capacity < 0)
                throw new ArgumentOutOfRangeException(nameof(capacity), "Ёмкость не может быть отрицательной.");
            elementData = new T[capacity];
            size = 0;
        }

        //4. Метод для добавления элемента в конец динамического массива
        public void Add(T e)
        {
            if (size == elementData.Length)
            {
                Resize(elementData.Length * 3 / 2 + 1); // Увеличиваем размер массива
            }
            elementData[size++] = e;
        }

        //5. Метод для добавления элементов из другого массива
        public void AddAll(T[] a)
        {
            foreach (T e in a)
            {
                Add(e);
            }
        }

        //6. Метод для очистки динамического массива
        public void Clear()
        {
            Array.Clear(elementData, 0, size);
            size = 0;
        }

        //7. Метод для проверки, содержит ли массив указанный объект
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

        //8. Метод для проверки, содержатся ли указанные объекты в массиве
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

        // Вспомогательный метод для изменения размера внутреннего массива
        private void Resize(int newCapacity)
        {
            T[] newArray = new T[newCapacity];
            Array.Copy(elementData, newArray, size);
            elementData = newArray;
        }
        //9. Метод для проверки, является ли динамический массив пустым
        public bool IsEmpty()
        {
            return size == 0;
        }

        //10. Метод для удаления указанного объекта из динамического массива
        public bool Remove(T o)
        {
            for (int i = 0; i < size; i++)
            {
                if (Equals(elementData[i], o))
                {
                    Remove(i);
                    return true;
                }
            }
            return false;
        }

        //11. Метод для удаления указанных объектов из динамического массива
        public void RemoveAll(T[] a)
        {
            foreach (T item in a)
            {
                Remove(item);
            }
        }

        //12. Метод для оставления в динамическом массиве только указанных объектов
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
        //13. Метод для получения размера динамического массива
        public int Size()
        {
            return size;
        }

        //14. Метод для получения массива без изменений
        public T[] ToArray()
        {
            T[] result = new T[size];
            Array.Copy(elementData, result, size);
            return result;
        }
        //15. Метод для возвращения массива объектов, содержащего все элементы динамического массива
        public T[] ToArray(T[] a)
        {
            if (a == null || a.Length < size)
            {
                a = new T[size];
            }
            Array.Copy(elementData, a, size);
            return a;
        }

        //16. Метод для добавления элемента в указанную позицию
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

        //17. Метод для добавления элементов в указанную позицию
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

        //18. Метод для возвращения элемента в указанной позиции
        public T Get(int index)
        {
            if (index < 0 || index >= size)
            {
                throw new IndexOutOfRangeException("Индекс вне диапазона");
            }
            return elementData[index];
        }

        //19. Метод для возвращения индекса указанного объекта, или -1, если его нет
        public int IndexOf(T o)
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

        //20. Метод для нахождения последнего вхождения указанного объекта
        public int LastIndexOf(T o)
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
        //21. Метод для удаления и возвращения элемента в указанной позиции
        public T Remove(int index)
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
            return removedElement;
        }

        //22. Метод для замены элемента в указанной позиции новым элементом
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

        //Доп метод для обеспечения достаточной ёмкости массива
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

        //23. Метод для получения подсписка
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
    }

}

