﻿using System;
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
        bool OpponentTurned = false;

        string my_name;

        public Form1()
        {
            System.Windows.Forms.Control.CheckForIllegalCrossThreadCalls = false;
            InitializeComponent();
        }

        private void SendCommand(int row, int col)
        {
            string reply;
            reply = service.SendCommandGame(row, col, my_name);

            if(reply.Equals("W"))
            {
                ConfirmCommand(row, col);
                OpponentTurned = true;
                // TODO: Create receive thread
            }

            if(reply.Equals("TiW"))
            {
                ConfirmCommand(row, col);
                MyScoreUp();

                IsConnected = false;
                OpponentConnected = false;

                string info = "Tic wins!";
                Logs.AddToLog(textBox1, info);
            }

            if (reply.Equals("ToW"))
            {
                ConfirmCommand(row, col);
                MyScoreUp();

                IsConnected = false;
                OpponentConnected = false;

                string info = "Toe wins!";
                Logs.AddToLog(textBox1, info);
            }

            if (reply.Equals("D"))
            {
                ConfirmCommand(row, col);

                IsConnected = false;
                OpponentConnected = false;

                string info = "Draw!";
                Logs.AddToLog(textBox1, info);
            }

            if (reply.Equals("E"))
            {
                string info = "This cell already occupied! You should choose another cell";
                Logs.AddToLog(textBox1, info);
            }
        }

        private void ConfirmCommand(int row, int col)
        {
            if(row == 0 && col == 0)
            {
                if (my_name.Equals("Tic"))
                {
                    button1.Text = "X";
                }
                else
                {
                    button1.Text = "O";
                }
            }

            if (row == 0 && col == 1)
            {
                if (my_name.Equals("Tic"))
                {
                    button2.Text = "X";
                }
                else
                {
                    button2.Text = "O";
                }
            }

            if (row == 0 && col == 2)
            {
                if (my_name.Equals("Tic"))
                {
                    button3.Text = "X";
                }
                else
                {
                    button3.Text = "O";
                }
            }

            if (row == 1 && col == 0)
            {
                if (my_name.Equals("Tic"))
                {
                    button4.Text = "X";
                }
                else
                {
                    button4.Text = "O";
                }
            }

            if (row == 1 && col == 1)
            {
                if (my_name.Equals("Tic"))
                {
                    button5.Text = "X";
                }
                else
                {
                    button5.Text = "O";
                }
            }

            if (row == 1 && col == 2)
            {
                if (my_name.Equals("Tic"))
                {
                    button6.Text = "X";
                }
                else
                {
                    button6.Text = "O";
                }
            }

            if (row == 2 && col == 0)
            {
                if (my_name.Equals("Tic"))
                {
                    button7.Text = "X";
                }
                else
                {
                    button7.Text = "O";
                }
            }

            if (row == 2 && col == 1)
            {
                if (my_name.Equals("Tic"))
                {
                    button8.Text = "X";
                }
                else
                {
                    button8.Text = "O";
                }
            }

            if (row == 2 && col == 2)
            {
                if (my_name.Equals("Tic"))
                {
                    button9.Text = "X";
                }
                else
                {
                    button9.Text = "O";
                }
            }
        }

        private void MyScoreUp()
        {
            int curr_score = Convert.ToInt32(label4.Text);
            curr_score++;

            label4.Text = curr_score.ToString();
        }

        private void EnemyScoreUp()
        {
            int curr_score = Convert.ToInt32(label5.Text);
            curr_score++;

            label5.Text = curr_score.ToString();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if(OpponentConnected)
            {
                if (!OpponentTurned)
                {
                    cell_coord_row = 0;
                    cell_coord_col = 0;

                    SendCommand(0, 0);
                }
                else
                {
                    string info = "Opponent turn. Please wait";
                    Logs.AddToLog(textBox1, info);
                }
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
                if (!OpponentTurned)
                {
                    cell_coord_row = 0;
                    cell_coord_col = 1;

                    SendCommand(0, 1);
                }
                else
                {
                    string info = "Opponent turn. Please wait";
                    Logs.AddToLog(textBox1, info);
                }
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
                if (!OpponentTurned)
                {
                    cell_coord_row = 0;
                    cell_coord_col = 2;

                    SendCommand(0, 2);
                }
                else
                {
                    string info = "Opponent turn. Please wait";
                    Logs.AddToLog(textBox1, info);
                }
            }
            else
            {
                string info = "Opponent is not connected. Please wait";
                Logs.AddToLog(textBox1, info);
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            if (!OpponentTurned)
            {
                cell_coord_row = 1;
                cell_coord_col = 0;

                SendCommand(1, 0);
            }
            else
            {
                string info = "Opponent turn. Please wait";
                Logs.AddToLog(textBox1, info);
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            if (OpponentConnected)
            {
                if (!OpponentTurned)
                {
                    cell_coord_row = 1;
                    cell_coord_col = 1;

                    SendCommand(1, 1);
                }
                else
                {
                    string info = "Opponent turn. Please wait";
                    Logs.AddToLog(textBox1, info);
                }
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
                if (!OpponentTurned)
                {
                    cell_coord_row = 1;
                    cell_coord_col = 2;

                    SendCommand(1, 2);
                }
                else
                {
                    string info = "Opponent turn. Please wait";
                    Logs.AddToLog(textBox1, info);
                }
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
                if (!OpponentTurned)
                {
                    cell_coord_row = 2;
                    cell_coord_col = 0;

                    SendCommand(2, 0);
                }
                else
                {
                    string info = "Opponent turn. Please wait";
                    Logs.AddToLog(textBox1, info);
                }
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
                if (!OpponentTurned)
                {
                    cell_coord_row = 2;
                    cell_coord_col = 1;

                    SendCommand(2, 1);
                }
                else
                {
                    string info = "Opponent turn. Please wait";
                    Logs.AddToLog(textBox1, info);
                }
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
                if (!OpponentTurned)
                {
                    cell_coord_row = 2;
                    cell_coord_col = 2;

                    SendCommand(2, 2);
                }
                else
                {
                    string info = "Opponent turn. Please wait";
                    Logs.AddToLog(textBox1, info);
                }
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
                    OpponentTurned = false;

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
                    OpponentTurned = true;

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
