using System.Linq;
using System;
using System.IO;

namespace ConsoleApp1
{
    class Program
    {
        static void Main(string[] args)
        {
            MyHashSet<string> linesSet = new MyHashSet<string>();
            string[] lines = File.ReadAllLines("input.txt");

            foreach (string line in lines)
            {
                linesSet.Add(line);
            }

            var sortedLines = linesSet.ToArray().OrderBy(x => x, new WordLengthComparer()).ToList();

            foreach (var line in sortedLines)
            {
                Console.WriteLine(line);
            }
            Console.Read();
        }
    }
}