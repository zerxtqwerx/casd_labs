using System;

public class Program
{
    public static void Main(string[] args)
    {
        Console.WriteLine("Введите математическое выражение в обратной польской нотации:");
        string input = Console.ReadLine();

        string[] tokens = input.Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);

        try
        {
            double result = ExpressionEvaluator.EvalRPN(tokens);
            Console.WriteLine($"Результат: {result}");
            Console.ReadLine();
        }
        catch (Exception ex)
        {
            double result = ExpressionEvaluator.EvalRPN(tokens);
            Console.WriteLine($"Ошибка при вычислении выражения: {ex.Message}");
            Console.ReadLine();
        }
    }
}

//Примеры
//3 4 +
//3 4 + 2 *
//5 1 2 + 4 * -
//2 3 ^
//3 4 + 2 5 * - 7 +
//3 4 + 2 * 5 6 + /