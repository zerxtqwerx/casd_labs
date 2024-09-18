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
                for (int i = 10; i != size; i *= 10)
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
                for (int i = 10; i != size; i *= 10)
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
                for (int i = 10; i != size; i *= 10)
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
        }

        private void Graph_Load(object sender, EventArgs e)
        {
            DrawGraph();
        }
    }
}
