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
            Console.OutputEncoding = Encoding.GetEncoding(1251);
            int N = 6;
            Console.WriteLine(((N - 1) % 9) + 1); //6 Топологическая сортировка. Алгоритм Тарьяна.
            Console.WriteLine(((N - 1) % 3) + 10); //12 Построение максимального потока в транспортной сети. Алгоритм проталкивания предпотока
            Console.WriteLine(((N - 1) % 6) + 13); //18 Проверка изоморфности двух графов.

            //6
            int verticesCount = 5;
            var graph = new List<List<int>>
        {
            new List<int> { 1 },
            new List<int> { 2 },
            new List<int> { 0 },
            new List<int> { 1, 4 },
            new List<int> { 3 }
        };

            var tarjan = new Tarjan(verticesCount);
            var components = tarjan.FindStronglyConnectedComponents(graph);

            Console.WriteLine("Сильные компоненты:");
            foreach (var component in components)
            {
                Console.WriteLine(string.Join(", ", component));
            }

            //12
            int verticesCount1 = 6;
            Graph g = new Graph(verticesCount1);

            g.AddEdge(0, 1, 16); 
            g.AddEdge(0, 2, 13);
            g.AddEdge(1, 2, 10);
            g.AddEdge(1, 3, 12);
            g.AddEdge(2, 1, 4);
            g.AddEdge(2, 4, 14);
            g.AddEdge(3, 2, 9);
            g.AddEdge(3, 5, 20);
            g.AddEdge(4, 3, 7);
            g.AddEdge(4, 5, 4);

            int maxFlow = g.PushRelabel(0, 5);
            Console.WriteLine("Максимальный поток: " + maxFlow);

            //18
            Graph1 g1 = new Graph1(3);
            g1.AddEdge(0, 1);
            g1.AddEdge(1, 2);
            g1.AddEdge(0, 2);

            Graph1 g2 = new Graph1(3);
            g2.AddEdge(0, 1);
            g2.AddEdge(1, 2);
            g2.AddEdge(0, 2);

            Console.WriteLine($"Графы g1 и g2 изоморфны: {g1.IsIsomorphic(g2)}");

            Console.Read();
        }
    }
}
