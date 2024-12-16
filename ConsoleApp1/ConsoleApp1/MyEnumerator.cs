using System;
using System.Collections.Generic;

namespace ConsoleApp1
{
    public interface IMyEnumerator<T>
    {
        T Current { get; }            
        bool MoveNext();              
        void Reset();                 
    }
    public class MyEnumerator<T> : IMyEnumerator<T>
    {
        private MyArrayList<T> list;
        private int cursor = -1;

        public MyEnumerator(MyArrayList<T> list)
        {
            this.list = list;
        }

        public T Current
        {
            get
            {
                if (cursor < 0 || cursor >= list.Size())
                    throw new InvalidOperationException("Недопустимая операция ");
                return list.Get(cursor);
            }
        }

        public bool MoveNext()
        {
            cursor++;
            return cursor < list.Size();
        }

        public void Reset()
        {
            cursor = -1;
        }
        public IEnumerator<T> GetEnumerator()
        {
            for (int i = 0; i < list.Size(); i++)
            {
                yield return list.Get(i);
            }
        }
    }
}
