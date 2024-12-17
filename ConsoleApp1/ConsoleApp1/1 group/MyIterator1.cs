using System;

namespace ConsoleApp1
{
    public interface MyIterator1<T>
    {
        bool HasNext();

        T Next();

        void Remove();
    }

    public class MyItrArrayList<T> : MyIterator1<T>
    {
        private MyArrayList<T> list;
        private int cursor = -1;

        public MyItrArrayList(T[] list)
        {
            this.list = new MyArrayList<T>(list);
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
    }

    public class MyItrLinkedList<T> : MyIterator1<T>
    {
        private MyArrayList<T> list;
        private int cursor = -1;

        public MyItrLinkedList(T[] list)
        {
            this.list = new MyArrayList<T>(list);
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
    }


    public class MyItrVector<T> : MyIterator1<T>
    {
        private MyArrayList<T> list;
        private int cursor = -1;

        public MyItrVector(T[] list)
        {
            this.list = new MyArrayList<T>(list);
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
    }
}
