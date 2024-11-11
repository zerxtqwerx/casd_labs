using System;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
public class Program
{
    static void Main(string[] args)
    {
        Console.OutputEncoding = Encoding.GetEncoding(1251);
        MyArrayDeque<string> deque = new MyArrayDeque<string>();
        string[] lines = File.ReadAllLines("input.txt");

        foreach (var line in lines)
        {
            int digitCount = line.Count(char.IsDigit);

            int referenceDigitCount = deque.IsEmpty() ? 0 : deque.Element().Count(char.IsDigit);

            if (digitCount > referenceDigitCount)
            {
                deque.Add(line); 
            }
            else
            {
                deque.Push(line);
            }
        }

        using (StreamWriter writer = new StreamWriter("sorted.txt"))
        {
            var resultArray = deque.ToArray();
            foreach (var str in resultArray)
            {
                writer.WriteLine(str);
            }
        }

        Console.Write("введите максимально доступное количество пробелов в строке: ");
        int n;
        if (!int.TryParse(Console.ReadLine(), out n))
        {
            Console.WriteLine("неккоректный ввод. введите число.");
            return;
        }

        for (int i = 0; i < deque.Size();)
        {
            if (deque.Peek().Count(c => c == ' ') > n)
            {
                deque.RemoveFirst();
            }
            else
            {
                i++;
            }
        }
        //
        Console.WriteLine("записанная в двунаправленной очереди строка: ");
        while (!deque.IsEmpty())
        {
            Console.WriteLine(deque.RemoveFirst());
        }
        Console.WriteLine("Данные записаны в файл: " + Directory.GetCurrentDirectory() + "\\sorted.txt");
        Console.Read();
    }
}