using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections;

/*Описать метод, находящий длину 𝑥 вектора в 𝑁-мерном пространстве. Пространство
задаётся матрицей метрического тензора 𝐺 (если интересно, то можно почитать, что это,
если нет, то нет). Матрица 𝐺 должна быть симметричной, её размерность совпадает с
размерностью пространства. Нахождение длины: √𝑥 × 𝐺 × 𝑥
𝑇. Размерность пространства,
матрица тензора и вектор вводятся из файла. Память выделяется динамически; проверка
на то, что матрица симметрична – необходима. Результат выводится на экран.*/

namespace CASD_1
{
    internal class Program
    {
        static StreamReader streamReader;
        
        static int n = 0;   //мерность пространства
        static double[] x;  //вектор
        static double[,] g; //матрица тензора

        static void Main(string[] args)
        {

            string[] Lines;
            try
            {
                Lines = File.ReadAllLines("D:\\GitDesc\\casd_labs\\ConsoleApp1\\Sample.txt");
                x = Array.ConvertAll(Lines[0].Split(' '), double.Parse);
                n = x.Length;

                g = new double[n, n];
                MatrixInput(g, Lines);
                if (!IsSymmetric(g))
                {
                    Console.WriteLine("Матрица нессиметрична. Повторите ввод: ");
                }
                
            }
            catch 
            { 
                Console.WriteLine("Файла не существует");
                Console.ReadLine();
            }
            //x * g = vector
            double[] vector = new double[n]; 
            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < n; j++)
                {
                    vector[i] += x[j] * g[i, j];
                }
            }

            //vec * x^T = answer
            double answer = 0;
            for (int i = 0; i < n; i++)
            {
                answer += x[i] * vector[i];
            }

            Console.WriteLine($"Длина вектора X в {n}-мерном пространстве = {answer}");
            Console.Read();
        }

        static void MatrixInput(double[,] matr, string[] s)
        {
            for (int i = 0; i < n; i++)
            {
                string[] row = s[i + 2].Split(' ');
                for (int j = 0; j < n; j++)
                {
                    matr[i, j] = double.Parse(row[j]);
                }
                
            }
        }

        static bool IsSymmetric(double[,] matr)
        {
            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < n; j++)
                {
                    if (matr[i, j] != matr[j, i]) return false;
                }
            }
            return true;
        }
    }
}
