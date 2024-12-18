using System;
using System.Text;

namespace ConsoleApp1
{
    internal class Program
    {
        public static void Main()
        {
            Console.OutputEncoding = Encoding.GetEncoding(1251);
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

            Console.WriteLine("После замены:");
            iterator = myArrayList.ListIterator();

            while (iterator.HasNext())
            {
                Console.WriteLine(iterator.Next());
            }
            Console.Read();
        }
    }
}
