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
using System.Threading;

namespace TicTacToeClient
{
    public partial class Form1 : Form
    {
        TicTacToeWebService service = new TicTacToeWebService();
        int cell_coord_row = -1;
        int cell_coord_col = -1;
        bool IsConnected = false;
        bool OpponentConnected = false;

        string my_name;

        public Form1()
        {
            System.Windows.Forms.Control.CheckForIllegalCrossThreadCalls = false;
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

                my_name = "Tic";
                reply = service.CreateGame(my_name);

                if (reply.Equals("CS"))
                {
                    // Waiting connecting of opponent
                    IsConnected = true;

                    string info = "Game created succesfully. Please wait the opponent!";
                    Logs.AddToLog(textBox1, info);

                    Thread WaitOponnentThread = new Thread(WaitOp);
                    WaitOponnentThread.Start();
                }
                else
                {
                    string info = "Game already created by some user!";
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
            if (IsConnected)
            {
                string reply;
                reply = service.ExitFromGame(my_name);
                if(reply.Equals("ES"))
                {
                    string info = "Exit from game succesfull!";
                    Logs.AddToLog(textBox1, info);
                }
                IsConnected = false;
            }
            else
            {
                string info = "You are not connected to game!";
                Logs.AddToLog(textBox1, info);
            }
        }

        private void button12_Click(object sender, EventArgs e)
        {
            if (!IsConnected)
            {
                string reply;

                my_name = "Toe";
                reply = service.JoinToGame(my_name);
                if(reply.Equals("JS"))
                {
                    IsConnected = true;
                    string info = "Join to game succesfull!";
                    Logs.AddToLog(textBox1, info);
                }
                else
                {
                    string info = "Game is not exist. You should create the game!";
                    Logs.AddToLog(textBox1, info);
                }
            }
            else
            {
                string info = "You are already in game!";
                Logs.AddToLog(textBox1, info);
            }
        }

        private void WaitOp()
        {
            while(true)
            {
                string reply;
                reply = service.WaitOpponent();
                if(reply.Equals("OC"))
                {
                    string info = "Opponent is connected. Your turn!";
                    Logs.AddToLog(textBox1, info);
                    OpponentConnected = true;

                    break;
                }

                Thread.Sleep(1000);
            }
        }
    }
}
