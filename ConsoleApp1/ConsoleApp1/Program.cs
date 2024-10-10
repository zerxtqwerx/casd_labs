using System;
using System.Collections.Generic;
using System.IO;
using System.Text.RegularExpressions;

class Program
{
    static void Main()
    {
        string filePath = "input.txt";

        HashSet<string> tags = new HashSet<string>(StringComparer.OrdinalIgnoreCase);

        try
        {
            foreach (var line in File.ReadLines(filePath))
            {
                var matches = Regex.Matches(line, @"<\s*\/?\s*([a-zA-Z][a-zA-Z0-9]*)\s*>");
                foreach (Match match in matches)
                {
                    string tag = match.Value.Trim('<', '>', ' ');

                    tags.Add(match.Groups[1].Value.Trim());
                }
            }

            foreach (var tag in tags)
            {
                Console.WriteLine(tag);
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
