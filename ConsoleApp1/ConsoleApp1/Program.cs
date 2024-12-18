using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int N = 6;
            Console.WriteLine(((N - 1) % 9) + 1); //6 Топологическая сортировка. Алгоритм Тарьяна.
            Console.WriteLine(((N - 1) % 3) + 10); //12 Построение максимального потока в транспортной сети. Алгоритм проталкивания предпотока
            Console.WriteLine(((N - 1) % 6) + 13); //18 Проверка изоморфности двух графов.
            Console.Read();
        }
    }
}
