using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TicTacToeClient
{
    public partial class Form1 : Form
    {
        int cell_coord = -1;

        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            cell_coord = 1;
            Logs.AddToLog(textBox1, "21");
        }

        private void button2_Click(object sender, EventArgs e)
        {
            cell_coord = 2;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            cell_coord = 3;
        }

        private void button5_Click(object sender, EventArgs e)
        {
            cell_coord = 4;
        }

        private void button4_Click(object sender, EventArgs e)
        {
            cell_coord = 5;
        }

        private void button6_Click(object sender, EventArgs e)
        {
            cell_coord = 6;
        }

        private void button7_Click(object sender, EventArgs e)
        {
            cell_coord = 7;
        }

        private void button8_Click(object sender, EventArgs e)
        {
            cell_coord = 8;
        }

        private void button9_Click(object sender, EventArgs e)
        {
            cell_coord = 9;
        }

        private void button10_Click(object sender, EventArgs e)
        {

        }

        private void button11_Click(object sender, EventArgs e)
        {

        }
    }
}
