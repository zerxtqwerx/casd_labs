using System;

namespace ConsoleApp1
{
    public interface MyIterator1<T>
    {
        

        bool HasNext();

        T Next();

        void Remove();
    }
    public interface IMyCollection1<T>
    {

        MyIterator1<T> Iterator();
    }

    public class MyItr1<T> : MyIterator1<T>
    {
        private MyArrayDeque<T> list;
        private int cursor = -1;

        public MyItr1(MyArrayDeque<T> list)
        {
            this.list =list;
        }

        public IMyCollection1<T> IMyCollection1
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
            return list.Peek();
        }

        public void Remove()
        {
            list.Poll();
            cursor--;
        }
    }

}
