using System;
using System.Text;
using System.Collections.Generic;
using System.Collections;
using System.Threading.Tasks;
using System.Collections.Specialized;
using ConsoleApp1;
using System.Data.Common;
using System.Runtime.CompilerServices;
using System.Text.RegularExpressions;
using System.Diagnostics.Eventing.Reader;
using System.Globalization;

public class Calculator
{
    public static double SwitchExpression(string sign, double a, double b)
    {
        if (sign == "+")
            return a + b;
        else if (sign == "-")
            return a - b;
        else if (sign == "*")
            return a * b;
        else if (sign == "/")
            return a / b;
        else if (sign == "^")
            return Math.Pow(a, b);
        else if (sign == "√")
            return Math.Sqrt(a);
        else if (sign == "sin")
            return Math.Sin(a);
        else if (sign == "cos")
            return Math.Cos(a);
        else if (sign == "tan")
            return Math.Tan(a);
        else if (sign == "ln")
        {
            if (a <= 0) throw new ArgumentException();
            return Math.Log(a);
        }
        else if (sign == "log")
        {
            if (a <= 0) throw new ArgumentException();
            return Math.Log10(a);
        }
        else if (sign == "min")
            return Math.Min(a, b);
        else if (sign == "max")
            return Math.Max(a, b);
        else if (sign == "%")
            return a % b;
        else if (sign == "//")
            return (int)(a / b);
        else if (sign == "exp")
            return Math.Exp(1);
        else if (sign == "trunc")
            return Math.Truncate(a);
        return 0;
    }

    /*private static bool Comparator(string token)
    {
        if(token) return true;
    }*/

    private static string[] operators = { "+", "-", "*", "/", "^", "√", "sin", "cos", "tan", "ln", "log", "min", "max", "%", "//", "trunc", "(", ")" };
    private static string numberPattern = @"^-?\d+(\.\d+)?$";

    public static void Parse(string expression, out MyStack<double> numbers, out MyStack<string> signs)
    {
        numbers = new MyStack<double>();
        signs = new MyStack<string>();

        string[] tokens = expression.Split(' ');
        foreach (var token in tokens)
        {
            try
            {
                if (Array.Find(operators, op => op.Equals(token)) != null) //если оператор
                {
                    signs.Push(token);
                }
                else if (token == "exp")
                {
                    numbers.Push(Math.Exp(1));
                }
                else if (Regex.Matches(token, numberPattern).Count > 0) //если число
                {
                    double a = 0;
                    double.TryParse(token, NumberStyles.Any, CultureInfo.InvariantCulture, out a);
                    numbers.Push(a);
                }
                else
                {
                    bool flag = true;
                    foreach (char c in token)
                    {
                        if (!char.IsLetter(c))
                        {
                            flag = false;
                            break;
                        }
                    }
                    if (flag)
                    {
                        Console.WriteLine("Введите " + token + ": ");
                        try
                        {
                            string n = Console.ReadLine();
                            numbers.Push(Convert.ToDouble(n));
                        }
                        catch (Exception ex)
                        {
                            Console.WriteLine(token + " не число.");
                        }
                    }
                }
            }
            catch 
            {
                Console.WriteLine("Ввели некорректное выражение. Разделите все операции, числа и скобки пробелами. Вместо , в дробном числе введите .");
            }

        }
    }

    public static void Main(string[] args)
    {
        Console.OutputEncoding = Encoding.GetEncoding(1251);
        while (true)
        {
            {
                Console.WriteLine("Введите математическое выражение, разделяя все отдельные части выражения пробелом:");
                string expression = Console.ReadLine();
                try
                {
                    Parse(expression, out MyStack<double> numbers, out MyStack<string> signs);
                    double result = Calculate(numbers, signs);
                    Console.WriteLine(result);
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Ошибка: {ex.Message}");
                }
            }
        }
    }
    private static double Calculate(MyStack<double> numbers, MyStack<string> signs)
    {
        while (!signs.Empty() && !numbers.Empty())
        {
            try
            {
                var sign = signs.Pop();
                if (sign == ")")
                {
                    numbers.Push(Calculate(numbers, signs));
                }
                else if (sign == "(")
                    break;
                else
                    numbers.Push(Switch(sign, numbers));
            }
            catch (Exception ex) 
            { 
                Console.WriteLine($"Ошибка: {ex.Message}");
            }
        }
        return numbers.Pop();
    }

    public static double Switch(string sign, MyStack<double> numbers)
    {
        if (sign == "+")
            return numbers.Pop() + numbers.Pop();
        else if (sign == "-")
            return -1 * (numbers.Pop() - numbers.Pop());
        else if (sign == "*")
            return numbers.Pop() * numbers.Pop();
        else if (sign == "/")
        {
            var a = numbers.Pop();
            var b = numbers.Pop();
            return b / a;
        }
        else if (sign == "^")
        {
            var a = numbers.Pop();
            var b = numbers.Pop();
            return Math.Pow(b, a);
        }
        else if (sign == "√")
            return Math.Sqrt(numbers.Pop());
        else if (sign == "sin")
            return Math.Sin(numbers.Pop());
        else if (sign == "cos")
            return Math.Cos(numbers.Pop());
        else if (sign == "tan")
            return Math.Tan(numbers.Pop());
        else if (sign == "ln")
        {
            var a = numbers.Pop();
            if (a <= 0) throw new ArgumentException();
            return Math.Log(a);
        }
        else if (sign == "log")
        {
            var a = numbers.Pop();
            if (a <= 0) throw new ArgumentException();
            return Math.Log10(a);
        }
        else if(sign == "min")
            return Math.Min(numbers.Pop(), numbers.Pop());
        else if(sign == "max")
            return Math.Max(numbers.Pop(), numbers.Pop());
        else if (sign == "%")
        {
            var a = numbers.Pop();
            var b = numbers.Pop();
            return b % a;
        }
            
        else if (sign == "//")
        {
            var a = numbers.Pop();
            var b = numbers.Pop();
            return (int)b / a;
        }
        else if (sign == "trunc")
            return Math.Truncate(numbers.Pop());
        return 0;
    }
}
   