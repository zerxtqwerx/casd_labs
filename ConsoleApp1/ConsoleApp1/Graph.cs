using System;
using System.Windows.Forms;
using ZedGraph;
using System.Collections.Generic;

namespace ConsoleApp1
{
    public partial class Graph : Form
    {
        ZedGraphControl zedGraphControl;
        int functionIndex = 0;
        String[] names = { "Add (value)", "Get (value)", "Set (index, value)", "Add (index, value)", "Remove (index)" };

        public Graph()
        {
            InitializeComponent();
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            functionIndex = comboBox1.SelectedIndex;
            DrawGraph();
        }

        private void DrawGraph()
        {
            zedGraphControl = new ZedGraphControl { Dock = DockStyle.Fill };
            this.Controls.Add(zedGraphControl);
            GraphPane graphPane = zedGraphControl.GraphPane;
        }
    }
}
