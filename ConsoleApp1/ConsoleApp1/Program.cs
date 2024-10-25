using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    internal class Program
    {

        /*С клавиатуры вводится количество шагов добавления заявок в приоритетную очередь 𝑁.
На каждом шаге производятся следующие действия: генерируются и добавляются в
очередь от 1 до 10 заявок (конкретное число заявок выбирается случайно). Каждая заявка
содержит следующую информацию: 
        -приоритет (случайное целое число от 1 до 5), 
        -номер заявки (заявки считаются начиная с 1, нумерация сквозная на всех шагах), 
        -номер шага на котором заявка поступила в систему. 
После добавления заявок, заявка с наибольшим
приоритетом удаляется.

После завершения N шагов генерации заявок, шаги продолжаются без генерации (только
удаление) до тех пор, пока очередь не станет пуста.

Необходимо подсчитать максимальное время ожидания заявки в системе и вывести всю
информацию о заявке, которая ожидала максимальное время.
Кроме того, следует сохранять информацию о каждом добавлении заявки в очередь и
удалении заявки в очередь в файл log.txt. Запись в файле имеет следующую структуру:
ADD/REMOVE НомерЗаявки Приоритет НомерШага
*/
        private static int numberRequest = 1;
        private static string filePath = "log.txt";
        private static StreamWriter writer = new StreamWriter(filePath);

        static void Main(string[] args)
        {
            try
            {
                Console.OutputEncoding = Encoding.GetEncoding(1251);
                int n = Convert.ToInt32(Console.ReadLine());
                MyPriorityQueue<Request> queue = new MyPriorityQueue<Request>();
                for (int i = 1; i < n + 1; i++)
                {
                    Random rnd = new Random();
                    int countRequests = rnd.Next(1, 10);
                    for (int j = 0; j < countRequests; j++)
                    {
                        GenerateRequest(queue, i);
                    }
                    Request maxRequest = queue.Element();
                    queue.Remove(maxRequest);
                }
                System.TimeSpan time = new TimeSpan();
                while (!queue.IsEmpty())
                {
                    Request req = queue.Element();
                    time = req.Stopwatch.Elapsed;
                    queue.Remove(req);
                    writer.WriteLine("REMOVE " + req.Number + " " + req.Priority + " " + req.Step);
                }
                queue = null;
                Console.WriteLine(time);
                writer.Close();
                Console.WriteLine("Данные записаны в файл: " + Directory.GetCurrentDirectory() + "\\log.txt");
                Console.ReadLine();
            }
            catch (Exception e)
            {
                Console.WriteLine(e.ToString());
                Console.ReadLine();
            }
        }
        private static void GenerateRequest(MyPriorityQueue<Request> queue, int step)
        {
            
            Random rnd = new Random();
            int countRequests = rnd.Next(1, 10);

            for (int i = 0; i <= countRequests; i++)
            {
                int priority = rnd.Next(1, 5);
                Request request = new Request(priority, numberRequest, step);
                numberRequest++;
                queue.Add(request);
                writer.WriteLine("ADD " + request.Number + " " + request.Priority + " " + request.Step);
            }
        }
    }
}
