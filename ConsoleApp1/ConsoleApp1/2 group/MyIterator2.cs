using System;
using System.Collections;
using System.Collections.Generic;

namespace ConsoleApp1
{
    public interface MyIterator2<T>
    {

        bool HasNext();
        bool HasPrevious();

        T Next();
        T Previous();

        int NextIndex();
        int PreviousIndex();

        void Remove();

        void Set(T element);
        void Add(T element);
    }

    public interface IMyCollection2<T>
    {

        MyIterator2<T> ListIterator();
        //int Size();
    }

    public class MyItr2<T> : MyIterator2<T>
    {
        /*private readonly IMyCollection2<T> collection;
        private readonly Func<IMyCollection2<T>, T> getItemFunc;
        private readonly Func<IMyCollection2<T>, bool> moveNextFunc;
        private readonly Action<IMyCollection2<T>> resetFunc;

        public MyItr2(IMyCollection2<T> collection,
            Func<IMyCollection2<T>, T> getItemFunc,
            Func<IMyCollection2<T>, bool> moveNextFunc,
            Action<IMyCollection2<T>> resetFunc)
        {
            this.collection = collection;
            this.getItemFunc = getItemFunc;
            this.moveNextFunc = moveNextFunc;
            this.resetFunc = resetFunc;
        }*/
        //public event Action<MyArrayList<T>> OnDataChanged;
        private MyArrayList<T> list;
        //public T Current => getItemFunc(collection);
        //object IEnumerator.Current => Current;
        private int cursor = -1;

        public MyItr2(MyArrayList<T> list)
        {
            this.list = list;
        }

        public IMyCollection2<T> IMyCollection2
        {
            get => default;
            set
            {
            }
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
                //OnDataChanged?.Invoke(list);
            }
            cursor--;
        }

        public void Set(T element)
        {
            if (cursor < 0 || cursor >= list.Size())
                throw new InvalidOperationException("Индекс вне массива.");

            list.Set(cursor, element);
            //OnDataChanged?.Invoke(list);
        }

        public void Add(T element)
        {

            list.Add(default); 
            for (int i = list.Size() - 1; i > cursor; i--)
            {
                list.Set(i, list.Get(i - 1)); 
            }
            list.Set(cursor + 1, element);
            //OnDataChanged?.Invoke(list);
            cursor++; 
        }
        /*public bool MoveNext()
        {
            return moveNextFunc(collection);
        }

        public void Reset()
        {
            resetFunc(collection);
        }

        public void Dispose() { }*/
    }
}
