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
        static protected List<List<String>> arrPlayers = new List<List<String>>();
        static protected List<List<TicTacToeLogic.VERDICT>> arrVerdicts = new List<List<TicTacToeLogic.VERDICT>>();
        static protected List<List<String>> arrCommands = new List<List<String>>();

        private static Mutex mut = new Mutex();

        private static List<List<int>> curTurnTic = new List<List<int>>();
        private static List<List<int>> curTurnToe = new List<List<int>>();
        private static List<List<int>> num_turn = new List<List<int>>();

        private static List<TicTacToeLogic.STATE_CELL[,]> GameAreaList = new List<TicTacToeLogic.STATE_CELL[,]>();

        private static int group_count = 0;


        private void ClearData(int group)
        {
            for (int i = 0; i < 9; i++)
            {
                arrVerdicts[group][i] = TicTacToeLogic.VERDICT.NONE;
            }

            arrCommands[group].Clear();
            arrPlayers[group].Clear();
        }

        [WebMethod]
        public int CreateGame(string player_name)
        {
            mut.WaitOne();

            int group = group_count;
            List<string> L = new List<string>();

            arrPlayers.Add(L);

            arrPlayers[group].Add(player_name);

            List<int> T = new List<int>(1);
            List<int> O = new List<int>(1);

            curTurnTic.Add(T);
            curTurnToe.Add(O);

            curTurnTic[group][0] = 0;
            curTurnToe[group][0] = 0;

            List<TicTacToeLogic.VERDICT> V = new List<TicTacToeLogic.VERDICT>(9);
            arrVerdicts.Add(V);

            for (int i = 0; i < 9; i++)
            {
                arrVerdicts[group][i] = TicTacToeLogic.VERDICT.NONE;
            }

            List<string> C = new List<string>(9);
            arrCommands.Add(C);

            TicTacToeLogic.STATE_CELL[,] GameArea = new TicTacToeLogic.STATE_CELL[TicTacToeLogic.MAX_ROW, TicTacToeLogic.MAX_COL];
            GameAreaList.Add(GameArea);

            List<int> N = new List<int>(1);
            num_turn.Add(N);

            num_turn[group][0] = 0;

            TicTacToeLogic.InitGame(GameAreaList[group]);

            mut.ReleaseMutex();

            return group; // Creating success
        
        }

        [WebMethod]
        public int JoinToGame(string player_name)
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

                if(verdict == TicTacToeLogic.VERDICT.CONTINUE)
                {
                    mut.WaitOne();
                    arrVerdicts[curTurnTic] = verdict;
                    arrCommands.Add(command);
                    curTurnTic++;
                    mut.ReleaseMutex();

                    return "W"; // Continue game. Wait the opponent
                } else if(verdict == TicTacToeLogic.VERDICT.TIC_WINS)
                {
                    TicTacToeLogic.InitGame();

                    mut.WaitOne();
                    arrVerdicts[curTurnTic] = verdict;
                    arrCommands.Add(command);
                    curTurnTic++;
                    mut.ReleaseMutex();

                    return "TiW"; // Tic wins
                } else if(verdict == TicTacToeLogic.VERDICT.DRAW)
                {
                    TicTacToeLogic.InitGame();

                    mut.WaitOne();
                    arrVerdicts[curTurnTic] = verdict;
                    arrCommands.Add(command);
                    curTurnTic++;
                    mut.ReleaseMutex();

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

                if (verdict == TicTacToeLogic.VERDICT.CONTINUE)
                {
                    mut.WaitOne();
                    arrVerdicts[curTurnToe] = verdict;
                    arrCommands.Add(command);
                    curTurnToe++;
                    mut.ReleaseMutex();

                    return "W"; // Continue game. Wait the opponent
                }
                else if (verdict == TicTacToeLogic.VERDICT.TOE_WINS)
                {
                    TicTacToeLogic.InitGame();

                    mut.WaitOne();
                    arrVerdicts[curTurnToe] = verdict;
                    arrCommands.Add(command);
                    curTurnToe++;
                    mut.ReleaseMutex();

                    return "ToW"; // Toe wins
                    
                }
                else if (verdict == TicTacToeLogic.VERDICT.DRAW)
                {
                    TicTacToeLogic.InitGame();

                    mut.WaitOne();
                    arrVerdicts[curTurnToe] = verdict;
                    arrCommands.Add(command);
                    curTurnToe++;
                    mut.ReleaseMutex();

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
                return message; // Draw
            }

            if (player_name.Equals("Tic") && arrVerdicts[curTurnTic].Equals(TicTacToeLogic.VERDICT.DRAW))
            {
                //Send opponent command
                string message = "D" + "#" + arrCommands[curTurnTic];
                ClearData();
                return message; // Draw
            }

            return "W" + "#";
        }

    }
}
