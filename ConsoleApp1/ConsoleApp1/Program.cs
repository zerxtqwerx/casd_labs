using System;

namespace ConsoleApp1
{
    internal class Program
    {
        public static void Main()
        {
            MyArrayList<int> myArrayList = new MyArrayList<int>();
            myArrayList.Add(1);
            myArrayList.Add(2);
            myArrayList.Add(3);

            MyIterator<int> iterator = myArrayList.Iterator();

            while (iterator.HasNext())
            {
                int value = iterator.Next();
                Console.WriteLine(value);
                if (value == 2)
                    iterator.Set(20); 
            }

            iterator = myArrayList.Iterator();
            Console.WriteLine("После замены:");
            while (iterator.HasNext())
            {
                Console.WriteLine(iterator.Next());
            }
        }
    }
}
