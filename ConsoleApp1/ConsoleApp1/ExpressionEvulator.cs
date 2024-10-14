using System;
using System.Collections.Generic;
using System.Text;

public class ExpressionEvaluator
{
    private static readonly Dictionary<string, int> precedence = new Dictionary<string, int>()
    {
        { "+", 1 }, { "-", 1 },
        { "*", 2 }, { "/", 2 },
        { "^", 3 }, { "√", 3 },
        { "sin", 3 }, { "cos", 3 },
        { "tan", 3 }, { "ln", 3 },
        { "log", 3 }, { "min", 1 },
        { "max", 1 }, { "%", 2 }
    };

    public static string[] ToRPN(string expr)
    {
        var ops = new MyStack<string>();
        var output = new List<string>();
        var sb = new StringBuilder();

        foreach (char c in expr)
        {
            if (char.IsWhiteSpace(c)) continue;

            if (char.IsDigit(c) || c == '.')
            {
                sb.Append(c);
            }
            else
            {
                if (sb.Length > 0)
                {
                    output.Add(sb.ToString());
                    sb.Clear();
                }

                if (char.IsLetter(c) || c == '√')
                {
                    output.Add(c.ToString());
                }
                else if (c == '(')
                {
                    ops.Push(c.ToString());
                }
                else if (c == ')')
                {
                    while (!ops.IsEmpty() && ops.Peek() != "(")
                    {
                        output.Add(ops.Pop());
                    }
                    ops.Pop(); // Убираем '('
                }
                else
                {
                    string op = c.ToString();
                    while (!ops.IsEmpty() && precedence.TryGetValue(ops.Peek(), out int p) && p >= precedence[op])
                    {
                        output.Add(ops.Pop());
                    }
                    ops.Push(op);
                }
            }
        }

        if (sb.Length > 0)
        {
            output.Add(sb.ToString());
        }

        while (!ops.IsEmpty())
        {
            output.Add(ops.Pop());
        }

        return output.ToArray();
    }

    public static double EvalRPN(string[] rpn)
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
        }

        return stack.Pop();
    }
}
