using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    internal class Program
    {
        public static void Main(string[] args)
        {
            MyArrayList<int> list = new MyArrayList<int>();
            for (int i = 1; i <= 10; i++)
            {
                list.Add(i);
            }
            Console.WriteLine("Размер: " + list.Size());

            Console.WriteLine("Элементы в списке:");
            for (int i = 0; i < list.Size(); i++)
            {
                Console.WriteLine("Элемент[" + i + "]: " + list.Get(i));
            }

            Console.WriteLine("Удаление элемента 5:");
            list.Remove(5);
            Console.WriteLine("Размер списка после удаления: " + list.Size());

            Console.WriteLine("Список пуст? " + list.IsEmpty());

            Console.WriteLine("Удаление элементов 2, 3:");
            list.RemoveAll(new int[] { 2, 3 });
            Console.WriteLine("Размер списка после удаления: " + list.Size());

            Console.WriteLine("Создание подсписка с элементами от 0 до 2:");
            MyArrayList<int> sublist = list.SubList(0, 2);
            Console.WriteLine("Элементы подсписка:");
            for (int i = 0; i < sublist.Size(); i++)
            {
                Console.WriteLine("Элемент подсписка[" + i + "]: " + sublist.Get(i));
            }
            Console.WriteLine("Сохранение только элемента 1:");
            list.RetainAll(new int[] { 1 });
            Console.WriteLine("Размер списка после сохранения: " + list.Size());
            Console.ReadLine();
        }
    }
}
