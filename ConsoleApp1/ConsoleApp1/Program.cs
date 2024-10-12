using System;
using System.Collections.Generic;
using System.IO;
using System.Text.RegularExpressions;

namespace ConsoleApp1
{

    class Program
    {
        static void Main()
        {
            string filePath = "input.txt";

            MyArrayList<string> tags = new MyArrayList<string>();

            try
            {
                foreach (var line in File.ReadLines(filePath))
                {
                    var matches = Regex.Matches(line, @"<\s*\/?\s*([a-zA-Z][a-zA-Z0-9]*)\s*>");
                    foreach (Match match in matches)
                    {
                        string tag = match.Value.Trim('<', '>', ' ');

                        if(tags.Contains(match.Groups[1].Value.Trim()) == false)
                            tags.Add(match.Groups[1].Value.Trim());
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
