using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Web;
using System.Web.Services;

namespace TicTacToeServer
{
    /// <summary>
    /// Сводное описание для TicTacToeWebService
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // Чтобы разрешить вызывать веб-службу из скрипта с помощью ASP.NET AJAX, раскомментируйте следующую строку. 
    // [System.Web.Script.Services.ScriptService]
    public class TicTacToeWebService : System.Web.Services.WebService
    {
        static protected ArrayList arrPlayers = new ArrayList();
        static protected ArrayList arrVerdicts = new ArrayList(9);
        private static Mutex mut = new Mutex();

        private void ClearVerdicts()
        {
            for (int i = 0; i < 9; i++)
            {
                arrVerdicts.Add(TicTacToeLogic.VERDICT.NONE);
            }
        }

        [WebMethod]
        public string CreateGame(string player_name)
        {
            mut.WaitOne();
            if (arrPlayers.Count == 0)
            {
                arrPlayers.Add(player_name);
                ClearVerdicts();

                mut.ReleaseMutex();

                TicTacToeLogic.InitGame();

                return "CS"; // Creating success
            }
            else
            {
                mut.ReleaseMutex();
                return "CE"; // Creating error
            }
        }

        [WebMethod]
        public string JoinToGame(string player_name)
        {
            mut.WaitOne();
            if (arrPlayers.Count == 1)
            {
                arrPlayers.Add(player_name);
                mut.ReleaseMutex();

                return "JS"; // Join success
            }
            else
            {
                mut.ReleaseMutex();
                return "JE"; // Join error
            }
        }

        [WebMethod]
        public string ExitFromGame(string player_name)
        {
            mut.WaitOne();
            for (int i = 0; i < arrPlayers.Count; i++)
            {

                if (arrPlayers[i].ToString() == player_name)
                {
                    arrPlayers.RemoveAt(i);
                }
            }
            mut.ReleaseMutex();

            return "ES"; // Exit success 
        }

        [WebMethod]
        public string WaitOpponent()
        {
            mut.WaitOne();
            if (arrPlayers.Count == 2)
            {
                mut.ReleaseMutex();
                return "OC"; // Opponent connected
            }
            else
            {
                mut.ReleaseMutex();
                return "ON"; // Opponent is not connected
            }
        }

        [WebMethod]
        public string SendCommandGame(int row, int col, int player_name)
        {
            TicTacToeLogic.VERDICT verdict;

            if(player_name.Equals("Tic"))
            {
                verdict = TicTacToeLogic.TickMoved(row, col);

                mut.WaitOne();
                arrVerdicts.Add(verdict);
                mut.ReleaseMutex();

                if(verdict == TicTacToeLogic.VERDICT.CONTINUE)
                {
                    return "W"; // Continue game. Wait the opponent
                } else if(verdict == TicTacToeLogic.VERDICT.TIC_WINS)
                {
                    TicTacToeLogic.InitGame();
                    return "TiW"; // Tic wins
                } else if(verdict == TicTacToeLogic.VERDICT.DRAW)
                {
                    TicTacToeLogic.InitGame();
                    return "D"; // Draw
                } else
                {
                    return "E"; // Error, try to do another action
                }
            }
            else
            {
                verdict = TicTacToeLogic.ToeMoved(row, col);

                mut.WaitOne();
                arrVerdicts.Add(verdict);
                mut.ReleaseMutex();

                if (verdict == TicTacToeLogic.VERDICT.CONTINUE)
                {
                    return "W"; // Continue game. Wait the opponent
                }
                else if (verdict == TicTacToeLogic.VERDICT.TOE_WINS)
                {
                    TicTacToeLogic.InitGame();
                    return "ToW"; // Toe wins
                    
                }
                else if (verdict == TicTacToeLogic.VERDICT.DRAW)
                {
                    TicTacToeLogic.InitGame();
                    return "D"; // Draw
                }
                else
                {
                    return "E"; // Error, try to do another action
                }
            }
        }

        [WebMethod]
        public string ReceiveCommand(string player_name)
        {

            return "";
        }

    }
}
