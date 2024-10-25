using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    internal class Request : IComparable<Request>, IDisposable
    {
        private int priority;
        private int number;
        private int step;
        private Stopwatch stopwatch;

        public int Priority => priority;
        public int Number => number;
        public int Step => step;
        public Stopwatch Stopwatch => stopwatch;

        public Request(int priority, int number, int step)
        {
            this.priority = priority;
            this.number = number;
            this.step = step;
            stopwatch = Stopwatch.StartNew();
        }

        ~Request()
        {
            Dispose(false);
            stopwatch.Stop();
            Console.WriteLine(stopwatch.ElapsedMilliseconds);
        }

        public int CompareTo(Request other)
        {
            if (other == null)
                return 1; // Текущий объект больше, чем null

            // Сравниваем по полю priority
            return this.priority.CompareTo(other.priority);
        }

        // Флаг для отслеживания вызова Dispose
        private bool disposed = false;

        // Метод для освобождения неуправляемых ресурсов
        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this); // Подавить финализацию
        }

        // Метод, который может быть вызван в Dispose и финализаторе
        protected virtual void Dispose(bool disposing)
        {
            if (!disposed)
            {
                if (disposing)
                {
                    // Освобождение управляемых ресурсов (если есть)
                    Console.WriteLine("Освобождение управляемых ресурсов.");
                }

                // Освобождение неуправляемых ресурсов (если есть)
                Console.WriteLine("Освобождение неуправляемых ресурсов.");

                disposed = true; // Сброс флага
            }
        }
    }
}
