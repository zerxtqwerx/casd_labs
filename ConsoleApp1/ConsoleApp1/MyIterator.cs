using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    public interface MyIterator<T>
    {
        bool HasNext();
        bool HasPrevious();

        T Next();
        T Previous();

        T NextIndex();
        T PreviousIndex();

        void Remove();

        void Set(T element);
        void Add(T element);
    }

    public class MyItr<T> : MyIterator<T>
    {
        /*private class Cursor<T>
        {
            public T Value { get; set; }
            public Cursor<T> Previous { get; set; }
            public Cursor<T> Next { get; set; }
            public int Index;

            public Cursor()
            {
                Value = default(T);
                Previous = null;
                Next = null;
                Index = 0;
            }

            public void Add(T value, Cursor<T> previous = null, Cursor<T> next = null)
            {
                Cursor<T> current = new Cursor<T>();
                current.Value = value;
                current.Previous = previous;
                current.Previous.Next = current;
                current.Next.Previous = current;
                if(previous != null)
                    Index = current.Previous.Index + 1;
            }

            public void Remove(Cursor<T> start, Cursor<T> removing)
            {
                try
                {
                    Cursor<T> cursor = start;
                    while(cursor != removing)
                    {

                    }
                }
            }
        }*/
        //Cursor<T> cursor;
        MyLinkedList<T> cursor;
        int Index;

        public bool HasNext()
        {
            try
            {
                return cursor.Get(Index + 1) != null;
            }
            catch
            { return false; }
        }

        public T Next()
        {
            try
            {
                return cursor.Get(Index + 1);
            }
            catch { return default(T); }
        }

        public bool HasPrevious()
        {
            try
            {
                return cursor.Get(Index - 1) != null;
            }
            catch
            { return false; }
        }

        public T Previous()
        {
            try
            {
                return cursor.Get(Index - 1);
            }
            catch { return default(T); }
        }

        public int NextIndex()
        {
            try
            {
                if ((Index + 1) <= Convert.ToInt32(cursor.GetLast()))
                    return Index + 1;
                return -1;
            }
            catch { return -1; }
        }
        public int PreviousIndex()
        {
            try
            {
                if ((Index - 1) >= 0)
                    return Index - 1;
                return -1;
            }
            catch { return -1; }
        }

        public void Remove()
        {
            try
            {
                cursor.Remove(Index);
            }
            catch(Exception e) { Console.WriteLine(e); }
        }

        public void Set(T element)
        {
            try
            {
                int index = cursor.IndexOf(element);
                cursor.Set(index, element);
            }
            catch (Exception e) { Console.WriteLine(e); }
        }
        public void Add(T element)
        {
            try
            {
                cursor.Add(NextIndex(), element);
            }
            catch (Exception e) { Console.WriteLine(e); }
        }
    }
}
