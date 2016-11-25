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
        static protected ArrayList arrCommands = new ArrayList(9);

        private static Mutex mut = new Mutex();

        private static int curTurnTic = 0;
        private static int curTurnToe = 0;

        private void ClearData()
        {
            curTurnTic = 0;
            curTurnToe = 0;

            for (int i = 0; i < 9; i++)
            {
                arrVerdicts[i] = TicTacToeLogic.VERDICT.NONE;
                arrCommands.RemoveAt(i);
            }

            for(int i = 0; i < arrPlayers.Count; i++)
            {
                arrPlayers.RemoveAt(i);
            }
        }

        [WebMethod]
        public string CreateGame(string player_name)
        {
            mut.WaitOne();
            if (arrPlayers.Count == 0)
            {
                arrPlayers.Add(player_name);
                curTurnTic = 0;
                curTurnToe = 0;

                for (int i = 0; i < 9; i++)
                {
                    arrVerdicts.Add(TicTacToeLogic.VERDICT.NONE);
                }

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
        public TicTacToeLogic.VERDICT Check()
        {
            return (TicTacToeLogic.VERDICT)arrVerdicts[0];
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
        public string SendCommandGame(int row, int col, string player_name)
        {
            TicTacToeLogic.VERDICT verdict;

            if(player_name.Equals("Tic"))
            {
                String command = row.ToString() + ":" + col.ToString();
                verdict = TicTacToeLogic.TickMoved(row, col);

                mut.WaitOne();
                arrVerdicts[curTurnTic] = verdict;
                arrCommands.Add(command);
                curTurnTic++;
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
                String command = row.ToString() + ":" + col.ToString();
                verdict = TicTacToeLogic.ToeMoved(row, col);

                mut.WaitOne();
                arrVerdicts[curTurnToe] = verdict;
                arrCommands.Add(command);
                curTurnToe++;
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
            if(player_name.Equals("Tic") && arrVerdicts[curTurnTic].Equals(TicTacToeLogic.VERDICT.NONE))
            {
                return "W" + "#"; // Wait the opponent
            }

            if (player_name.Equals("Toe") && arrVerdicts[curTurnToe].Equals(TicTacToeLogic.VERDICT.NONE))
            {
                return "W" + "#"; // Wait the opponent
            }

            if (player_name.Equals("Tic") && arrVerdicts[curTurnTic].Equals(TicTacToeLogic.VERDICT.CONTINUE))
            {
                //Send opponent command
                string message = "C" + "#" + arrCommands[curTurnTic];
                curTurnTic++;
                return message; // Continue. Your turn
            }

            if (player_name.Equals("Toe") && arrVerdicts[curTurnToe].Equals(TicTacToeLogic.VERDICT.CONTINUE))
            {
                //Send opponent command
                string message = "C" + "#" + arrCommands[curTurnToe];
                curTurnToe++;
                return message; // Continue. Your turn
            }

            if (player_name.Equals("Toe") && arrVerdicts[curTurnToe].Equals(TicTacToeLogic.VERDICT.TIC_WINS))
            {
                //Send opponent command
                string message = "TiW" + "#" + arrCommands[curTurnToe];
                ClearData();
                return message; // Tic wins
            }

            if (player_name.Equals("Tic") && arrVerdicts[curTurnTic].Equals(TicTacToeLogic.VERDICT.TOE_WINS))
            {
                //Send opponent command
                string message = "ToW" + "#" + arrCommands[curTurnTic];
                ClearData();
                return message; // Toe wins
            }

            if (player_name.Equals("Toe") && arrVerdicts[curTurnToe].Equals(TicTacToeLogic.VERDICT.DRAW))
            {
                //Send opponent command
                string message = "D" + "#" + arrCommands[curTurnToe];
                ClearData();
                return "D"; // Draw
            }

            if (player_name.Equals("Tic") && arrVerdicts[curTurnTic].Equals(TicTacToeLogic.VERDICT.DRAW))
            {
                //Send opponent command
                string message = "D" + "#" + arrCommands[curTurnTic];
                ClearData();
                return "D"; // Draw
            }

            return "W" + "#";
        }

    }
}
