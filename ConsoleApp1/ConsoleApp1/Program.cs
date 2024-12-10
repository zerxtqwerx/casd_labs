using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

namespace ConsoleApp1
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.OutputEncoding = Encoding.GetEncoding(1251);
            MyHashSet<string> uniqueWords = new MyHashSet<string>();

            string filePath = "input.txt";

            foreach (var line in File.ReadLines(filePath))
            {
                MatchCollection matches = Regex.Matches(line.ToLower(), @"\b[a-zA-Z]+\b", RegexOptions.IgnoreCase);

                foreach (Match match in matches)
                {
                    if(!uniqueWords.Contains(match.Value)) 
                        uniqueWords.Add(match.Value);
                }
            }

            Console.WriteLine("Уникальные слова (без учета регистра):");
            foreach (var word in uniqueWords.ToArray().OrderBy(x => x).ToList()) 
            {
                Console.WriteLine(word);
            }
            Console.Read();
        }
    }
}
