using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ConsoleApp1
{
    public partial class Menu : Form
    {
        bool firstCombox = false;
        bool secondCombox = false;
        public Menu()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if(firstCombox && secondCombox)
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
    }
}
