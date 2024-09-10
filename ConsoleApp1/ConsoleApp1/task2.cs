using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;

/*Определить структуру для хранения комплексных чисел. Методы: создание комплексного
числа по вещественной и мнимой части, сложение, вычитание, умножение, деление,
нахождение модуля и аргумента, возврат мнимой и вещественной частей, вывод. При
необходимости передавать структуру в качестве параметра используйте константные
ссылки.
Для демонстрации работы методов организуйте текстовое меню с помощью бесконечного
цикла. Выбор действий организовать вводом символа, который обрабатывается
оператором switch. Кроме методов необходимо иметь возможность выхода из программы
по пункту меню. Выход может быть осуществлён по символам 'Q' и 'q'. При вводе
неизвестного символа, должно быть выведено сообщение «неизвестная команда».
(Операция ввода получает одно число, с которыми должны работать остальные операции.
Если операции необходимо два аргумента – введите второй аргумент. Результат должен
записываться в исходной число. До первого ввода считать число равным 0).*/


namespace ConsoleApp1
{
    internal class task2
    {
        static void Main(string[] args)
        {
            int n = -1;
            while (n != 0)
            {
                n = -1;
                Console.WriteLine("Выберите одну из предложенных команд по порядковому номеру: ");
                Console.WriteLine("1. Сложение");
                Console.WriteLine("2. Вычитание");
                Console.WriteLine("3. Умножение");
                Console.WriteLine("4. Деление");
                Console.WriteLine("5. Нахождение модуля");
                Console.WriteLine("6. Нахождение аргумента");
                Console.WriteLine("Нажмите Q для выхода.");

                string command = Console.ReadLine();

                if (command == "q" || command == "Q")
                {
                    n = 0;
                }
                else if(char.IsDigit(Convert.ToChar(command)))
                {
                    n = Convert.ToInt32(command);
                }
                else
                {
                    Console.WriteLine("Неизвестная команда. повторите попытку.");
                }
                //если n - одна из команд
                if (n != -1)
                {
                    if (n == 0)
                    {
                        break;
                    }
                    Console.WriteLine("Введите комплексное число: ");
                    ComplexDigit complex1 = new ComplexDigit();
                    complex1 = InputComplex();

                    ComplexDigit complex2 = new ComplexDigit();
                    if (n >= 1 && n <= 4)
                    {
                        Console.WriteLine("Введите второе комплексное число: ");
                        complex2 = InputComplex();
                    }

                    ComplexDigit answer = new ComplexDigit();
                    Console.WriteLine("Ответ: ");
                    switch (n)
                    {
                        case 1:
                            answer = complex1.Add(complex2);
                            Console.WriteLine(Convert.ToString(answer.RealPart()) + "+ i*" + Convert.ToString(answer.ImaginaryPart()));
                            break;
                        case 2:
                            answer = complex1.Difference(complex2);
                            Console.WriteLine(Convert.ToString(answer.RealPart()) + "+ i*" + Convert.ToString(answer.ImaginaryPart()));
                            break;
                        case 3:
                            answer = complex1.Multiply(complex2);
                            Console.WriteLine(Convert.ToString(answer.RealPart()) + "+ i*" + Convert.ToString(answer.ImaginaryPart()));
                            break;
                        case 4:
                            answer = complex1.Divide(complex2);
                            Console.WriteLine(Convert.ToString(answer.RealPart()) + "+ i*" + Convert.ToString(answer.ImaginaryPart()));
                            break;
                        case 5:
                            Console.WriteLine(complex1.FindModule());
                            break;
                        case 6:
                            Console.WriteLine(complex1.FindArgument());
                            break;
                        default:
                            break;
                    }
                    Console.WriteLine("\t");
                }
            }
        }

        public static ComplexDigit InputComplex()
        {
            string r, i;
            do
            {
                Console.WriteLine("Введите вещественную часть: ");
                r = Console.ReadLine();

                Console.WriteLine("Введите мнимую часть: ");
                i = Console.ReadLine();
            }
            while (!char.IsDigit(Convert.ToChar(r)) || !char.IsDigit(Convert.ToChar(i)));
            return new ComplexDigit(Convert.ToDouble(r), Convert.ToDouble(i));
        }
    }
}
