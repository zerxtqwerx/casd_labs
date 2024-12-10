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
        private T Cursor;

        public bool HasNext()
        {
           
        }
    }
}
