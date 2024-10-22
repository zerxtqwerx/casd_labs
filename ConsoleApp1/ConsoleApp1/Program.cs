using System;
using System.Text;
using System.Collections.Generic;
using System.Collections;
using System.Threading.Tasks;
using System.Collections.Specialized;
using ConsoleApp1;

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
            return Math.Log10(a);
        else if (sign == "min")
            return Math.Min(a, b);
        else if (sign == "max")
            return Math.Max(a, b);
        else if (sign == "%")
            return a % b;
        else if (sign == "//")
            return (int)(a / b);
        else if (sign == "e")
            return Math.Exp();
        else if(sign ==)
        return 0;
    }

    string[] operators = { "+", "-", "*", "/", "^", "√", "sin", "cos", "tan", "ln", "log", "min", "max", "%", "//", "e", "[", "]", "(", ")"};

    public static void Parse(string expression, out MyStack<double> numbers, out MyStack<string> signs)
    {
        numbers = new MyStack<double>();    
        signs = new MyStack<string>();

        string[] tokens = expression.Split(' ');
        foreach(var token in tokens)
        {

        }
    }

    public static void Main(string[] args)
    {
        Console.OutputEncoding = Encoding.GetEncoding(1251);
        try
        {
            while (true)
            {
                Console.WriteLine("Введите математическое выражение:");
                string infix = Console.ReadLine();

                //string postfix = InfixToPostfix(infix);
                //double result = EvaluatePostfix(postfix);
                //Console.WriteLine($"Результат: {result}");
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Ошибка: {ex.Message}");
            Console.ReadLine();
        }
    }
}

/*public class Calculator
{
    private static int GetPrecedence(char op)
    {
        switch (op)
        {
            case '+':
            case '-':
                return 1;
            case '*':
            case '/':
                return 2;
            case '^':
                return 3;
            default:
                return 0;
        }
    }

    private static bool IsOperator(string s) => s.Length == 1 && "+-*/^".Contains(s);

    public static string InfixToPostfix(string expression)
    {
        var output = new List<string>();
        var operators = new MyStack<string>();

        var tokens = expression.Split(' ');

        foreach (var token in tokens)
        {
            if (double.TryParse(token, out _) || char.IsLetter(token[0]))
            {
                output.Add(token);
            }
            else if (token == "(")
            {
                operators.Push(token);
            }
            else if (token == ")")
            {
                while (!operators.IsEmpty() && operators.Peek() != "(")
                    output.Add(operators.Pop());
                operators.Pop(); // Remove "(" from stack
            }
            else if (IsOperator(token))
            {
                while (!operators.IsEmpty() && GetPrecedence(operators.Peek()[0]) >= GetPrecedence(token[0]))
                    output.Add(operators.Pop());
                operators.Push(token);
            }
        }

        while (!operators.IsEmpty())
            output.Add(operators.Pop());

        return string.Join(" ", output);
    }

    public static double EvaluatePostfix(string expression)
    {
        var values = new MyStack<double>();
        var tokens = expression.Split(' ');

        foreach (var token in tokens)
        {
            if (double.TryParse(token, out double number))
            {
                values.Push(number);
            }
            else if (IsOperator(token))
            {
                double b = values.Pop();
                double a = values.Pop();
                values.Push(Switch(token, a, b));
            }
        }

        return values.Pop();
    }

    public static double Switch(string sign, double a, double b)
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
            return Math.Log10(a);
        return 0;
    }

    public static void Main(string[] args)
    {
        Console.OutputEncoding = Encoding.GetEncoding(1251);


        try
        {
            while (true)
            {
                Console.WriteLine("Введите математическое выражение:");
                string infix = Console.ReadLine();
                string postfix = InfixToPostfix(infix);
                double result = EvaluatePostfix(postfix);
                Console.WriteLine($"Результат: {result}");
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Ошибка: {ex.Message}");
            Console.ReadLine();
        }
    }
}*/
    /*public static double EvalRPN(string[] rpn)
    {
        var stack = new MyStack<double>();

        foreach (string token in rpn)
        {
            if (double.TryParse(token, out double num))
            {
                stack.Push(num);
            }
            else
            {
                double right = stack.Pop();
                double left = stack.IsEmpty() ? 0 : stack.Pop();

                switch (token)
                {
                    case "+": stack.Push(left + right); break;
                    case "-": stack.Push(left - right); break;
                    case "*": stack.Push(left * right); break;
                    case "/":
                        if (right == 0) throw new DivideByZeroException();
                        stack.Push(left / right);
                        break;
                    case "^": stack.Push(Math.Pow(left, right)); break;
                    case "√": stack.Push(Math.Sqrt(right)); break;
                    case "sin": stack.Push(Math.Sin(right)); break;
                    case "cos": stack.Push(Math.Cos(right)); break;
                    case "tan": stack.Push(Math.Tan(right)); break;
                    case "ln":
                        if (right <= 0) throw new ArgumentException();
                        stack.Push(Math.Log(right));
                        break;
                    case "log": stack.Push(Math.Log10(right)); break;
                    default: throw new InvalidOperationException($"Unknown op: {token}");
                }
            }
        }*/
    