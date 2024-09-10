using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

/*Описать метод, находящий длину 𝑥 вектора в 𝑁-мерном пространстве. Пространство
задаётся матрицей метрического тензора 𝐺 (если интересно, то можно почитать, что это,
если нет, то нет). Матрица 𝐺 должна быть симметричной, её размерность совпадает с
размерностью пространства. Нахождение длины: √𝑥 × 𝐺 × 𝑥
𝑇. Размерность пространства,
матрица тензора и вектор вводятся из файла. Память выделяется динамически; проверка
на то, что матрица симметрична – необходима. Результат выводится на экран.*/

namespace KASD_1
{
    internal class Program
    {
        static int n; static double[] x;
        static double[,] g;

        static void Main(string[] args)
        {
            Console.WriteLine("Введите мерность пространства: ");
            n = Convert.ToInt32(Console.ReadLine());
            x = new double[n]; g = new double[n, n];


            Console.WriteLine("Введите вектор Х: ");
            for (int i = 0; i < n; i++)
            {
                x[i] = Convert.ToDouble(Console.ReadLine());
            }

            Console.WriteLine("Введите матрицу G: ");
            MatrixInput(g);
            while (!IsSymmetric(g))
            {
                Console.WriteLine("Матрица нессиметрична. Повторите ввод: ");
                MatrixInput(g);

            }
            
            //multiplication x * g = vector
            double[] vector = new double[n]; 
            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < n; j++)
                {
                    vector[i] += x[j] * g[i, j];
                }
            }

            //multiplication vec * x^T = answer
            double answer = 0;
            for (int i = 0; i < n; i++)
            {
                answer += x[i] * vector[i];
            }

            Console.WriteLine($"Длина вектора Ъ в N-мерном пространстве = {answer}");
            Console.Read();
        }

        //function of input matrix from console
        static void MatrixInput(double[,] matr)
        {
            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < n; j++)
                {
                    g[i, j] = Convert.ToDouble(Console.ReadLine());
                }
            }
        }

        //function of checking matrix for symmetry
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
