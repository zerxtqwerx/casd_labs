using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Text.RegularExpressions;

namespace ConsoleApp1
{

    class Program
    {
        static void Main()
        {
           
            MyHashMap<string, int> tagCounter = new MyHashMap<string, int>();


            Regex tagPattern = new Regex(@"<\s*\/?\s*([a-zA-Z][\w]*)\s*>", RegexOptions.IgnoreCase);


            string[] lines = File.ReadAllLines("input.txt");

            foreach (var line in lines)
            {
                MatchCollection matches = tagPattern.Matches(line);
                foreach (Match match in matches)
                {
                    string tag = match.Groups[1].Value.ToLower();

                    if (tagCounter.ContainsKey(tag))
                    {
                        int count = tagCounter.Get(tag);
                        tagCounter.Put(tag, count + 1);
                    }
                    else
                    {
                        tagCounter.Put(tag, 1);
                    }
                }
            }

            Console.WriteLine("Количество вхождений тегов:");
            foreach (var entry in tagCounter.EntrySet())
            {
                Console.WriteLine($"{entry.Key}: {entry.Value}");
            }
            Console.ReadKey();
        }
    }
}

