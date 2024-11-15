using System;

namespace ConsoleApp1
{
    public class Program
    {
        [STAThread]
        static void Main(string[] args)
        {
            Graph graph = new Graph();
            graph.ShowDialog();
            Console.ReadLine();
        }
    }
}