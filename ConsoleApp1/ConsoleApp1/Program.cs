using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace ConsoleApp1
{
    public class Program
    {
        static void Main()
        {
            Console.OutputEncoding = Encoding.GetEncoding(1251);
            string[] lines = File.ReadAllLines("input.txt");
            MyVector<string> ipAddresses = new MyVector<string>();

            foreach (string line in lines)
            {
                string[] substrings = line.Split(' ');

                foreach (string substring in substrings)
                {
                    if (IsValidIP(substring))
                    {
                        ipAddresses.Add(substring);
                    }
                }
            }
            using (StreamWriter writer = new StreamWriter("output.txt"))
            {
                foreach (string substring in ipAddresses)
                {
                    writer.WriteLine(substring);
                }
            }
            string currentDirectory = Directory.GetCurrentDirectory();
            Console.WriteLine("IP-адреса записаны в файл: " + currentDirectory + "\\output.txt");
            Console.ReadLine();
        }

        static bool IsValidIP(string ip)
        {
            string[] parts = ip.Split('.');
            if (parts.Length != 4)
                return false;

            for (int i = 0; i < parts.Length; i++)
            {
                if (!int.TryParse(parts[i], out int number))
                {
                    return false;
                }
                if (number < 0 || number > 255)
                {
                    return false;
                }
                if (parts[i].Length != number.ToString().Length)
                {
                    return false;
                }
            }

            // Проверяем, что IP-адреса не пересекаются с другой числовой подстрокой
            if (!IsIsolated(ip))
            {
                return false;
            }

            return true;
        }

        static bool IsIsolated(string ip)
        {
            
            string input = "..."; 
            int index = input.IndexOf(ip);
            if (index == -1) return true;

            bool isBefore = (index == 0) || !IsDigitOrDot(input[index - 1]);

            bool isAfter = (index + ip.Length == input.Length) || !IsDigitOrDot(input[index + ip.Length]);

            return isBefore && isAfter;
        }

        static bool IsDigitOrDot(char c)
        {
            return Char.IsDigit(c) || c == '.';
        }
    }
}
