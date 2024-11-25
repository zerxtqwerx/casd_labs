using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Text.RegularExpressions;
using System.Xml.Linq;

public enum VariableType
{
    Int,
    Float,
    Double
}
public class VariableDefinition
{
    public VariableType Type { get; set; }
    public string Value { get; set; }

    public VariableDefinition(VariableType type, string value)
    {
        Type = type;
        Value = value;
    }

    public override string ToString()
    {
        return $"{Type} => {Value}";
    }
}

class Program
{
    static void Main()
    {
        Console.OutputEncoding = Encoding.GetEncoding(1251);
        string path = "input.txt";
        MyHashMap<string, VariableDefinition> variableMap = new MyHashMap<string, VariableDefinition>();
        Regex regex = new Regex(@"^(int|float|double)\s+([a-zA-Z_][\w]*)\s*=\s*([\d]+([.][\d]+)?);?$", RegexOptions.Multiline);

        string[] lines = File.ReadAllLines(path);
        List<string> errorMessages = new List<string>();
        HashSet<string> duplicates = new HashSet<string>();

        foreach (var line in lines)
        {
            Match match = regex.Match(line);
            if (match.Success)
            {
                VariableType type;
                string name = match.Groups[2].Value;
                //string value = match.Groups[3].Value.Replace(',', '.'); // Заменяем запятую на точку

                switch (match.Groups[1].Value.ToLower())
                {
                    case "int":
                        type = VariableType.Int;
                        break;
                    case "float":
                        type = VariableType.Float;
                        break;
                    case "double":
                        type = VariableType.Double;
                        break;
                    default:
                        continue;
                }

                // Проверяем на существование переменной и фиксируем дубликат
                if (variableMap.ContainsKey(name))
                {
                    duplicates.Add(name); // добавляем имя переменной в дубликаты
                }
                else
                {
                    // Сохраняем новое определение переменной
                    VariableDefinition variable = new VariableDefinition(type, match.Groups[3].Value);
                    variableMap.Put(name, variable);
                }
            }
            else
            {
                try
                {
                    string[] s = line.Split(' ');
                    if (variableMap.ContainsKey((string)s[1]))
                    {
                        duplicates.Add(line);
                    }
                    else
                    {
                        errorMessages.Add(line);
                    }
                }
                catch { errorMessages.Add(line); } 
            }
        }

        // Запись результатов в файл
        using (StreamWriter writer = new StreamWriter("output.txt"))
        {
            foreach (var entry in variableMap.EntrySet())
            {
                writer.WriteLine($"{entry.Value.Type} => {entry.Key}({entry.Value.Value})");
            }

            if (duplicates.Count > 0)
            {
                writer.WriteLine("\nПереопределенные переменные:");
                foreach (string duplicate in duplicates)
                {
                    writer.WriteLine(duplicate);
                }
            }

            if (errorMessages.Count > 0)
            {
                writer.WriteLine("\nНекорректные определения:");
                foreach (string error in errorMessages)
                {
                    writer.WriteLine(error);
                }
            }
        }

        Console.WriteLine("Данные записаны в файл: " + Path.Combine(Directory.GetCurrentDirectory(), "output.txt"));
        Console.Read();
    }
}
    /*static void Main()
    {
        Console.OutputEncoding = Encoding.GetEncoding(1251);
        string path = "input.txt";
        MyHashMap<string, VariableDefinition> variableMap = new MyHashMap<string, VariableDefinition>();

        Regex regex = new Regex(@"^(int|float|double)\s+([a-zA-Z_][\w]*)\s*=\s*(\d+([.]\d+)?);?$", RegexOptions.Multiline);


        string[] lines = File.ReadAllLines(path);
        List<string> errorMessages = new List<string>();
        HashSet<string> duplicates = new HashSet<string>();

        foreach (var line in lines)
        {
            Match match = regex.Match(line);
            if (match.Success)
            {
                VariableType type;
                string name = match.Groups[2].Value;
                string value = match.Groups[3].Value;

                switch (match.Groups[1].Value.ToLower())
                {
                    case "int":
                        type = VariableType.Int;
                        break;
                    case "float":
                        type = VariableType.Float;
                        break;
                    case "double":
                        type = VariableType.Double;
                        break;
                    default:
                        continue;
                }


                if (variableMap.ContainsKey(name))
                {
                    duplicates.Add(name);
                }
                else
                {
                    VariableDefinition variable = new VariableDefinition(type, value);
                    variableMap.Put(name, variable);
                }
            }
            else
            {
                Regex regex1 = new Regex(@"^(int|float|double)\s+([a-zA-Z_][\w]*)\s*=\s*(\d+([.]\d+)?);?$", RegexOptions.Multiline);
                Match match1 = regex1.Match(line);
                string name1 = match.Groups[2].Value;

                if (match1.Success)
                {
                    duplicates.Add(name1);
                }
                else
                    errorMessages.Add($"Некорректное определение: {line}");
            }
        }

        StreamWriter writer = new StreamWriter("output.txt");

        foreach (var entry in variableMap.EntrySet())
        {
            writer.WriteLine($"{entry.Value.Type} => {entry.Key}({entry.Value.Value})");
        }

        if (duplicates.Count > 0)
        {
            writer.WriteLine("\nПереопределенные переменные:");
            foreach (string duplicate in duplicates)
            {
                writer.WriteLine(duplicate);
            }
        }

        if (errorMessages.Count > 0)
        {
            writer.WriteLine("\nНекорректные определения:");
            foreach (string error in errorMessages)
            {
                writer.WriteLine(error);
            }
        }
        writer.Close();
        Console.WriteLine("Данные записаны в файл: " + Directory.GetCurrentDirectory() + "\\output.txt");
        Console.ReadLine();

    }*/
