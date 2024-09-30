using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Test;

namespace ConsoleApp1
{
    public partial class Menu : Form
    {
        bool firstCombox = false;
        bool secondCombox = false;
        bool genArrButton = false;
        public Menu()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if(firstCombox && secondCombox && genArrButton)
            {
                Graph graph = new Graph(comboBox1.SelectedIndex, comboBox2.SelectedIndex);
                graph.ShowDialog();
            }
        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            secondCombox = true;
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            firstCombox = true;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (genArrButton == false)
            {
                if (comboBox2.SelectedIndex != null && comboBox1.SelectedIndex != null)
                {
                    Test.Test test = new Test.Test();
                    test.GenerateArrays(comboBox1.SelectedIndex, comboBox2.SelectedIndex);
                    genArrButton = true;
                }                
            }
        }
    }
}
