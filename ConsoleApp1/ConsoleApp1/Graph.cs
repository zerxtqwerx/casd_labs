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
using TestData;
using System.Security.Policy;

namespace ConsoleApp1
{
    public partial class Graph : Form
    {
        ZedGraphControl zedGraphControl2;
        int indexGroup = 0;
        int indexTestData = 0;
        int indexChapter = 0;
        int indexName = 0;
        int indexColor = 0;
        int size = 0;
        List<string> names = new List<string>();
        List<string> chapters = new List<string>();
        Color[] color = { Color.Coral, Color.PowderBlue, Color.RoyalBlue, Color.SpringGreen, Color.YellowGreen, Color.Violet, Color.Teal };


        public Graph(int a, int b, int size_, double[] x, long[][] y)
        {
            indexGroup = a;
            indexTestData = b;

            switch (indexGroup)
            {
                case 1:
                    names.Add("Bubble");
                    names.Add("Insertion");
                    names.Add("Selection");
                    names.Add("Shaker");
                    names.Add("Gnome");
                    break;
                case 2:
                    names.Add("Bitonic");
                    names.Add("Shell");
                    names.Add("Tree");
                    break;
                case 3:
                    names.Add("Comb");
                    names.Add("Heap");
                    names.Add("Quick");
                    names.Add("Merge");
                    names.Add("Counting");
                    names.Add("Bucker");
                    names.Add("Radiax");
                    break;
                default:
                    break;
            }
            switch (indexTestData)
            {
                case 1:
                    chapters.Add("Массивы случайных чисел по модулю 1000");
                    break;
                case 2:
                    chapters.Add("Массивы, разбитые на несколько отсортированных подмассивов разного размера");
                    break;
                case 3:
                    chapters.Add("Изначально отсортированные массивы случайных чисел с некоторым числом перестановок двух случайных элементов");
                    break;
                case 4:
                    chapters.Add("Полностью отсортированные массивы в прямом порядке");
                    chapters.Add("Полностью отсортированные массивы в обратном порядке");
                    chapters.Add("Полностью отсортированные массивы с несколькими заменёнными элементами");
                    chapters.Add("Полностью отсортированные массивы с большим количеством повторений одного элемента");
                    break;
                default:
                    chapters.Add("Массивы случайных чисел по модулю 1000");
                    break;
            }

            zedGraphControl2 = new ZedGraphControl { Dock = DockStyle.Fill };
            this.Controls.Add(zedGraphControl2);
            GraphPane graphPane = zedGraphControl2.GraphPane;
            // Устанавливаем заголовки
            if (chapters != null)
            {
                graphPane.Title.Text = chapters[0].ToString();
                indexChapter++;
            }
            graphPane.XAxis.Title.Text = "Ось X";
            graphPane.YAxis.Title.Text = "Ось Y";
            /*graphPane.XAxis.Scale.Min = 10;
            graphPane.XAxis.Scale.Max = size;

            graphPane.YAxis.Scale.Min = 0;
            graphPane.YAxis.Scale.Max = 100;
            graphPane.YAxis.Scale.MinorStep = 0;
            graphPane.YAxis.Scale.MajorStep = size;*/

            for (int i = 0; i < y.Length; i++)
            {
                PointPairList points = new PointPairList();
                for(int j = 0; j != y[i].Length; j++)
                {
                    points.Add(x[j], y[i][j]);
                }
                LineItem lineItem = graphPane.AddCurve(names[i], points, color[i], SymbolType.Circle);

                // Настройки линии
                lineItem.Line.Width = 2.0f; // Ширина линии
                lineItem.Line.IsSmooth = true; // Гладкая линия
                lineItem.Line.SmoothTension = 0.5f; // Напряжение гладкой линии
                lineItem.Symbol.Size = 6; // Размер символа на графике


                //нет ивента чтобы изменить график на форме
            }
            /*            InitializeComponent();
                        zedGraphControl2.AxisChange();
                        zedGraphControl2.Invalidate();*/

            //InitializeComponent();
            InitializeComponent();
            zedGraphControl2.AxisChange();
            zedGraphControl2.Invalidate();

        }
    }
}


        /*private void zedGraphControl2_Load(object sender, EventArgs e)
        {
            double[] x;
            double[][] y;

        }*/

        /*//результат - матрица, строки - номера сортировок, столбцы - группа тестовых данных.
        //первые n элементов в столбцах = делителям divisor - результаты сортировки на массивах размером 10 тестовых данных. каждые последующие n сортировок
        //в столбце - следующая степень 10 в размере массива.
        //array = test.Testing(indexGroup + 1, indexTestData + 1);
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
        }*/
/*
        private void Graph_Load(object sender, EventArgs e)
        {
            //DrawGraph();
        }

    }
}*/
         

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


