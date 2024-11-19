using System;
using System.IO;
using System.Text;
using System.Text.RegularExpressions;

namespace ConsoleApp1
{

    class Program
    {
        static void Main()
        {
            Console.OutputEncoding = Encoding.GetEncoding(1251);
            string filePath = "input.txt";

            MyHashMap<string, int> tags = new MyHashMap<string, int>();

            try
            {
                foreach (var line in File.ReadLines(filePath))
                {
                    var matches = Regex.Matches(line, @"<\s*\/?\s*([a-zA-Z][a-zA-Z0-9]*)\s*>");
                    foreach (Match match in matches)
                    {
                        string tag = match.Value.Trim('<', '>', ' ');
                        tags.Put(match.Groups[1].Value.Trim(), tags.Get(match.Groups[1].Value.Trim())+1);
                        /*if (!tags.ContainsKey(match.Groups[1].Value.Trim()))
                            tags.Add(match.Groups[1].Value.Trim());*/
                    }
                }


                for (int i = 0; i < tags.Size(); i++)
                {
                    Console.WriteLine(tags.Get(i));
                }
                Console.ReadLine();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Произошла ошибка: {ex.Message}");
                Console.ReadLine();
            }
        }
    }
}

