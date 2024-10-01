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
        Test.Test test;
        public Menu()
        {
            test = new Test.Test();
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if(firstCombox && secondCombox && genArrButton)
            {               
                test.StartTest();
                Close();
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
            if (genArrButton == false && firstCombox == true && secondCombox == true)
            {
                if (comboBox2.SelectedIndex != null && comboBox1.SelectedIndex != null)
                {

                    test.InitialTest(comboBox1.SelectedIndex, comboBox2.SelectedIndex);
                    genArrButton = true;
                }                
            }
        }
    }
}
