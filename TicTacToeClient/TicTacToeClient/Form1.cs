using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using TicTacToeClient.GameService;

namespace TicTacToeClient
{
    public partial class Form1 : Form
    {
        TicTacToeWebService service = new TicTacToeWebService();
        int cell_coord_row = -1;
        int cell_coord_col = -1;
        bool IsConnected = false;
        bool OpponentConnected = false;

        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if(OpponentConnected)
            {
                cell_coord_row = 0;
                cell_coord_col = 0;
            }
            else
            {
                string info = "Opponent is not connected. Please wait";
                Logs.AddToLog(textBox1, info);
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (OpponentConnected)
            {
                cell_coord_row = 0;
                cell_coord_col = 1;
            }
            else
            {
                string info = "Opponent is not connected. Please wait";
                Logs.AddToLog(textBox1, info);
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (OpponentConnected)
            {
                cell_coord_row = 0;
                cell_coord_col = 2;
            }
            else
            {
                string info = "Opponent is not connected. Please wait";
                Logs.AddToLog(textBox1, info);
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            cell_coord_row = 1;
            cell_coord_col = 0;
        }

        private void button4_Click(object sender, EventArgs e)
        {
            if (OpponentConnected)
            {
                cell_coord_row = 1;
                cell_coord_col = 1;
            }
            else
            {
                string info = "Opponent is not connected. Please wait";
                Logs.AddToLog(textBox1, info);
            }
        }

        private void button6_Click(object sender, EventArgs e)
        {
            if (OpponentConnected)
            {
                cell_coord_row = 1;
                cell_coord_col = 2;
            }
            else
            {
                string info = "Opponent is not connected. Please wait";
                Logs.AddToLog(textBox1, info);
            }
        }

        private void button7_Click(object sender, EventArgs e)
        {
            if (OpponentConnected)
            {
                cell_coord_row = 2;
                cell_coord_col = 0;
            }
            else
            {
                string info = "Opponent is not connected. Please wait";
                Logs.AddToLog(textBox1, info);
            }
        }

        private void button8_Click(object sender, EventArgs e)
        {
            if (OpponentConnected)
            {
                cell_coord_row = 2;
                cell_coord_col = 1;
            }
            else
            {
                string info = "Opponent is not connected. Please wait";
                Logs.AddToLog(textBox1, info);
            }
        }

        private void button9_Click(object sender, EventArgs e)
        {
            if (OpponentConnected)
            {
                cell_coord_row = 2;
                cell_coord_col = 2;
            }
            else
            {
                string info = "Opponent is not connected. Please wait";
                Logs.AddToLog(textBox1, info);
            }
        }

        private void button10_Click(object sender, EventArgs e)
        {
            if(!IsConnected)
            {
                string reply;
                reply = service.CreateGame("Tic");
                if(reply.Equals("CS"))
                {
                    // Waiting connecting of opponent
                    IsConnected = true;
                }
                else
                {
                    string info = "Game already created!";
                    Logs.AddToLog(textBox1, info);
                }
            }
            else
            {
                string info = "Game already created!";
                Logs.AddToLog(textBox1, info);
            }
        }

        private void button11_Click(object sender, EventArgs e)
        {

        }

        private void button12_Click(object sender, EventArgs e)
        {
            if (!IsConnected)
            {

                IsConnected = true;
            }
            else
            {
                string info = "You are already in game!";
                Logs.AddToLog(textBox1, info);
            }
        }
    }
}
