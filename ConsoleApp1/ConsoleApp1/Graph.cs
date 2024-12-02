using System;
using System.Windows.Forms;
using ZedGraph;
using System.Collections.Generic;
using System.Drawing;

namespace ConsoleApp1
{
    public partial class Graph : Form
    {
        ZedGraphControl zedGraphControl;
        int functionIndex = 0;
        String[] names = { "Add (value)", "Get (value)", "Set (index, value)", "Add (index, value)", "Remove (index)" };
        string name;
        Color color1 = new Color();
        Color color2 = new Color();
        Test test = new Test();

        public Graph()
        {
            InitializeComponent();
            this.Controls.Add(comboBox1);
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            functionIndex = comboBox1.SelectedIndex;
            name = comboBox1.SelectedText;
            DrawGraph();
        }

        private void DrawGraph()
        {
            functionIndex = comboBox1.SelectedIndex;
            zedGraphControl = new ZedGraphControl { Dock = DockStyle.Fill };
            this.Controls.Add(zedGraphControl);
            GraphPane graphPane = zedGraphControl.GraphPane;
            graphPane.Title.Text = name;
            graphPane.XAxis.Title.Text = "Ось X";
            graphPane.YAxis.Title.Text = "Ось Y";
            double[] X = { 100, 1000, 10000, 100000};
            double[] Y1 = new double[4];
            double[] Y2 = new double[4];

            switch (functionIndex)
            {
                case 0:
                    {
                        Y1 = test.TestPutHashMap();
                        Y2 = test.TestPutTreeMap();
                        color1 = Color.PowderBlue;
                        color2 = Color.PaleGreen;
                        break;
                    }
                case 1:
                    {
                        Y1 = test.TestGetHashMap();
                        Y2 = test.TestGetTreeMap();
                        color1 = Color.DarkBlue;
                        color2 = Color.HotPink;
                        break;
                    }
                case 2:
                    {
                        Y1 = test.TestRemoveHashMap();
                        Y2 = test.TestRemoveTreeMap();
                        color1 = Color.LightCyan;
                        color2 = Color.MediumBlue;
                        break;
                    }
                default:
                    {
                        Y1 = test.TestPutHashMap();
                        Y2 = test.TestPutTreeMap();
                        color1 = Color.PowderBlue;
                        color2 = Color.PaleGreen;
                        break;
                    }
            }
            graphPane.AddCurve("MyHashMap", X, Y1, color1);
            graphPane.AddCurve("MyTreeMap", X, Y2, color2);

            InitializeComponent();
            zedGraphControl.AxisChange();
            zedGraphControl.Invalidate();
        }
    }
}
