using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ZedGraph;
using Test;
using static System.Net.Mime.MediaTypeNames;
using System.Drawing.Drawing2D;

namespace ConsoleApp1
{
    public partial class Graph : Form
    {
        int indexGroup = 0;
        int indexTestData = 0;

        public Graph(int a, int b)
        {
            InitializeComponent();
            indexGroup = a;
            indexTestData = b;
        }

        private void DrawGraph()
        {
            
            double[][] array = new double[0][];
            double[] x = new double[0];
            double[] y = new double[0];
            List<string> names = new List<string>();
            Color[] color = { Color.Coral, Color.PowderBlue, Color.RoyalBlue, Color.SpringGreen, Color.YellowGreen, Color.Violet, Color.Teal };
            Test.Test test = new Test.Test();
            int divisor = 1;
            switch (indexGroup + 1)
            {
                case 1:
                    array = new double[5][];
                    x = new double[5];

                    names.Add("Bubble");
                    names.Add("Insertion");
                    names.Add("Selection");
                    names.Add("Shaker");
                    names.Add("Gnome");
                    break;
                case 2:
                    array = new double[3][];
                    x = new double[3];

                    names.Add("Bitonic");
                    names.Add("Shell");
                    names.Add("Tree");
                    break;
                case 3:
                    array = new double[7][];
                    x = new double[7];

                    names.Add("Comb");
                    names.Add("Heap");
                    names.Add("Quick");
                    names.Add("Merge");
                    names.Add("Counting");
                    names.Add("Bucker");
                    names.Add("Radiax");
                    break;
                default:
                    array = new double[5][];
                    x = new double[5];
                    break;
            }
            GraphPane graphPane = zedGraphControl2.GraphPane;
            Dock = DockStyle.Fill;
            // Устанавливаем заголовки
            graphPane.Title.Text = "Зависимость кол-ва ";
            graphPane.XAxis.Title.Text = "Ось X";
            graphPane.YAxis.Title.Text = "Ось Y";
            graphPane.XAxis.Scale.Min = 0;
            graphPane.XAxis.Scale.Max = Math.Pow(10, x.Length);
            graphPane.XAxis.Scale.MinorStep = 100;
            graphPane.XAxis.Scale.MajorStep = 1000000;

            //результат - матрица, строки - номера сортировок, столбцы - группа тестовых данных.
            //первые n элементов в столбцах = делителям divisor - результаты сортировки на массивах размером 10 тестовых данных. каждые последующие n сортировок
            //в столбце - следующая степень 10 в размере массива.
            array = test.Testing(indexGroup + 1, indexTestData + 1);
            for (int i = 0; i < array.Length; i++)
            {
                int a = 0;
                for (int del = 0; del < divisor; del++)
                {
                    y = new double[divisor];
                    for (int j = 0; j < divisor; j++)
                    {
                        y[j] = array[i][a + del];
                    }
                    a += divisor;
                    LineItem lineItem = graphPane.AddCurve(names[i], x, array[i], color[i], SymbolType.Circle);
                    // Настройки линии
                    lineItem.Line.Width = 2.0f; // Ширина линии
                    lineItem.Line.IsSmooth = true; // Гладкая линия
                    lineItem.Line.SmoothTension = 0.5f; // Напряжение гладкой линии
                    lineItem.Symbol.Size = 6; // Размер символа на графике

                }
                if (a == array[i].Length)
                    continue;
            }
            zedGraphControl2.AxisChange();
            zedGraphControl2.Invalidate();
        }
        private void Graph_Load(object sender, EventArgs e)
        {
            DrawGraph();
        }

        static double[][] TransposeMatrix(double[][] matrix)
        {
            int rows = matrix.GetLength(0);
            double[][] transposed = new double[rows][];
            int columns = 0;
            foreach (double[] row in matrix)
            {
                columns = row.GetLength(0);
                transposed[columns] = new double[rows];
            }

            for (int i = 0; i < columns; i++)
            {
                for (int j = 0; j < rows; j++)
                {
                    transposed[j][i] = matrix[i][j];
                }
            }
            return transposed;
        }
    }
}
            
            /*for(int i = 0; i != array.Length; i++)
            {
                LineItem lineItem = graphPane.AddCurve(names[i], x, array[i], color[i], SymbolType.Circle);
                // Настройки линии
                lineItem.Line.Width = 2.0f; // Ширина линии
                lineItem.Line.IsSmooth = true; // Гладкая линия
                lineItem.Line.SmoothTension = 0.5f; // Напряжение гладкой линии
                lineItem.Symbol.Size = 6; // Размер символа на графике
            }
            
*/

            /*// Инициализация объекта GraphPane
            GraphPane graphPane = zedGraphControl2.GraphPane;

            // Устанавливаем заголовки
            graphPane.Title.Text = "Пример графика";
            graphPane.XAxis.Title.Text = "Ось X";
            graphPane.YAxis.Title.Text = "Ось Y";

            // Создаем объект линии
            for (int i = 0; i < array.Length; i++)
            {
                LineItem lineItem = graphPane.AddCurve("Моя Функция", x, y, Color.Red, SymbolType.Circle);
                // Настройки линии
                lineItem.Line.Width = 2.0f; // Ширина линии
                lineItem.Line.IsSmooth = true; // Гладкая линия
                lineItem.Line.SmoothTension = 0.5f; // Напряжение гладкой линии
                lineItem.Symbol.Size = 6; // Размер символа на графике
            }

            */

            // Отображаем график
            /*zedGraphControl2.AxisChange();
            zedGraphControl2.Invalidate();
        }*/

        /*private void DrawGraph()
        {
            // Создаем массив точек
            double[] x = new double[0];
            double[] y = new double[0];
            int size = 0;
            Test.Test test = new Test.Test();

            if (indexGroup == 0)
            {
                size = 10000;
                y = new double[5];
                x = new double[5];
                int index = 0;
                for (int i = 10; i < size +1; i *= 10)
                {
                    x[index] = (double)i;
                    index++;
                }
                y = test.Testing(indexGroup + 1, indexTestData + 1);
            }
            else if (indexGroup == 1)
            {
                size = 100000;
                y = new double[3];
                x = new double[3];
                for (int i = 10; i < size + 1; i *= 10)
                {
                    x[i] = (double)i;
                }
                y = test.Testing(indexGroup + 1, indexTestData + 1);
            }
            else if (indexGroup == 2)
            {
                size = 1000000;
                y = new double[7];
                x = new double[7];
                for (int i = 10; i < size + 1; i *= 10)
                {
                    x[i] = (double)i;
                }
                y = test.Testing(indexGroup + 1, indexTestData + 1);
            }

            // Инициализация объекта GraphPane
            GraphPane graphPane = zedGraphControl2.GraphPane;

            // Устанавливаем заголовки
            graphPane.Title.Text = "Пример графика";
            graphPane.XAxis.Title.Text = "Ось X";
            graphPane.YAxis.Title.Text = "Ось Y";

            // Создаем объект линии
            LineItem lineItem = graphPane.AddCurve("Моя Функция", x, y, Color.Red, SymbolType.Circle);

            // Настройки линии
            lineItem.Line.Width = 2.0f; // Ширина линии
            lineItem.Line.IsSmooth = true; // Гладкая линия
            lineItem.Line.SmoothTension = 0.5f; // Напряжение гладкой линии
            lineItem.Symbol.Size = 6; // Размер символа на графике

            // Отображаем график
            zedGraphControl2.AxisChange();
            zedGraphControl2.Invalidate();
        }*/


