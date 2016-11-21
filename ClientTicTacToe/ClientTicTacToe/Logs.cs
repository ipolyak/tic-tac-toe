using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace ClientTicTacToe
{
    class Logs
    {
        public static void AddToLog(TextBox Logs, String info)
        {
            Logs.Text += info + "\r\n";
        }
    }
}
