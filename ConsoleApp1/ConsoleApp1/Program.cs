using System;

namespace ConsoleApp1
{
    internal class Program
    {
        public static void Main()
        {
            Console.WriteLine("1 группа:");
            MyArrayList<int> myArrayList = new MyArrayList<int>();
            myArrayList.Add(1);
            myArrayList.Add(2);
            myArrayList.Add(3);

            MyIterator2<int> iterator = myArrayList.ListIterator();

            while (iterator.HasNext())
            {
                int value = iterator.Next();
                Console.WriteLine(value);
                if (value == 2)
                    iterator.Set(20);
            }
            /*while (iterator.HasPrevious())
                iterator.Previous();
*/
            Console.WriteLine("После замены:");
            iterator = myArrayList.ListIterator();
            Console.WriteLine(iterator.Previous());

            while (iterator.HasNext())
            {
                Console.WriteLine(iterator.Next());
            }
            Console.Read();
        }
    }
}
