using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
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
        static protected ArrayList arrCommands = new ArrayList();

        [WebMethod]
        public string CreateGame(string player_name)
        {
            if(arrPlayers.Count == 0)
            {
                arrPlayers.Add(player_name);
                TicTacToeLogic.InitGame();

                return "CS"; // Creating success
            }
            else
            {
                return "CE"; // Creating error
            }
        }

        [WebMethod]
        public string JoinToGame(string player_name)
        {
            if (arrPlayers.Count == 1)
            {
                arrPlayers.Add(player_name);

                return "JS"; // Join success
            }
            else
            {
                return "JE"; // Join error
            }
        }

        [WebMethod]
        public string ExitFromGame(string player_name)
        {
            for (int i = 0; i < arrPlayers.Count; i++)
            {
                if (arrPlayers[i].ToString() == player_name)
                    arrPlayers.RemoveAt(i);
            }

            return "ES"; // Exit success 
        }

        [WebMethod]
        public string WaitOpponent()
        {
            if (arrPlayers.Count == 2)
            {
                return "OC"; // Opponent connected
            }
            else
            {
                return "ON"; // Opponent is not connected
            }
        }

    }
}
