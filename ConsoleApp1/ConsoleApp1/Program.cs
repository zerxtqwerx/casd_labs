using ConsoleApp1;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Program
{
    internal class Program
    {
        [STAThread]
        static void Main(string[] args)
        {
            Menu menu = new Menu();
            menu.ShowDialog();
            Console.ReadLine();
        }
    }
}
